using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject respawnText;
    public GameObject endGameReset;
    public GameObject endGameExit;
    public GameObject gameOverText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            ScoreScript.scoreValue += 100;
            if (BallsLeftScript.ballsLeft == 0)
            {
                ActiveEnd();
            }
            // if statment once ball enters at 0
        }
    }  
    
    public void ActiveEnd(){
                     respawnText.SetActive(false);
                     endGameExit.SetActive(true);
                     endGameReset.SetActive(true);
                     gameOverText.SetActive(true);
     }
}

  


