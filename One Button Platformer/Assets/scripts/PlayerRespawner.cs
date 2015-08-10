using UnityEngine;
using System.Collections;

public class PlayerRespawner : MonoBehaviour {
	
	private static int DEATH_BLINKS = 5;
	private static float BLINK_DURATION = .4f;

	private PlayerController player;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rigidBody;

	private bool playerIsAlive = true;


	void Start() {
		player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		spriteRenderer = player.GetComponent<SpriteRenderer>();
		rigidBody = player.GetComponent<Rigidbody2D>();
	}

	public void OnDeath() {
		if (playerIsAlive) {
			playerIsAlive = false;
			StartCoroutine(DeathCoroutine());
		}
	}
	
	private IEnumerator DeathCoroutine() {
		rigidBody.isKinematic = true;
		for (int i = 0; i < DEATH_BLINKS*2; i++) {
			yield return new WaitForSeconds(BLINK_DURATION/2);
			spriteRenderer.enabled = ! spriteRenderer.enabled;
		}
		Respawn();
		rigidBody.isKinematic = false;
		playerIsAlive = true;
	}
	
	private void Respawn() {
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
