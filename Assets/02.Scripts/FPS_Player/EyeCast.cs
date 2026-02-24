using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//광선 (Rayser) 쏘아서  부딪친 오브젝트로  충돌 했는 지 아닌지 판단 
public class EyeCast : MonoBehaviour
{
    private Transform tr;
    private Ray ray; //광선자료형(구조체)
    private RaycastHit hit;  //RaycastHit(구조체) : 광선에 어떤 오브젝트와 충돌 했을 때 충돌 감지 하는 자료형
    private float rayDistance = 20f; // 광선 충돌  범위
    public LayerMask layerMask; //레이어를 지정 할 수 있다.
    [Header("크로스헤어 스크립트 참조")]
    public CrossHair crossHair; //크로스헤어 스크립트 참조
    void Start()
    {
        tr = transform;
        crossHair = GameObject.Find("CrossHair").GetComponent<CrossHair>();
        //하이라키에서 오브젝트명인 CrossHair 를 찾아서 crossHair에 대입
    }
    void Update()
    {                 //카메라포지션, 카메라 전방으로
        ray = new Ray(tr.position, tr.forward);
                     // 위치     ,  방향  * 거리            ,색깔은 녹색
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);
        // 광선 그려준다.("씬화면에서만 보인다)
                              //출력 전용 매개변수
        if(Physics.Raycast(ray, out hit,rayDistance,layerMask))
        {      //광선을 쏘았는 데 10범위에 몬스터나 좀비가 충돌 했다면....

            //Debug.Log($"맞았다!");
            crossHair.isGaze = true; //크로스헤어 응시 중으로 변경

        }
        else //충돌 하지 않았다면.....
        {
            //Debug.Log($" 맞지 않음!");
            crossHair.isGaze = false; //크로스헤어 응시 중이 아님으로 변경
        }

    }
}
