using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool gameStart = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //If colliding tag = player start the game
        //Run the game until onCollisionExit collision tag = player

    }

    // Update is called once per frame
    void Update()
    {
        //use the InvokeRepeating method to shrink the ring overtime
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameStart = true;
            Debug.Log("Timer starts, Animals start spawning");
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameOver = true;
            Debug.Log("Game Over, Stop timer, Stop animation, Stop spawning");
        }
        
    }
         
}
