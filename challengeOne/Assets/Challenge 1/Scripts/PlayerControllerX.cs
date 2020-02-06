using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

 //   public GameObject player;

   // private Rigidbody playerRb;
    
 

    // Start is called before the first frame update
    void Start()
    {

      //  playerRb = player.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        if(verticalInput >0)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);

        }
        if (verticalInput < 0)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * rotationSpeed);
            
        }


        // tilt the plane up/down based on up/down arrow keys
        //transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}