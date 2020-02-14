﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public bool gameStart = false;
    public bool gameOver = false;

    //Testing, balancing still needed
    public float minRadius; //Recommend 3
    public float shrinkFactor; //Recommend 0.5
    public float waitTime; //Recommend 15 seconds
    MeshCollider meshCollider;

    public GameObject timer;
    public TimerController timerController;


    // Start is called before the first frame update
    void Start()
    {
        timerController = timer.GetComponent<TimerController>();
        meshCollider = GetComponent<MeshCollider>();
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
            timer.gameObject.SetActive(true); 

            //start shrinking ring, timer, animals spawns
            StartCoroutine(ShrinkRing());
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameStart = false;
            gameOver = true;
            StopCoroutine(ShrinkRing());
            //end animal spawns,animations, movement, timer
            
        }
    }

    IEnumerator ShrinkRing()
    {
        while (gameStart && !gameOver) // testing, use gameStart/!gameOver 
        {
            //Wait a specified amount of time before shrinking ring.
            yield return new WaitForSeconds(waitTime);

            // scaling all axis' evenly except y, which remains 0 
            while (transform.localScale.x > minRadius && !gameOver)
            {
                transform.localScale -= new Vector3(1, 0, 1) * Time.deltaTime * shrinkFactor;
                yield return null;
            }

        }
    }

}