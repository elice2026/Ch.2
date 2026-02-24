using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform mainCameraTr;
    private Transform CanvasTr;
    void Start()
    {
        CanvasTr = GetComponent<Transform>();
        mainCameraTr = Camera.main.transform;
    }
    void Update()
    {
        CanvasTr.LookAt(mainCameraTr);
        //캔버스의 트랜스폼이 메인카메라의 트랜스폼을 쳐다 본다.
    }
}
