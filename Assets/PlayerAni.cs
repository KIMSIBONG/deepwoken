using UnityEditor.Animations;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    PlayerHP playerhp;
    private Animator animator;
    public float clickCooldown = 1f;
    private float lastClickTime; // 마지막 클릭 시간 기록
    private float lastParryTime;
     // 클릭 쿨타임 설정 (초)
    public float parryCooldown = 1f;
    public GameObject parryObject;
    public float destroyDelay = 0.5f;
    public Collider myCollider; // 외부에서 지정할 오브젝트
    private bool colliderEnabled = true;
    private float disableDuration = 0.4f;
    public GameObject particle;
    void Start()
    {
        // Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();
        

        
    }

    void Update()
    {
        // 마우스 클릭 쿨타임 확인
        if (Time.time - lastClickTime >= clickCooldown)
        {
            // 예를 들어, 마우스 클릭을 누르면 "Attack" 애니메이션을 재생
            if (Input.GetMouseButtonDown(0))
            {
                // 현재 실행 중인 모든 애니메이션을 멈춤
                StopAllAnimations();

                // "Attack" 애니메이션을 재생
                animator.SetTrigger("Attack");

                // AttackNumber를 증가시키고, 범위를 0부터 2까지로 유지

                // "Blend" 파라미터 설정

                // 마지막 클릭 시간 갱신
                lastClickTime = Time.time;

                // 애니메이션을 재생하고 나서 다시 정상 속도로 변경
                
            }

        }
        if (Time.time - lastParryTime >= parryCooldown)
        {
            if (Input.GetKeyDown(KeyCode.F) && colliderEnabled)
            {
                DisableCollider();
                SpawnPrefab();
                StopAllAnimations();
                
                animator.SetTrigger("Parrying");
                
                lastParryTime = Time.time;
            }
            // 현재 실행 중인 모든 애니메이션을 멈춤
            
            // 애니메이션을 재생하고 나서 다시 정상 속도로 변경

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // 현재 실행 중인 모든 애니메이션을 멈춤
            StopAllAnimations();

            animator.SetTrigger("SideStep");
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            // 현재 실행 중인 모든 애니메이션을 멈춤
            animator.SetTrigger("Walk");

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            // 현재 실행 중인 모든 애니;메이션을 멈춤
            StopAllAnimations();

            animator.SetTrigger("Run");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 현재 실행 중인 모든 애니메이션을 멈춤
            StopAllAnimations();

            animator.SetTrigger("SideStep");
        }

        if (!Input.anyKey)
        {
            // 아무 키나 안눌리면 "Idle" 애니메이션을 재생
            StopAllAnimations();
            animator.SetTrigger("Idle");
            
        }

        // 아래는 다른 입력에 대한 처리 코드들...
    }

    // 현재 실행 중인 모든 애니메이션을 멈추는 메서드
    private void StopAllAnimations()
    {
        
        
        
        animator.ResetTrigger("Run");
        animator.ResetTrigger("SideStep");
        animator.ResetTrigger("Walk");
        // 다른 애니메이션 트리거도 필요에 따라 추가
    }
    void DisableCollider()
    {
        // 콜라이더 비활성화
        myCollider.enabled = false;

        // 지정된 시간 이후에 콜라이더 다시 활성화
        Invoke("EnableCollider", disableDuration);
    }

    void EnableCollider()
    {
        // 콜라이더 활성화
        myCollider.enabled = true;
    }
    void SpawnPrefab()
    {
        // 현재 오브젝트의 위치를 가져와서 y 좌표를 1로 설정
        Vector3 spawnPosition = new Vector3(transform.position.x, 1.3f, transform.position.z);

        // 프리팹을 y 좌표가 1인 위치에 생성
        GameObject spawnedPrefab = Instantiate(particle, spawnPosition, transform.rotation);

        // 1초 후에 생성된 프리팹 파괴
        Destroy(spawnedPrefab, 1f);
    }


}