using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCreator : MonoBehaviour
{
    public GameObject prefab;
    float time = 4f;
    float currentMaxTime = 4f;
    // Update is called once per frame
    void Update()
    {
        //시간 내리기
        time -= Time.deltaTime;
        //시간이 0 이하로 가면?
        if(time <= 0)
        {
            //-90~90사이의 좌표에서 좀비 생성
            System.Random rand = new System.Random();
            float x, y, z;
            x = rand.Next(-90, 90);
            z = rand.Next(-90, 90);
            y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z));
            GameObject Enemy = Instantiate(prefab, new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
            EnemyFSM enemyState = Enemy.GetComponent<EnemyFSM>();
            Transform scale = Enemy.GetComponentInChildren<Transform>();
            if (Score.time > 60)
            {
                scale.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                enemyState.maxHp = 20;
                enemyState.hp = enemyState.maxHp;
                enemyState.moveSpeed = 7;
            } else if(Score.time > 120)
            {
                scale.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                enemyState.maxHp = 25;
                enemyState.hp = enemyState.maxHp;
                enemyState.moveSpeed = 9;
            } else if(Score.time > 180)
            {
                scale.transform.localScale = new Vector3(2f, 2f, 2f);
                enemyState.maxHp = 30;
                enemyState.hp = enemyState.maxHp;
                enemyState.moveSpeed = 11;
            } else if(Score.time > 240)
            {
                scale.transform.localScale = new Vector3(4f, 2.4f, 4f);
                enemyState.maxHp = 50;
                enemyState.hp = enemyState.maxHp;
                enemyState.moveSpeed = 13;
            }
            time = currentMaxTime;
        }
    }
}
