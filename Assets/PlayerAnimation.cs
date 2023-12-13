using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 예를 들어, 스페이스 바를 누르면 "Attack" 애니메이션을 재생
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // "Attack" 애니메이션을 재생
            animator.SetTrigger("AttackTrigger");
        }
    }
}