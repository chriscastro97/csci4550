using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public bool gameOver;
    public bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        //Start with the radius here and a way to know when player steps inside
    }

    // Update is called once per frame
    void Update()
    {
        //Shrink the ring overtime
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameStart = true;
            //start timer, animals spawns
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameStart = false;
            gameOver = true;
            //end animal spawns,animations, movement, timer
        }
    }




}
