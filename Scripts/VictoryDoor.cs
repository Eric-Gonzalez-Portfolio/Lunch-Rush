using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class VictoryDoor : MonoBehaviour {

	public GameObject victory_obj;

	private bool prev_victory = false;

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player" && !prev_victory) {
			victory_obj.GetComponent<UnityEngine.UI.Text> ().enabled = true;
			int player_no = coll.gameObject.transform.parent.GetComponent<PlayerControl> ().player_no;

			victory_obj.GetComponent<UnityEngine.UI.Text> ().text = "Player " + player_no + " Victory!\r\nPress start...";

			prev_victory = true;
		}
	}

	void Update() {
		if (prev_victory && Time.timeScale == 0)
			SceneManager.LoadScene ("Main_Menu");
	}
}
