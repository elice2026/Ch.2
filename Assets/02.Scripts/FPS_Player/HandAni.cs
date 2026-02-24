using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Shift +w 누르면 뛰어갈때 총을 접고  떼면 원래대로 겨눈다.
public class HandAni : MonoBehaviour
{
    public float walkSpeed; //걷는 속도
    public float runSpeed; //뛰는 속도
    public Animation CombaSG_ani;
    public bool isRunning = false;
    void Start() // 게임 시작전 한번만 
    {
        walkSpeed = 5f;
        runSpeed = 10f;
    }
    void Update() // 게임 시작후  종료 될때 까지 계속 호출 되는 메소드
    {    //동시에 왼쪽 쉬프트키와  W를 누르고 있는 중이라면
        // || or 둘중에 하나만 참 이면 다 참이 된다.
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            CombaSG_ani.Play("running");// 총을 접는 애니메이션 호출
            isRunning = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)) // 왼쪽 쉬프키는 띠었다면
        {

            CombaSG_ani.Play("runStop"); //총을 원래위치로 되돌리는 애니메이션
            isRunning=false;
        }
        
    }
}
