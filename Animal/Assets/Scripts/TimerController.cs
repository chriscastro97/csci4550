using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    //Timer Variables
    private float currentTime = 0f;
    private float startingTime = 0f;
    
    //Refrences
    [SerializeField] Text countdownText;
    private RingManager ringManager;

    // Start is called before the first frame update
    void Start()
    {
        //Reference ringManager script
        ringManager = GameObject.Find("Ring").GetComponent<RingManager>();

        //Start the timer at 0
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {

        //If the game is running, start the timer.
        if(ringManager.gameStart && !ringManager.gameOver)
        {
            currentTime += 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString();
        }
        

    }

}
