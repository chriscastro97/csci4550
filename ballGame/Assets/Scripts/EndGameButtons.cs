using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndGameButtons : MonoBehaviour
{
    //The index number of the scene you are changing to
    public int levelNumber = 1;

     private double exitVideoLength;
    //The sound that is played on MouseOver
    public AudioClip buttonSound;
    public AudioClip click;
    public AudioClip clickReset;
     
    private AudioSource AudioSource;
  
    
    
    
    [SerializeField]
    private GameObject  player;
    
    [SerializeField]
    private GameObject  cam;
    
    [SerializeField]
    private AudioSource camSource;
    
    [SerializeField]
    private GameObject  balltext; 
    [SerializeField]
    private GameObject  scoretext; 
    [SerializeField]
    private GameObject  gameovertext;
    [SerializeField]
    private VideoPlayer exitVideoPlayer;
     [SerializeField]
    private AudioClip EndGameMusic;
	// Use this for initialization
	void Start ()
    {
        
       exitVideoLength = exitVideoPlayer.clip.length;
       camSource = cam.GetComponent<AudioSource>();
        AudioSource = player.GetComponent<AudioSource>();
        AudioSource.Stop();
        AudioSource.PlayOneShot(EndGameMusic);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("Detected Mouse");

        
        if (this.gameObject.tag == "ExitButton")
        {
            //Quits the application
            Debug.Log("exit pressed");
            AudioSource.Stop();
            
            balltext.SetActive(false);
            scoretext.SetActive(false);
            gameovertext.SetActive(false);
            exitVideoPlayer.Play();
            StartCoroutine(WaitAndQuit(exitVideoLength));
         
        }

        if (this.gameObject.tag == "ReturnHome")
        {     
            AudioSource.Stop();
            camSource.Stop();
            camSource.PlayOneShot(click);
            balltext.SetActive(false);
            scoretext.SetActive(false);
            SceneManager.LoadScene("MainMenu");
            
            BallsLeftScript.ballsLeft = 9; 
            ScoreScript.scoreValue = 0;
        }



        if (this.gameObject.tag == "ResetGame")
        {  
           
            AudioSource.Stop();
            camSource.Stop();
           camSource.PlayOneShot(clickReset);
            
            SceneManager.LoadScene("Game");
            BallsLeftScript.ballsLeft = 9; 
            ScoreScript.scoreValue = 0;
            
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

