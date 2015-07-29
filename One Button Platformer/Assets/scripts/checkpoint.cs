using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {

	private bool visited = false;

	public Material visitedMaterial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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
