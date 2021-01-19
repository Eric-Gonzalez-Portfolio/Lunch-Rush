using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class character_select : MonoBehaviour {

    Image p1;
    Image p2;
    Text p1_text;
    Text p2_text;
    Text start_prompt;
    bool p1_ready = false;
    bool p2_ready = false;

    // Use this for initialization
    void Start () {
        p1 = GameObject.Find("p1_image").GetComponent<Image>();
        p2 = GameObject.Find("p2_image").GetComponent<Image>();
        p1_text = GameObject.Find("p1_text").GetComponent<Text>();
        p2_text = GameObject.Find("p2_text").GetComponent<Text>();
        start_prompt = GameObject.Find("start_prompt").GetComponent<Text>();
        p1_text.text = "Press \"A\" to Join";
        p2_text.text = "Press \"A\" to Join";
        start_prompt.text = "";
        //get UI elements
    }
	
	void Update()
    {
        if (Input.GetButtonDown("P1 Jump")) {
            p1_ready = true;
            p1_text.text = "Player 1 Ready!";
        }
        else if (Input.GetButtonDown("P1 Back"))
        {
			Debug.Log ("P1 pressed back");
            if (p1_ready) {
                p1_ready = false;
                p1_text.text = "Press \"A\" to Join";
            }
            else SceneManager.LoadScene("Main_Menu");
            //exit to main menu
        }

        if (Input.GetButtonDown("P2 Jump")) {
            p2_ready = true;
            p2_text.text = "Player 2 Ready!";
        }
        else if (Input.GetButtonDown("P2 Back"))
        {
            if (p2_ready) {
                p2_ready = false;
                p2_text.text = "Press \"A\" to Join";
            }
            else SceneManager.LoadScene("Main_Menu");
            //exit to main menu
        }


        if (p1_ready && p2_ready) {
            start_prompt.text = "Press Start to Begin";
        }
        else
        {
            start_prompt.text = "";
        }
            //output start prompt if both players ready

        if (!p1_ready)
            p1.color = new Color(0.1f,0.1f,0.1f,1);
        if (p1_ready)
            p1.color = new Color(1, 1, 1, 1);
        if (!p2_ready)
            p2.color = new Color(0.1f, 0.1f, 0.1f, 1);
        if (p2_ready)
            p2.color = new Color(1, 1, 1, 1);
        //darken the character if they are not ready

        if ((Input.GetButton("P1 Start") || Input.GetButton("P2 Start")) && p1_ready && p2_ready)
            SceneManager.LoadScene("Level1");
    }

}
