using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class fakegoal : MonoBehaviour
{

    BoxCollider2D boxCollider;

    
    public GameObject textdisplay;
    public GameObject badtextdisplay;
    public GameObject goal;

    public AudioSource audio;
    public AudioClip clip1;

   public  Player player;
   
   bool self = false;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
         

        player.GetComponent<Player>(); 
        
        bool self = false; 
        audio = GetComponent<AudioSource>();
        audio.clip = clip1; 
        

    }


    // Update is called once per frame
    void Update()
    {


        


    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        
        

            if (collision.gameObject.CompareTag("Player"))
            {
              

               StartCoroutine(waitDeath());
           
      
        


    }



    }

    IEnumerator waitDeath()
    {           
        boxCollider.enabled = false;

        yield return new WaitForSeconds(3);
      
      
        badtextdisplay.SetActive(true);
        audio.PlayOneShot(clip1);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Lose"); 
        

    }


}
