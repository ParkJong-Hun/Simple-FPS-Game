using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200f; // 회전속도변수
    float mx = 0;
    float my = 0;

    // Update is called once per frame
    void Update()
    {
        //게임 상태가 '게임 중' 상태일 때만 조작할 수 있게 한다.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }
        // 마우스 입력을 받는다.
        float mouse_X = Input.GetAxis("Mouse X"); 
        float mouse_Y = Input.GetAxis("Mouse Y");
        //회전값 변수에 마우스 입력 값만큼 미리 누적을 시킨다.
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;
        //상하이동 회전변수(my)의 값을 -90~90도 사이로 제한한다.
        my = Mathf.Clamp(my, -90f, 90f);
        //회전방향으로 물체를 회전시킨다. 
        transform.eulerAngles = new Vector3(-my, mx, 0);

    /*    // 마우스 입력 값을 이용해 회전 방향을 잡는다. 
        Vector3 dir = new Vector3(-mouse_Y, mouse_X, 0);

        // 회전방향으로 물체를 회전시킨다.
        transform.eulerAngles += dir * rotSpeed * Time.deltaTime;

        //x축 회전(상화회전)값을 -90도 ~ 90도 사이로 제한한다.
        Vector3 rot = transform.eulerAngles;
        rot.x = Mathf.Clamp(rot.x, -90f, 90f);
        transform.eulerAngles = rot;
        */
    }
}
