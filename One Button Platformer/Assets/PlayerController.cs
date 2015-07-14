using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int flyingForce = 5;

	private Rigidbody2D rigidBody;
	private Transform bottomLeft;
	private Transform bottomRight;

	private bool addingForceUp = false;

	// for debugging reasons
	private bool standingOnFloor;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		bottomLeft = transform.FindChild("bottomLeft");
		bottomRight = transform.FindChild("bottomRight");
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && StandingOnFloor()) {
			rigidBody.AddForce(new Vector2(5,5), ForceMode2D.Impulse);
			addingForceUp = true;
		}

		if (Input.GetKeyUp(KeyCode.Space)) {
			addingForceUp = false;
		}

		standingOnFloor = StandingOnFloor();
	}

	void FixedUpdate () {
		if (addingForceUp) {
			rigidBody.AddForce(Vector2.up * flyingForce);
		}
	}




	private bool StandingOnFloor() {
		RaycastHit2D hitLeft = Physics2D.Raycast(bottomLeft.position, -Vector2.up, 0.1f);
		RaycastHit2D hitRight = Physics2D.Raycast(bottomRight.position, -Vector2.up, 0.1f);

		return hitLeft.collider != null || hitRight.collider != null;
	}
}
