﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Main_Menu");
        }

    }
}
