using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    Text text;
    int currentScore;
    int savedScore;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        currentScore = (int)Score.score;
        if(PlayerPrefs.GetInt("Best") != 0)
        {
            savedScore = PlayerPrefs.GetInt("Best");
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "현재점수: " + currentScore;
        if(savedScore < currentScore)
        {
            PlayerPrefs.SetInt("Best", currentScore);
        }
    }
}
