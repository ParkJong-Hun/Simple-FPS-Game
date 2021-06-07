using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineDestroy : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip afterClip;
    public AudioClip afterClip2;
    MeshRenderer mesh;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mesh = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            //탄약 먹으면 탄창 30으로 초기화
            StopAllCoroutines();
            StartCoroutine(wait());
            PlayerFire.magazine = 30;
            Text magazineText = GameObject.Find("Magazine").GetComponent<Text>();
            magazineText.text = "남은 탄창: " + PlayerFire.magazine;
        }
    }

    IEnumerator wait()
    {
        mesh.enabled = false;
        audioSource.Play();
        print("1 실행");
        yield return new WaitForSeconds(0.4f);
        audioSource.Stop();
        audioSource.clip = afterClip;
        audioSource.Play();
        print("2 실행");
        yield return new WaitForSeconds(1.2f);
        audioSource.Stop();
        audioSource.clip = afterClip2;
        audioSource.Play();
        print("3 실행");
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
