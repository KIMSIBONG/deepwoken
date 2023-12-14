using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private float lastClickTime; // 마지막 클릭 시간 기록
    public float clickCooldown = 3f; // 클릭 쿨타임 설정 (초)

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
                // "Attack" 애니메이션을 재생
                animator.SetTrigger("Attack");

                // AttackNumber를 증가시키고, 범위를 0부터 2까지로 유지

                // "Blend" 파라미터 설정

                // 마지막 클릭 시간 갱신
                lastClickTime = Time.time;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Parrying");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Walk");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("Sideright");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Walk");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("Sideright");
        }
    }
}