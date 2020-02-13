using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public bool gameOver;
    public bool gameStart;
    public GameObject ring;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Shrink the ring overtime
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShrinkRing();
            Debug.Log("Shrink the ring");
        }
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

    private void ShrinkRing()
    {
        //Get the current radius of the ring
        float newScaleX = ring.transform.localScale.x;
        float newScaleZ = ring.transform.localScale.z;

        //Change the radius values
        newScaleX = 10;
        newScaleZ = 10;

        //Set the new radius values
        ring.transform.localScale.Set(newScaleX, ring.transform.localScale.y, newScaleZ);

        //Not working

    }

}
