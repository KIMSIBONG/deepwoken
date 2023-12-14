using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private float lastClickTime; // ������ Ŭ�� �ð� ���
    public float clickCooldown = 3f; // Ŭ�� ��Ÿ�� ���� (��)

    void Start()
    {
        // Animator ������Ʈ ��������
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ���콺 Ŭ�� ��Ÿ�� Ȯ��
        if (Time.time - lastClickTime >= clickCooldown)
        {
            // ���� ���, ���콺 Ŭ���� ������ "Attack" �ִϸ��̼��� ���
            if (Input.GetMouseButtonDown(0))
            {
                // "Attack" �ִϸ��̼��� ���
                animator.SetTrigger("Attack");

                // AttackNumber�� ������Ű��, ������ 0���� 2������ ����

                // "Blend" �Ķ���� ����

                // ������ Ŭ�� �ð� ����
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