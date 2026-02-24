using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 1.Image 
public class ZombieDamage : MonoBehaviour
{
    public Image hpBar;
    public Text hpText;
    public int hp = 0;
    public int hpInit = 100;
    public bool isDie = false;
    public Animator animator;
    public AudioSource source;
    public AudioClip deathClip;
    public BoxCollider boxCollider;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        hp = hpInit;   //100으로 초기화
        hpBar.color = Color.green; //색상초기화
        animator = GetComponent<Animator>(); //자기 자신오브젝트에 애니메이터 대입
       
    }
    private void OnCollisionEnter(Collision col)
    {
        #region 태그가 BULLET 인 경우의 로직
        if (col.gameObject.tag =="BULLET") //태그 검사
        {
            Destroy(col.gameObject); //총알사라짐
            hp -= 25;   //hp = hp - 25;
            hp = Mathf.Clamp(hp, 0, 100);
            // hp = 수학클래스.Clamp(what?, 최저값, 최고값)
            //                 제한함수
            hpBar.fillAmount = (float)hp / (float)hpInit;
            HpBarColor();
            animator.SetTrigger("Hit");
            hpText.text = $"HpBar : {hp.ToString()}";
            if(hp <=0)
            {
                ZombieDie();
            }
        }
        #endregion

        if(col.gameObject.tag =="Player")
        {
            rb.isKinematic = true; //물리작용이 없음 
            //순간적으로 물리가 발생하지 않게 할때
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag =="Player")
        {
            rb.isKinematic= false; //물리작용이 있음
            // 다시 물리가 발생하게 
        }

    }

    private void ZombieDie()
    {
        animator.SetTrigger("Die"); //사망 애니메이션 재생
        isDie = true;
        source.PlayOneShot(deathClip, 1.0f);
        //1. 시체가 되어서도 따라온다.
        //2. 시체가 되었는 데 해당 캐릭터 총알을 쏘면 사망 애니메이션을 반복한다.
        GetComponent<CapsuleCollider>().enabled = false;
        //캡슐콜라이더를 비활성화 시킨다.
    }

    private void HpBarColor()
    {
        if (hpBar.fillAmount <= 0.3f)
            hpBar.color = Color.red;
        else if (hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;
    }
    public void ColliderEnable()
    {
        boxCollider.enabled = true;
    }
    public void ColliderDisable()
    {
        boxCollider.enabled = false;
    }
}
