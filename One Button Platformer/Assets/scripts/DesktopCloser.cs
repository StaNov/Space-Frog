using UnityEngine;
using System.Collections;

public class DesktopCloser : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
