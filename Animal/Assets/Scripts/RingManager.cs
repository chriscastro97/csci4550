using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public bool gameStart = false;
    public bool gameOver = false;

    //Testing, balancing still needed
    public float minRadius; //Recommend 3
    public float shrinkFactor; //Recommend 0.5
    public float waitTime; //Recommend 10 seconds
    

    //Timing variables
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    //Timer variables
    public GameObject timer;

    //Objective variables
    public GameObject objectiveText;

    //Refrences
    private SpawnManager spawnManager;
    MeshCollider meshCollider;

    // Start is called before the first frame update
    void Start()
    {
        //Get refs
        meshCollider = GetComponent<MeshCollider>();
        spawnManager = GetComponent<SpawnManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //start shrinking ring, timer, animals spawns
            gameStart = true;
            timer.gameObject.SetActive(true);
            StartCoroutine(ShrinkRing());

            //Hide objective text
            objectiveText.gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //end the game
            gameStart = false;
            gameOver = true;
            StopCoroutine(ShrinkRing());
            
            //Show the objectiveText which now holds the score
            //objectiveText.gameObject.SetActive(true);

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
