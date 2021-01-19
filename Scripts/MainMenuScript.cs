using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("XButton"))
        {
            SceneManager.LoadScene("LegendOfPK");
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

        if (Input.GetButtonDown("YButton"))
        {
            SceneManager.LoadScene("About_Page");
        }

    }
}
