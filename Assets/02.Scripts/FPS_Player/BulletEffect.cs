using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//총알이 충돌 하면  사운드가 울리고 이펙트 효과는 구현한다.
public class BulletEffect : MonoBehaviour
{
    public AudioSource source; //오디오소스
    public AudioClip effectClip; //오디오클립
    public GameObject effectPrefab; //이펙트 프리팹
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision col) //isTrigger 체크 X block
    {
        // 충돌 했다면 block  스스로 호출되는  콜백 함수 
        //태그 검사 충돌한 오브젝트가  == BULLET  인가?
        if(col.gameObject.tag =="BULLET") //최적화 부분은 나중에
        {
            Destroy(col.gameObject); // 충돌한 게임오브젝트 삭제 
            source.PlayOneShot(effectClip, 1.0f);
            // 사본 오브젝트에다가  원본 프리팹을 대입
            var eff = Instantiate(effectPrefab, col.transform.position, Quaternion.identity);
                                       //이펙트생성되는 위치  충돌한 위치,생성될때 회전 없이 생성
                       //객체생성메서드(what?, where, how Rotation?)
            Destroy(eff,2.5f);

        }
    }
    
}
