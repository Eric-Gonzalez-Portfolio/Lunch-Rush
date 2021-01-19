using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitchSimple : MonoBehaviour {


	void Update () {
		if (Input.GetButtonDown("Submit"))
			SceneManager.LoadScene("Player_Select");
	}
}
