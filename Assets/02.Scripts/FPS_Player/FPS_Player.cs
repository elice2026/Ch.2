using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// w-> 전진이동   s -> 후진이동    a-> 좌측이동   d-> 우측이동
public class FPS_Player : MonoBehaviour
{
    public float moveSpeed = 8f; //이동속도 어느정도 스피드로 이동할지 ?
    public float rotSpeed = 90f; //회전속도 
    public float jumpForce = 8.0f; //점프하는 힘  점프력
    private Transform tr;
    private Rigidbody rb;
    private bool isJump = false; //점프중인지 아닌지 판단 
    [Header("마우스로 회전")]
    public float XSensitivity = 100f; //x로 움직일 때 마우스 감도
    public float YSensitivity = 100f; //y로 움직일 때 마우스 감도
    public float yMinLimit = -45f; //마우스는 y축 움직일때 플레이어는 x축 회전 제한 최저값
    public float yMaxLimit = 45f; //마우스는 y축 움직일때 플레이어는 x축 회전 제한 최고값
    public float xMinLimit = -360f;//마우스는 x축 움직일때 플레이어는 y축 회전 제한 최저값
    public float xMaxLimit = 360f;//마우스는 x축 움직일때 플레이어는 y축 회전 제한 최고값
    public float yRot = 0f; //y축 회전변수
    public float xRot = 0f; //x축 회전변수 
    void Start()
    {
        //Update 할때마다 접근 하지 않고 스타트 함수에서 한번만 접근 추전
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        isJump = false;
        //바닥에 닿았으니 isJump =false; 전달
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A  , D// -1 ,0, +1
        float v = Input.GetAxis("Vertical"); //S -1  0  W 1 //

        #region 앞뒤 이동 및 좌우이동 
        FPSMove(h, v);
        #endregion

        #region 왼쪽 Shift +w 누르면  뛰어가기 
        FastMove(v);
        #endregion

        #region SpaceBar를 누르면 점프 하기 

        if (Input.GetButtonDown("Jump"))
        {
            FPSJump();
            isJump = true;
        }

        #endregion

        #region 마우스가 좌우로 이동 하면 (MouseX) :player 좌우로 (Y)축회전 마우스가 상하로 이동하면(MouseY) player는 X축 회전

        RotationLimit();

        #endregion
    }

    private void RotationLimit()
    {
        xRot += Input.GetAxis("Mouse X") * XSensitivity * Time.deltaTime;
        //   마우스는 X로 이동하면 플레이어 Y축회전 
        yRot += Input.GetAxis("Mouse Y") * YSensitivity * Time.deltaTime;
        //마우스를 Y로 이동 하면 플레이어는 X축회전 
        yRot = Mathf.Clamp(yRot, yMinLimit, yMaxLimit);
        tr.eulerAngles = new Vector3(-yRot, xRot, 0f);
        //eulerAngles = Vector3 3차원좌표값을 받아서 회전하는 것으로 변형 한다.
        // 어떤 특정각으로 회전 할 때  즉 값 제한을 해야 할 때 
        //tr.Rotate(x,y,z); //지속적인 회전을 할때 Rotate(x,y,z)메소드 사용 하면 된다.
        // Quaternion rot Quaternion 4차원복소수 메서드 
        //Quaternion rot = Quaternion.LookRotation(tr.eulerAngles);
        // 어떤 특정 각으로 회전해서 바라볼때
        //짐벌락현상 : 회전 x축 y축 z축이 엉키기 쉽다. 그럴때는 엉키지 않는  Quaternion을 쓴다.
    }

    private void FPSJump()
    {
        if (isJump == true) return; //isJump가 == true와 같다면 
         //return; // 위의 조건에 맞으면 메소드를 종료하고 빠져나간다.
         // 이 밑 하위로직으로 내려 가지 않는다.
        rb.velocity = Vector3.up * jumpForce;
        // velocity(속도) = 방향 × 점프력
        // 리지디 바디의 힘과방향(velocity)
    }

    private void FastMove(float v)
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            moveSpeed = 12f;
            tr.Translate(Vector3.forward * v * Time.deltaTime * moveSpeed, Space.Self);
        }
        else
        {
            moveSpeed = 8f;
        }
    }

    private void FPSMove(float h, float v)
    {
        tr.Translate(Vector3.right * h * Time.deltaTime * moveSpeed, Space.Self);
        //이동함수(왼쪽 오른쪽 moveSpeed 속도 만큼)              , 로컬좌표
        // A:입력:-1   D: 입력 +1
        tr.Translate(Vector3.forward * v * Time.deltaTime * moveSpeed, Space.Self);
        // 이동 함수( 전진 후진)
    }
}
