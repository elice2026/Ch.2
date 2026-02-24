using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// 애니메이터 컨트롤러를 참조 해서  거리를 잰다음 (플레이어랑 좀비) 20미터 범위안에 들면 추적 walk 3미터 범위안에 들면 Attack
// Navigation : 좀비가 플레이를 잘 추적 할 수 있도록 
public class ZombieCtrl : MonoBehaviour
{
    public NavMeshAgent navi;
    public Animator animator;
    public float traceDist = 20f; //추적 범위
    public float attackDist = 3f; // 공격 범위
    // 좀비와 플레이어의 거리를 재려면 누구의 위치 
    public Transform zombieTr; //좀비의 위치 
    public Transform playerTr; // 플레이어의 위치 
    private ZombieDamage z_damage;
    void Start()
    {
        z_damage = GetComponent<ZombieDamage>();
        navi = this.gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        zombieTr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
                   //하이라키에서 Player라는 태크를 가진 오브젝트를  찾는다.
    }
    void Update()
    {
        if (z_damage.isDie) return; 
        // isDie가 참이 되면  더이상 이 하위 밑에 로직으로 내려가지 않는다.
        float dist = Vector3.Distance(zombieTr.position, playerTr.position);
        //  거리를 잰다 좀비와 플레이의 거리 
        if( dist <= attackDist) //공격 범위에 들어오면
        {
            animator.SetBool("IsAttack", true);
            navi.isStopped = true; //추적 중지 
            //문제점  : 거리가 3범위 안에 있으면 회전 하지 않고 공격 한다.
            //해결책 :  플레이어 회전하면  좀비나 몬스터도 같이 회전해서 공격 해야 한다.
            // 위의 해결 로직 

            //  rot    = 회전하면서 쳐다보는 기능(플레이어좌표)
            Quaternion rot = Quaternion.LookRotation(playerTr.position - zombieTr.position);
                                                       //타겟 위치(Player) -  좀비 자기자신 위치를 빼면 = 타겟(player)가 있는 방향이 나온다
            //Vector3 좌표값을 받아서 회전 한다
            zombieTr.rotation = Quaternion.Slerp(zombieTr.rotation, rot, Time.deltaTime * 3f);
                                 //곡면보간   //자기자신의 로테이션 , 플레이어 방향으로 , 3타임만큼 천천히 부드럽게 이동
        }
        else if (dist <= traceDist) //추적 범위 안에 들어오면 
        {
            navi.isStopped = false; //추적 시작 
            navi.destination = playerTr.position;
            //  추적 대상  = 플레이어 포지션
            animator.SetBool("IsAttack",false);
            animator.SetBool("IsTrace",true);
        }
        else //공격 이나 추적범위에도 아무것도 해당 되지 않으면
        {
            navi.isStopped = true;
            animator.SetBool("IsTrace",false );
        }

    }
}
