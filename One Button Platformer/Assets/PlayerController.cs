using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rigidBody;
	private Transform bottom;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		bottom = transform.FindChild("bottom");
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && StandingOnFloor()) {
			rigidBody.AddForce(new Vector2(5,5), ForceMode2D.Impulse);
		}
	}

	private bool StandingOnFloor() {
		RaycastHit2D hit = Physics2D.Raycast(bottom.position, -Vector2.up, 0.1f);
		return hit.collider != null;
	}
}
