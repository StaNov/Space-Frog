using UnityEngine;
using System.Collections;

public class DeadBlock : MonoBehaviour {

	private PlayerController player;

	void Start() {
		player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Vector3 playerPosition = player.transform.position;

		if (player.GetLastVisitedCheckpoint() != null) {
			Vector3 checkpointPosition = player.GetLastVisitedCheckpoint().position;
			player.transform.position = new Vector3(checkpointPosition.x, checkpointPosition.y, playerPosition.z);
			player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		} else {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
