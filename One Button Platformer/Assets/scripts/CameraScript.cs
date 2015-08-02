using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float rightOffset;
	public float cameraSpeed = 10;
	
	private Transform player;


	void Start () {
		player = GameObject.FindWithTag("Player").transform;
		transform.position = TargetPosition();
	}

	void Update () {
		Vector3 targetPosition = TargetPosition();

		if (Vector3.Distance(transform.position, targetPosition) < 0.01) {
			transform.position = targetPosition;
		} else {
			transform.position = Vector3.Lerp (transform.position, targetPosition, cameraSpeed / 1000);
		}
	}

	private Vector3 TargetPosition() {
		return player.position + new Vector3(rightOffset,0,-1);
	}
}
