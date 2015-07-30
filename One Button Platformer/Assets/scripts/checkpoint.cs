using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	private bool visited = false;

	public Material visitedMaterial;

	void OnTriggerEnter2D(Collider2D collider) {
		if (visited) {
			return;
		}

		PlayerController controller = collider.GetComponent<PlayerController>();
		controller.setLastVisitedCheckpoint(transform);
		updateGraphics();

		visited = true;
	}


	private void updateGraphics() {
		GetComponent<MeshRenderer>().material = visitedMaterial;
	}
}
