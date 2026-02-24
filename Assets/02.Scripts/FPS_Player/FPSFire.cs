using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 마우스 왼쪽버튼 눌렀을 때 총알 발사 하고 사운드 효과 
// 오디오 소스 오디오 클립  총알 오브젝트  발사위치  
public class FPSFire : MonoBehaviour
{
    public AudioSource source;
    public AudioClip fireClip;
    public GameObject bulletPrefab;
    public Transform FirePos;
    public Animation combatSG_Ani;
    private HandAni handAni;
    public ParticleSystem flashEffect; //muzzleflash 효과 총구 화염효과
    public ParticleSystem CartrigeEffect; // 탄환 탄피 떨어지는 효과
    void Start()
    {
        handAni = GetComponent<HandAni>();
    }
    void Update()
    {
          // 마우스 왼쪽버튼을 눌렀다면 ... 0:왼쪽 1:오른쪽 2: 마우스 휠버튼
        if(Input.GetMouseButtonDown(0) && handAni.isRunning ==false)
        {
            Fire();
            EffectControl(true);
        }
        else if(Input.GetMouseButtonUp(0)) //왼쪽마우스 버튼을 띠었다면
        {
            EffectControl(false);
        }

    }

    private void Fire() //개발자 직접 만든 메서드 발사소리 총구에서 총알이 발사 됨
    {
        source.PlayOneShot(fireClip, 1.0f);
        Instantiate(bulletPrefab, FirePos.position, FirePos.rotation);
        //동적할당( 무엇을? , 어디서 , 어떻게 회전 할 것인가)
        // 객체 생성 함수(what? , where , how rotation);
        combatSG_Ani.Play("fire");
    }
    void EffectControl(bool isPlay)
    {
        if(isPlay)  //==true 생략가능 
        {
            flashEffect.Play(); //파티클 이펙트 효과 재생
            CartrigeEffect.Play();

        }
        else
        {
            flashEffect.Stop();
            CartrigeEffect.Stop();
        }
        
    }
}
