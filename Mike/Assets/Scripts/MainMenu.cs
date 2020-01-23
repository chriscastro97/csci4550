using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loads first scene
    public void PlayGame()
    {
        SceneManager.LoadScene("RPG");
    }

    public void Title()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        // Exit the application if the user presses the "escape" key
        // Does not work when playing from inside the Unity editor

        Debug.Log("QUIT");
        Application.Quit();      
    }

}
