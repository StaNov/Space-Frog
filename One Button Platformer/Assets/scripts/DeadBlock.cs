using UnityEngine;
using System.Collections;

public class DeadBlock : MonoBehaviour {

	private PlayerController player;

	void Start() {
		player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Vector3 playerPosition = player.transform.position;
		Vector3 checkpointPosition = player.getLastVisitedCheckpoint().position;


		if (player.getLastVisitedCheckpoint() != null) {
			player.transform.position = new Vector3(checkpointPosition.x, checkpointPosition.y, playerPosition.z);
		} else {
			Application.LoadLevel(0);
		}
	}
}
