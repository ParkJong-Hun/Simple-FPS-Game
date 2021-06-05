using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    CharacterController cc;
    float gravity = -20f;
    float yVelocity = 0;
    public float jumpPower = 10f;
    public bool isJumping = false;
    public int hp = 20;
    int maxHp = 20;
    public Slider hpSlider;
    public GameObject hitEffect;
    Animator anim; //애니메이터 변수

    // Update is called once per frame
    private void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        //게임 상태가 '게임 중' 상태일 때만 조작할 수 있게 한다.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized; //이동방향을 설정함
        anim.SetFloat("MoveMotion", dir.magnitude);

        //특정한 이동 벡터를 Transform 컴포넌트가 붙어 있는 게임 오브젝트를 기준으로
        //상대 방향 벡터로 변환해주는 TransformDirection()가 있다.
        dir = Camera.main.transform.TransformDirection(dir);
        if (cc.collisionFlags == CollisionFlags.Below)//지면에 닿아 있는지..
        {
            if (isJumping) // 점프 중이라면
            {
                isJumping = false; // 점프 전 상태로 초기화
            }
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
        }

        //캐릭터 수직 속도에 중력 값을 적용한다.
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
  //      print(yVelocity);
        // 이동 속도에 맞춰 이동한다
        cc.Move(dir * moveSpeed * Time.deltaTime);
        //    transform.position += dir * moveSpeed * Time.deltaTime;
        
        //현재 플레이어 hp(%)를 hp슬라이더의 value에 반영한다.
        hpSlider.value = (float)hp / (float)maxHp;
    }
    public void DamageAction(int damage)
    {
        hp -= damage;
        if (hp > 0)
        {
            StartCoroutine(PlayerHitEffect());
                
        }
    }
    IEnumerator PlayerHitEffect()
    {
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hitEffect.SetActive(false);
    }
}
