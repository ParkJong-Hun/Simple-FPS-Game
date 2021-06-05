using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    public int attackPower = 10; // 수류탄 데미지
    public float explosionRadius = 5f; // 폭발 효과 반경
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius, 1 << 10);

        for (int i = 0; i < cols.Length; i++)
        {
            cols[i].GetComponent<EnemyFSM>().HitEnemy(attackPower);
        }

        GameObject eff = Instantiate(bombEffect); // 폭발 프리팹 생성
        eff.transform.position = transform.position;  
        Destroy(gameObject); // Bomb 오브젝트 파괴
    }
}
