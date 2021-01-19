using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoToAbout()
    {
        SceneManager.LoadScene("About_Page");
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene("Level_tut");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
