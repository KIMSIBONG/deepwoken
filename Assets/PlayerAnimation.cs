using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private float lastClickTime; // 마지막 클릭 시간 기록
    private float lastParryTime;
    public float clickCooldown = 3f; // 클릭 쿨타임 설정 (초)
    public float parryCooldown = 1f;
    public GameObject parryObject;
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                StopAllAnimations();

                animator.SetTrigger("Parrying");
                SpawnPrefab();
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
    void SpawnPrefab()
    {
        // 플레이어의 현재 위치와 앞 방향으로 프리팹 소환
        Vector3 spawnPosition = transform.position + transform.forward * 2f;  // 예시로 2f만큼 앞으로 이동
        Quaternion spawnRotation = transform.rotation;

        // 프리팹을 소환
        Instantiate(parryObject, spawnPosition, spawnRotation);
    }
}