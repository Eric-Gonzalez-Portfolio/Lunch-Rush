using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private bool isPaused = false;
	Object[] objects;

	public GameObject pause_text;

	void Start() {
		objects = FindObjectsOfType(typeof(GameObject));
	}

	void Update () {
		if (Input.GetButtonDown ("Start")) {
			if (isPaused) {
				foreach (GameObject obj in objects) {
					if (obj.GetComponent<PlayerPause> () != null) {
						obj.GetComponent<PlayerPause> ().Pause (false);
					}
				}

				Time.timeScale = 1;

				pause_text.GetComponent<UnityEngine.UI.Text> ().enabled = false;

				isPaused = false;
			} else {
				foreach (GameObject obj in objects) {
					if (obj.GetComponent<PlayerPause> () != null) {
						obj.GetComponent<PlayerPause> ().Pause (true);
					}
				}

				Time.timeScale = 0;

				pause_text.GetComponent<UnityEngine.UI.Text> ().enabled = true;

				isPaused = true;
			}
		}
	}
}
