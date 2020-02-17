using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTextController : MonoBehaviour
{
    //Refrences
    private string objectiveTextString;
    [SerializeField] Text objectiveText;
    private RingManager ringManager;
    private TimerController timerController;
    public GameObject endText;

    // Start is called before the first frame update
    void Start()
    {
        //Get ringManager
            ringManager = GameObject.Find("Ring").GetComponent<RingManager>();
        //timerController = GameObject.Find("Timer").GetComponent<TimerController>();

        //Set the objective text
        objectiveTextString = "Step into the Ring to begin the game.";
        objectiveText.text = objectiveTextString;

                
    }

    // Update is called once per frame
    void Update()
    {

        if (ringManager.gameOver)
        {
            //Not working
            //Change the objective text to the score when the game starts
            endText.gameObject.SetActive(true);
        }

    }
}
