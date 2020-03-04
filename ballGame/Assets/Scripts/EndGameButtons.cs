using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButtons : MonoBehaviour
{
    //The index number of the scene you are changing to
    public int levelNumber = 1;

    
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

        
        if (this.gameObject.tag == "ExitButton")
        {
            //Quits the application
            Debug.Log("exit pressed");
            Application.Quit();
        }
      
           
        

        if (this.gameObject.tag == "Reset")
        {
            SceneManager.LoadScene("Game");
            BallsLeftScript.ballsLeft = 9; 
            ScoreScript.scoreValue = 0;
            
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

