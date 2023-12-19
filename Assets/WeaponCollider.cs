using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    private Animator animator;
    public Collider targetCollider; // ���󰡾� �� �ݶ��̴�

    private void Start()
    {
        animator = GetComponent<Animator>();

        // �ִϸ��̼� �̺�Ʈ ���
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = "UpdateColliderPosition";
        animationEvent.time = 0.5f; // �̺�Ʈ�� �߻��� �ִϸ��̼� �ð�

        AnimationClip animationClip = animator.runtimeAnimatorController.animationClips[0]; // �ִϸ��̼� Ŭ�� ��������
        animationClip.AddEvent(animationEvent); // �ִϸ��̼� Ŭ���� �̺�Ʈ �߰�
    }

    // �ִϸ��̼� �̺�Ʈ���� ȣ���� �޼���
    private void UpdateColliderPosition()
    {
        if (targetCollider != null)
        {
            // �ݶ��̴��� ��ġ�� ȸ���� �ִϸ��̼ǿ� �°� ������Ʈ
            transform.position = targetCollider.transform.position;
            transform.rotation = targetCollider.transform.rotation;
        }
    }
}