using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Best") > 0)
        {
            text.text = "최고 점수: " + PlayerPrefs.GetInt("Best");
        }
    }
}
