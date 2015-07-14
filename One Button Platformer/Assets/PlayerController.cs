using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int flyingForce = 5;
	public int jumpForceX = 5;
	public int jumpForceY = 5;

	private Vector2 jumpForce;

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
		jumpForce = new Vector2(jumpForceX, jumpForceY);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && StandingOnFloor()) {
			rigidBody.AddForce(jumpForce, ForceMode2D.Impulse);
			addingForceUp = true;
		}

		if (Input.GetKeyUp(KeyCode.Space) || rigidBody.velocity.y < 2) {
			addingForceUp = false;
		}

		standingOnFloor = StandingOnFloor();
	}

	void FixedUpdate () {
		// TODO ubírat sílu v závislosti na svislé rychlosti - úplně nahoře - nepřidávat vůbec
		if (addingForceUp) {
			rigidBody.AddForce(Vector2.up * flyingForce);

			if (rigidBody.velocity.x < 1) {
				rigidBody.AddForce(Vector2.right * 10);
			}
		}
	}




	private bool StandingOnFloor() {
		RaycastHit2D hitLeft = Physics2D.Raycast(bottomLeft.position, -Vector2.up, 0.1f);
		RaycastHit2D hitRight = Physics2D.Raycast(bottomRight.position, -Vector2.up, 0.1f);

		return hitLeft.collider != null || hitRight.collider != null;
	}
}
