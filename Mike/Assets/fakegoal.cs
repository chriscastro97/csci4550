using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class fakegoal : MonoBehaviour
{

    BoxCollider2D boxCollider;

    
    public GameObject textdisplay;
    public GameObject badtextdisplay;

    public AudioSource audio;
    public AudioClip clip1;

   


    private static bool secLife;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
        secLife = Player.secondlife;

        audio = GetComponent<AudioSource>();
        audio.clip = clip1;
        

    }


    // Update is called once per frame
    void Update()
    {


        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (secLife == false)
        {

            if (collision.gameObject.CompareTag("Player"))
            {

                textdisplay.SetActive(true);
                Player.secondlife = true;
                secLife = Player.secondlife;
                StartCoroutine(wait());

            } 

        }

        if (secLife == true)
        {
            badtextdisplay.SetActive(true);
            
        }
    }


    IEnumerator wait ()
    {
        
        if (secLife == true)
        {
            yield return new WaitForSeconds(5);
            textdisplay.SetActive(false);
        }

        if (secLife == false)
        {
            badtextdisplay.SetActive(true);
            audio.PlayOneShot(clip1);
            yield return new WaitForSeconds(5);

            SceneManager.LoadScene("Lose");

        }
    }


}
