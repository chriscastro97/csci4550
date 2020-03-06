using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private VideoPlayer exitVideoPlayer;

    
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject CamTwoBackground;
    [SerializeField] private   GameObject PointScoreText;
    [SerializeField] private   GameObject ControlText;

   
   [SerializeField] private AudioSource playerAudioSource;
   private double exitVideoLength;
    // Start is called before the first frame update
    void Start()
    {
         exitVideoLength = exitVideoPlayer.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            CamTwoBackground.SetActive(false);
            PointScoreText.SetActive(false);
            ControlText.SetActive(false);
            playerAudioSource.Stop();
            Camera.SetActive(true);
            exitVideoPlayer.Play();
            StartCoroutine(WaitAndQuit(exitVideoLength));
        }
        
    }
    
    private IEnumerator WaitAndQuit(double value) {
        yield return new WaitForSeconds((float) value);
        Application.Quit();
    }
}

