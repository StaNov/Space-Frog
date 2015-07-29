using UnityEngine;
using System.Collections;

public class DeadBlock : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		Application.LoadLevel(0);
	}
}
