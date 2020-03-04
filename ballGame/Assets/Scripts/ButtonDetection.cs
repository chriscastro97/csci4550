using UnityEngine;
using System.Collections;

public class ButtonDetection : MonoBehaviour {

    //The index number of the scene you are changing to
    public int levelNumber = 1;

    public GameObject MainMenu;

    public GameObject MainMenuCircles;

    private HighScoreScript highscore;
    public GameObject OptionBackground;
    public GameObject HighScoreText;

    public GameObject ControlText;

    public GameObject goaltext;
    //The sound that is played on MouseOver
    public AudioClip buttonSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("Detected Mouse");

        //Check which button that has been detected and preform indicated action
        if (this.gameObject.tag == "PlayButton")
        {
            //Load the scene you have chosen before
            Application.LoadLevel(levelNumber);
        }
        if (this.gameObject.tag == "OptionsButton")
        {
             Debug.Log("Clicked option");
            MainMenu.SetActive(false);
            MainMenuCircles.SetActive(false);
            OptionBackground.SetActive(true);
            goaltext.SetActive(true);
            HighScoreText.SetActive(true);
            ControlText.SetActive(true);
        }
        if (this.gameObject.tag == "ExitButton")
        {
            //Quits the application
            Debug.Log("exit pressed");
            Application.Quit();
        }
        if (this.gameObject.tag == "Return")
        {
            Debug.Log("You need to Tag this button!!");
            MainMenu.SetActive(true);
            MainMenuCircles.SetActive(true);
            OptionBackground.SetActive(false);
            goaltext.SetActive(false);
            HighScoreText.SetActive(false);
            ControlText.SetActive(false);
            
        }

        if (this.gameObject.tag == "Reset")
        {
            PlayerPrefs.DeleteKey("HIGHSCORE");
            PlayerPrefs.SetInt("HIGHSCORE", 0);
        
        }

    }
    
    void OnMouseEnter()
    {
        //Does this object have a sound?
        if (buttonSound != null)
        {
            //Play this sound, at this position, at this volume
            AudioSource.PlayClipAtPoint(buttonSound, this.transform.position, .2f);

        }

    }
}
