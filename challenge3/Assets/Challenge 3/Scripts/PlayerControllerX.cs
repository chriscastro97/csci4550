using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    private bool validY =true;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireWork;


    AudioSource backgroundaudioSource;
   

    AudioSource audioSource;
    public AudioClip boom;
    public AudioClip blip;
    public AudioClip boing;
    

    // Start is called before the first frame update
    void Start()
    {

        backgroundaudioSource = Camera.main.GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>(); 

        Physics.gravity *= gravityModifier;

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed, the game is not over and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && validY)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        if (playerRb.transform.position.y >= 14)
            validY = false;
        else
            validY = true;

        //Fix player being too low if the game is not over
        if(playerRb.transform.position.y <= 2 && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
            audioSource.PlayOneShot(boing);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            backgroundaudioSource.Stop();
            explosionParticle.Play();
            audioSource.PlayOneShot(boom);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        if (other.gameObject.CompareTag("Money"))
        {
            explosionParticle.Stop();
            audioSource.PlayOneShot(blip);
            fireWork.Play();
            Debug.Log("hit money!");
            Destroy(other.gameObject);
        }
    }

}
