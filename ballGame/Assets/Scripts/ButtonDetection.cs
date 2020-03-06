using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.UIElements;

public class ButtonDetection : MonoBehaviour {

    //The index number of the scene you are changing to
    public int levelNumber = 1;

    public GameObject MainMenu;

    public GameObject MainMenuCircles;


    [SerializeField]
    private VideoPlayer exitVideoPlayer;

  
    
    private double exitVideoLength;
     

    private HighScoreScript highscore;
    public GameObject OptionBackground;
    public GameObject HighScoreText;

    public GameObject ControlText;

    public GameObject goaltext;
    //The sound that is played on MouseOver
    public AudioClip buttonSound;

    [SerializeField]
    private AudioClip ButtonClick;
    
    [SerializeField]
    private AudioClip ButtonRest;
    private AudioSource audioSource;
	// Use this for initialization
	void Start ()
    {
       audioSource = Camera.main.GetComponent<AudioSource>();
        exitVideoLength = exitVideoPlayer.clip.length;
      
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
            audioSource.PlayOneShot(ButtonClick);
            Application.LoadLevel(levelNumber);
        }
        if (this.gameObject.tag == "OptionsButton")
        {
             Debug.Log("Clicked option");
             audioSource.PlayOneShot(ButtonClick);
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
            audioSource.Stop();
            exitVideoPlayer.Play();
            StartCoroutine(WaitAndQuit(exitVideoLength));
            Debug.Log("exit pressed");
            
        }
        if (this.gameObject.tag == "Return")
        {
            Debug.Log("You need to Tag this button!!");
         
            audioSource.PlayOneShot(ButtonClick);
            MainMenu.SetActive(true);
            MainMenuCircles.SetActive(true);
            OptionBackground.SetActive(false);
            goaltext.SetActive(false);
            HighScoreText.SetActive(false);
            ControlText.SetActive(false);
            
        }

        if (this.gameObject.tag == "Reset")
        {
            if (PlayerPrefs.GetInt("HIGHSCORE", 0) > 0)
            {
                audioSource.PlayOneShot(ButtonRest);
            }
            PlayerPrefs.DeleteKey("HIGHSCORE");
            PlayerPrefs.SetInt("HIGHSCORE", 0);
        
        }

    }
    
    private IEnumerator WaitAndQuit(double value) {
        yield return new WaitForSeconds((float) value);
        Application.Quit();
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
