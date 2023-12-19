using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    private Animator animator;
    public Collider targetCollider; // 따라가야 할 콜라이더

    private void Start()
    {
        animator = GetComponent<Animator>();

        // 애니메이션 이벤트 등록
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = "UpdateColliderPosition";
        animationEvent.time = 0.5f; // 이벤트가 발생할 애니메이션 시간

        AnimationClip animationClip = animator.runtimeAnimatorController.animationClips[0]; // 애니메이션 클립 가져오기
        animationClip.AddEvent(animationEvent); // 애니메이션 클립에 이벤트 추가
    }

    // 애니메이션 이벤트에서 호출할 메서드
    private void UpdateColliderPosition()
    {
        if (targetCollider != null)
        {
            // 콜라이더의 위치와 회전을 애니메이션에 맞게 업데이트
            transform.position = targetCollider.transform.position;
            transform.rotation = targetCollider.transform.rotation;
        }
    }
}