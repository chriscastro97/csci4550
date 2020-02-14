using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTextController : MonoBehaviour
{
    //Refrences
    private string objectiveText;
    [SerializeField] Text objectiveTextField;
    private RingManager ringManager;

    // Start is called before the first frame update
    void Start()
    {
        //Get ringManager
        ringManager = GameObject.Find("Ring").GetComponent<RingManager>();

        //Set the objective text
        objectiveText = "Step into the Ring to begin the game.";
        objectiveTextField.text = objectiveText;

                
    }

    // Update is called once per frame
    void Update()
    {
         

    }
}
