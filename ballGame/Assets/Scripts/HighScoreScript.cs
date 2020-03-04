using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public Text HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "YOUR CURRENT HIGHSCORE: " + PlayerPrefs.GetInt("HIGHSCORE", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
          HighScoreText.text = "YOUR CURRENT HIGHSCORE: " + PlayerPrefs.GetInt("HIGHSCORE", 0).ToString();
    }
}
