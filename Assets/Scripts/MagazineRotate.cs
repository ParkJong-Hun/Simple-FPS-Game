using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineRotate : MonoBehaviour
{
    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(transform.rotation.x, 360 * Time.deltaTime, transform.rotation.z);
    }
}
