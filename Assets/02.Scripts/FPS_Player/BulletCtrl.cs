using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//총알이 Z축으로 날아가야 한다.
public class BulletCtrl : MonoBehaviour
{
    public float speed = 2000f;
    public Rigidbody rb;
    void Start()
    {
        // 리지디바디.AddForce(방향 *speed) 로컬좌표 
        rb.AddForce(transform.forward * speed); //방향 * 스피드 = velocity
        //Vector3.forward :절대 좌표 혹은 월드좌표
        Destroy(this.gameObject, 3.0f);
        // 객체소멸함수(자기자신 게임오브젝트,3초)후에 사라지게
        //GabageCollector
    }

    
}
