using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform player;
	public float rightOffset;

	void Update () {
		Vector3 targetPosition = player.position + new Vector3(rightOffset,0,-1);

		if (Vector3.Distance(transform.position, targetPosition) < 0.01) {
			transform.position = targetPosition;
		} else {
			transform.position = Vector3.Lerp (transform.position, targetPosition, 0.01f);
		}
	}
}
