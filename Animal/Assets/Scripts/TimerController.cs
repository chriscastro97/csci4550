using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 0f;
    [SerializeField] Text countdownText;
    private RingManager ringManager;

    // Start is called before the first frame update
    void Start()
    {
        //Reference ringManager script
        ringManager = GameObject.Find("Ring").GetComponent<RingManager>();

        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ringManager.gameOver)
        currentTime += 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString();

    }

}
