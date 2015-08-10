using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {

	public GameObject gameOverText;

	private Transform finish;

	void Start() {
		finish = GameObject.FindWithTag("Finish").transform;
	}

	void OnTriggerEnter2D(Collider2D collider) {

		#if UNITY_EDITOR
		if (Application.loadedLevelName.StartsWith ("test")) {
			RestartLevel ();
			return;
		}
		#endif

		if (Application.loadedLevel < Application.levelCount - 1) {
			Application.LoadLevel(Application.loadedLevel + 1);
		} else {
			Instantiate(gameOverText, new Vector3(finish.position.x, finish.position.y + 3, finish.position.z), Quaternion.identity);
		}

	}

	void RestartLevel () {
		Application.LoadLevel(Application.loadedLevel);
	}
}
