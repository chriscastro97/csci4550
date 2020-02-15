using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Input variables
    private float horizontalInput;
    private float verticalInput;

    //Speed and limiting varialbes
    public float speed = 10.0f;
    private float xRange = 20.0f;
    private float negZRange = -4.0f;
    private float posZRange = 20.0f;

    //Refrences
    public GameObject projectilePrefab;
    private Animator playerAnimator;
    public bool gameOver;
    public RingManager ringManager;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();

        //Refrence to SpawnManager script in the empty SpawnManager game object
        ringManager = GameObject.Find("Ring").GetComponent<RingManager>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Tracking game status
        gameOver = ringManager.gameOver;
        
        //Getting player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (!gameOver)
        {
            //Using player input
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        }
        

        //Limiting player movement
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < negZRange)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y, negZRange);
        }
        else if (transform.position.z > posZRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, posZRange);
        }

        //Player attack controls
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            //TODO fix fish throwing
        }

    }
}
