using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class GameManagerMainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
 
    [SerializeField]  private VideoPlayer exitVideoPlayer;
    private double exitVideoLength;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
        exitVideoLength = exitVideoPlayer.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown("escape"))
                {
                    audioSource.Stop();
                    exitVideoPlayer.Play();
                    StartCoroutine(WaitAndQuit(exitVideoLength));
                }
    }
    
    private IEnumerator WaitAndQuit(double value) {
        yield return new WaitForSeconds((float) value);
        Application.Quit();
    }
}
