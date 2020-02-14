using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public bool gameStart;
    public bool gameOver;

    //Testing, balancing still needed
    public float minRadius; //Recommend 3
    public float shrinkFactor; //Recommend 0.5
    public float waitTime; //Recommend 30 seconds

    // Start is called before the first frame update
    void Start()
    {
        //only here for testing, triggered onCollisionEnter with player
        StartCoroutine(ShrinkRing());
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")//not working
        {
            gameStart = true;

            //start shrinking ring, timer, animals spawns
            StartCoroutine(ShrinkRing());
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//not working
        {
            gameStart = false;
            gameOver = true;

            StopCoroutine(ShrinkRing());
            //end animal spawns,animations, movement, timer
            
        }
    }

    IEnumerator ShrinkRing()
    {
        while (true) // testing, use gameStart/!gameOver 
        {
            //Wait a specified amount of time before shrinking ring.
            yield return new WaitForSeconds(waitTime);

            // scaling all axis' evenly except y, which remains 0 
            while (transform.localScale.x > minRadius)
            {
                transform.localScale -= new Vector3(1, 0, 1) * Time.deltaTime * shrinkFactor;
                yield return null;
            }

        }
    }

}
