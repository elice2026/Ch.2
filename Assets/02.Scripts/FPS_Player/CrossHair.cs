using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrossHair : MonoBehaviour
{
    private Transform tr; //자기자신  트랜스폼
    private Image crossHairImg; //크로헤어 이미지 
    private float startTime; // 크로스헤어가 커지기 시작한 시각을 저장 할 변수 
    public float duration = 0.2f; // 크로스헤어가 커지는 시간적용 
    public float minSize = 0.8f; //크로스헤어의 최소크기 
    public float maxSize = 1.3f;//크로스헤어의 최대 크기 
    private Color originColor = new Color(1f,1f, 1f,0.8f); //최초의 색상
    private Color gazeColor = Color.red;  // 응시 중일때의 색상

    public bool isGaze; //응시 중인지 아닌지 판단
    void Start()
    {
        tr = transform;
        crossHairImg = GetComponent<Image>();
        startTime = Time.time; //크로스헤어가 커지기 시작한 시각 저장 하기위해  Time.time : 현재시간을 저장
        // 현재시를 대입해서 밑에 Update()에서 과거시간으로 하기 위해 

        //local이 붙는 이유 : 크로스헤어가 캔버스의 자식 오브젝트이기 때문에
        tr.localScale  = Vector3.one * minSize; //크로스헤어의 초기 크기 설정
        crossHairImg.color = originColor; //크로스헤어의 초기 색상 설정
    }
    void Update()
    {
        if (isGaze) //응시 중이라면...
        {               //(현재시간 - 과거시간 = 지난시간) / 지속시간
            float t = (Time.time - startTime) / duration; //지난시간에서 0.2f로 나눈 값
            tr.localScale = Vector3.one * Mathf.Lerp(minSize, maxSize, t);
            //Vector3.one: x,y,z  크기를 모두 동일하게 적용
            //Mathf.Lerp(시작값, 끝값, 비율) : 비율에 따라서 시작값에서 끝값으로 선형보간
            //lerp는 선형 보간 함수 
            crossHairImg.color = gazeColor; //응시 중일 때의 색상으로 변경
        }
        else //응시 중이 아니라면...
        {
            tr.localScale = Vector3.one * minSize; //크로스헤어의 크기를 최소 크기로 변경
            crossHairImg.color = originColor; //크로스헤어의 색상을 최초 색상으로 변경
            startTime = Time.time; //크로스헤어가 커지기 시작한 시각을 현재 시간으로 재설정

        }
    }
}
