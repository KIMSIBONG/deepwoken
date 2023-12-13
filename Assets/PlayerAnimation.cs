using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Animator ������Ʈ ��������
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ���� ���, �����̽� �ٸ� ������ "Attack" �ִϸ��̼��� ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // "Attack" �ִϸ��̼��� ���
            animator.SetTrigger("AttackTrigger");
        }
    }
}