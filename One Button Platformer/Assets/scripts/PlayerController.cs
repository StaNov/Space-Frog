using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float flyingForce = 5.0f;
	public int jumpForceX = 5;
	public int jumpForceY = 5;
	public float maxJumpHeight = 5.0f;

	private Vector2 jumpForce;

	private Rigidbody2D rigidBody;
	private Transform bottomLeft;
	private Transform bottomRight;

	private bool addingForceUp = false;
	private float beforeJumpY;
	private Transform lastVisitedCheckpoint;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		bottomLeft = transform.FindChild("bottomLeft");
		bottomRight = transform.FindChild("bottomRight");
		jumpForce = new Vector2(jumpForceX, jumpForceY);
	}

	void Update () {
		if (Input.GetKey(KeyCode.Space) && StandingOnFloor() && !addingForceUp) {
			Jump ();
		}

		if (addingForceUp && (Input.GetKeyUp(KeyCode.Space) || rigidBody.velocity.y <= 0)) {
			addingForceUp = false;
		}
	}

	void FixedUpdate () {
		if (addingForceUp) {
			rigidBody.AddForce(new Vector2(0, maxJumpHeight - (JumpHeight())) * flyingForce);

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

	// TODO přejmenovat metody na velké počáteční
	public Transform getLastVisitedCheckpoint() {
		return lastVisitedCheckpoint;
	}
	
	public void setLastVisitedCheckpoint(Transform checkpoint) {
		lastVisitedCheckpoint = checkpoint;
	}




	private void Jump() {
		beforeJumpY = transform.position.y;
		rigidBody.AddForce (jumpForce, ForceMode2D.Impulse);
		addingForceUp = true;
	}

	private void StopPlayer () {
		rigidBody.velocity = Vector2.zero;
	}

	private float JumpHeight() {
		return transform.position.y - beforeJumpY;
	}


	private bool StandingOnFloor() {
		RaycastHit2D hitLeft = Physics2D.Raycast(bottomLeft.position, Vector2.down, 0.01f);
		RaycastHit2D hitRight = Physics2D.Raycast(bottomRight.position, Vector2.down, 0.01f);

		return hitLeft.collider != null || hitRight.collider != null;
	}
}
