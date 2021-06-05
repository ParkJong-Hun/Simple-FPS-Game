using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // Camposition 오브젝트
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;//카메라의 위치를 Camposition 위치에 일치시킨다.    
    }
}
