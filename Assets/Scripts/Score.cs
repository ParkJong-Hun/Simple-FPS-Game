using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float score = 0;
    public static float time = 0f;
    PlayerMove player;
    Text text;
    // Update is called once per frame
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
        text = GetComponent<Text>();
    }
    void Update()
    {
        //체력이 0보다 크면
        if ( player.hp > 0)
        {
            //점수 시간 만큼 증가
            time += Time.deltaTime;
            score += Time.deltaTime;
            text.text = "점수 : " + (int)score;
        }
    }
}
