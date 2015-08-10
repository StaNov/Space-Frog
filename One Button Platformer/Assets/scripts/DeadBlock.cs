using UnityEngine;
using System.Collections;

public class DeadBlock : MonoBehaviour {
	
	private PlayerController player;
	private PlayerRespawner playerRespawner;

	void Start() {
		player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		playerRespawner = player.GetComponent<PlayerRespawner>();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		playerRespawner.OnDeath();
	}
}
