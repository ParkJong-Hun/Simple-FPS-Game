using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeCreator : MonoBehaviour
{
    public GameObject prefab;
    float time = 30f;
    // Update is called once per frame
    void Update()
    {
        //시간 내리기
        time -= Time.deltaTime;
        //시간이 0 이하로 가면?
        if (time <= 0)
        {
            //-90~90사이의 좌표에서 좀비 생성
            System.Random rand = new System.Random();
            float x, y, z;
            x = rand.Next(-90, 90);
            z = rand.Next(-90, 90);
            y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z));
            GameObject g400 = Instantiate(prefab, new Vector3(x, y + 0.5f, z), new Quaternion(0, 0, 0, 0));
            time = 30f;
        }
    }
}
