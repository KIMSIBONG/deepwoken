using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    public float AttackNumber = 0f;
    void Start()
    {
        // Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        // 예를 들어, 스페이스 바를 누르면 "Attack" 애니메이션을 재생
        if (Input.GetMouseButtonDown(0))
        {
            // "Attack" 애니메이션을 재생
            animator.SetTrigger("Attack");

            // AttackNumber를 증가시키고, 범위를 0부터 2까지로 유지
            AttackNumber++;
            if (AttackNumber > 2)
            {
                AttackNumber = 0;
            }

            // "Blend" 파라미터 설정
            animator.SetFloat("Blend", AttackNumber);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Parrying");
            
        }
        
    }
    
}