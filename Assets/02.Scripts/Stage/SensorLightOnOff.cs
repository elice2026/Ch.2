using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// FPS 랑 is Trigger 충돌감지 해서  라이트를 켜고  끄고 사운드로 구현 하면 좋겠다.
public class SensorLightOnOff : MonoBehaviour
{
    public AudioSource source;
    public AudioClip _lightSound;
    public Light sensorLight;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) //is Trigger 체크시 충돌감지 하는 메소드
    {
        // 콜백 함수라고도 한다.
        // 스스로 자기 자신 을 호출
        if(other.gameObject.tag == "Player") //충돌된 태그가 Player랑 같다면
        {
            sensorLight.enabled = true; //라이트를 켠다
            source.PlayOneShot(_lightSound, 1.0f);
            // 소리를 한번만 울려라(무엇을?, 볼륨크기는?)
        }

    }
    private void OnTriggerExit(Collider other) //  isTrigger 체크시 콜라이더 범위를 빠져 나갔다면 
    {
        if (other.gameObject.tag == "Player") //충돌된 태그가 Player랑 같다면
        {
            sensorLight.enabled = false; //라이트를 끈다
            source.PlayOneShot(_lightSound, 1.0f);
            
        }
    }

}
