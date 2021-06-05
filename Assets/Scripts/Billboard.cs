using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform target; //메인카메라
    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<PlayerMove>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        transform.forward = target.forward;
    }
}
