using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float flyingForce = 5.0f;
	public int jumpForceX = 5;
	public int jumpForceY = 5;

	private Vector2 jumpForce;

	private Rigidbody2D rigidBody;
	private Transform bottomLeft;
	private Transform bottomRight;
	private Collider2D collider;

	private bool addingForceUp = false;

	// for debugging reasons
	private bool standingOnFloor;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		bottomLeft = transform.FindChild("bottomLeft");
		bottomRight = transform.FindChild("bottomRight");
		jumpForce = new Vector2(jumpForceX, jumpForceY);
		collider = GetComponent<Collider2D>();
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
			rigidBody.AddForce(new Vector2(0, rigidBody.velocity.y) * flyingForce);

			if (rigidBody.velocity.x < 1) {
				rigidBody.AddForce(Vector2.right * 10);
			}
		}
	}

	void OnCollisionEnter2D () {
		if (StandingOnFloor()) {
			StopPlayer ();
		}
	}

	void StopPlayer () {
		rigidBody.velocity = Vector2.zero;
	}



	private bool StandingOnFloor() {
		RaycastHit2D hitLeft = Physics2D.Raycast(bottomLeft.position, Vector2.down, 0.01f);
		RaycastHit2D hitRight = Physics2D.Raycast(bottomRight.position, Vector2.down, 0.01f);

		return hitLeft.collider != null || hitRight.collider != null;
	}
}
