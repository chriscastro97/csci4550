using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallsLeftScript : MonoBehaviour
{
    public static int ballsLeft = 8;

    Text ballsLeftText;
    // Start is called before the first frame update
    void Start()
    {
        ballsLeftText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ballsLeftText.text = "BALLS LEFT: " + ballsLeft;
    }
}
