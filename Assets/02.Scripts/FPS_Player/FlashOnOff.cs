using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//F키를 누르면 spotLight켜지고 F키를 누르면 다시 꺼진다. 
// 사운드도 울리게 할 것이다.
//1.라이트 자료형과 사운드 관련 자료형이 있어야 한다.
public class FlashOnOff : MonoBehaviour
{
    public Light _spotLight;  //라이트 
    public AudioSource source; // 스피커 :소리를 울리는 컴퍼넌트
    public AudioClip flashClip; // 사운드 파일 
   
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) //F키를 눌렀다면 
        {
            source.PlayOneShot(flashClip,1.0f);
            // 사운드 구현 
            _spotLight.enabled = !_spotLight.enabled;
            //! 부정 연산자  
        }
      
        
    }
}
