using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GranadeDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            //탄약 먹으면 탄창 30으로 초기화
            PlayerFire.g400 = 3;
            Text g400Text = GameObject.Find("Granade").GetComponent<Text>();
            g400Text.text = "남은 수류탄: " + PlayerFire.g400;
            Destroy(gameObject);
        }
    }
}
