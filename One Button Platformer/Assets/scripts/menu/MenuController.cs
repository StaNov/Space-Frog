using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	
	}
}
