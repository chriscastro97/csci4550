using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject ScoreBoxCamera;
    private GameObject MainCamera;
    private Rigidbody playerRb;
    
    public float speed;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip  respawnClip;
    [SerializeField] private AudioClip  noSpawnClip;

    
    public bool hasPowerup = false;
    private float powerUpStrength = 15;
    private float powerUpTime = 5;

    public GameObject scoreStar1;
    public GameObject scoreStar2;
    public GameObject scoreStar3;
    public GameObject scoreStar4;
    public GameObject scoreStar5;
    public GameObject scoreStar6;
    public GameObject scoreStar7;
    public GameObject scoreStar8;
    public GameObject scoreStar9;


    private bool hasEntered1;
    private bool hasEntered2;
    private bool hasEntered3;
    private bool hasEntered4;
    private bool hasEntered5;
    private bool hasEntered6;
    private bool hasEntered7;
    private bool hasEntered8;
    private bool hasEntered9;

    [SerializeField] private ParticleSystem ScoreBoxParticle;
    [SerializeField] private AudioSource scoreBoxAudio;
    [SerializeField] private AudioClip boom;
    [SerializeField] private AudioClip sameHole;


    public GameObject respawnPoint;


    

    public bool respawn;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        MainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
         respawn = false;
          if (Input.GetKeyDown("space"))
                  {
                      respawn = true;
                      Respawn(respawn);
                    
                  }
    }

    void FixedUpdate()
    {  
       
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        playerRb.AddForce(movement * speed);

    }

    void Respawn(bool respawnFlag)
    {
        if (BallsLeftScript.ballsLeft > 0)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            playerRb.velocity = new Vector3(0, 0, 0);
            playerRb.AddForce(movement * 0);
            playerRb.transform.position = respawnPoint.transform.position;
            BallsLeftScript.ballsLeft -= 1;
            AudioSource.PlayOneShot(respawnClip);
        }
        else
        {
            AudioSource.PlayOneShot(noSpawnClip);
        }
        {
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Powerup1"))
        {
           

            
                scoreBoxAudio.PlayOneShot(boom);
                 ScoreBoxParticle.Play();
                Destroy(other.gameObject);
                hasPowerup = true;
            

                scoreStar1.gameObject.SetActive(true);
            
          
        }

        if (other.CompareTag("Powerup2"))
        {


            scoreBoxAudio.PlayOneShot(boom);
            
            ScoreBoxParticle.Play();
                Destroy(other.gameObject);
                hasPowerup = true;


                scoreStar2.gameObject.SetActive(true);
            
        }

        if (other.CompareTag("Powerup3"))
        {

            scoreBoxAudio.PlayOneShot(boom);
            ScoreBoxParticle.Play();
            Destroy(other.gameObject);
            hasPowerup = true;
           scoreStar3.gameObject.SetActive(true);
            
        }

        if (other.CompareTag("Powerup4"))
        {

                scoreBoxAudio.PlayOneShot(boom);

                ScoreBoxParticle.Play();
                Destroy(other.gameObject);
                hasPowerup = true;

                scoreStar4.gameObject.SetActive(true);
            
        }

        if (other.CompareTag("Powerup5"))
        {

            scoreBoxAudio.PlayOneShot(boom);

            ScoreBoxParticle.Play();
                Destroy(other.gameObject);
                hasPowerup = true;

               scoreStar5.gameObject.SetActive(true);
          
        }

        if (other.CompareTag("Powerup6"))
        {

            scoreBoxAudio.PlayOneShot(boom);

            ScoreBoxParticle.Play();
                Destroy(other.gameObject);
                hasPowerup = true;

                scoreStar6.gameObject.SetActive(true);
            
        }

        if (other.CompareTag("Powerup7"))
        {

            scoreBoxAudio.PlayOneShot(boom);


            ScoreBoxParticle.Play();
                Destroy(other.gameObject);
                hasPowerup = true;

                scoreStar7.gameObject.SetActive(true);
           
        }

        if (other.CompareTag("Powerup8"))
        {

            scoreBoxAudio.PlayOneShot(boom);


            ScoreBoxParticle.Play();
                Destroy(other.gameObject);
                hasPowerup = true;
                scoreStar8.gameObject.SetActive(true);
           
        }

        if (other.CompareTag("Powerup9"))
        {

            scoreBoxAudio.PlayOneShot(boom);


            ScoreBoxParticle.Play();
                Destroy(other.gameObject);
                hasPowerup = true;
                scoreStar9.gameObject.SetActive(true);
           


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator WaitForParticle(float time)
    {
        yield return new WaitForSeconds(time);



    }


    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerUpTime);
        hasPowerup = false;

        StartCoroutine(PowerupCountdownRoutine());

        scoreStar1.gameObject.SetActive(false);
        scoreStar2.gameObject.SetActive(false);
        scoreStar3.gameObject.SetActive(false);
        scoreStar4.gameObject.SetActive(false);
        scoreStar5.gameObject.SetActive(false);
        scoreStar6.gameObject.SetActive(false);
        scoreStar7.gameObject.SetActive(false);
        scoreStar8.gameObject.SetActive(false);
        scoreStar9.gameObject.SetActive(false);
    }
}