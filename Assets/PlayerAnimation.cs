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
                // ���� ���� ���� ��� �ִϸ��̼��� ����
                animator.speed = 0f;
                
                // "Attack" �ִϸ��̼��� ���
                animator.SetTrigger("Attack");

                // AttackNumber�� ������Ű��, ������ 0���� 2������ ����

                // "Blend" �Ķ���� ����

                // ������ Ŭ�� �ð� ����
                lastClickTime = Time.time;

                // �ִϸ��̼��� ����ϰ� ���� �ٽ� ���� �ӵ��� ����
                animator.speed = 1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            // ���� ���� ���� ��� �ִϸ��̼��� ����
            animator.speed = 0f;

            animator.SetTrigger("Parrying");

            // �ִϸ��̼��� ����ϰ� ���� �ٽ� ���� �ӵ��� ����
            animator.speed = 1f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            // ���� ���� ���� ��� �ִϸ��̼��� ����
            animator.speed = 0f;

            animator.SetTrigger("Run");

            // �ִϸ��̼��� ����ϰ� ���� �ٽ� ���� �ӵ��� ����
            animator.speed = 1f;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // ���� ���� ���� ��� �ִϸ��̼��� ����
            animator.speed = 0f;

            animator.SetTrigger("Sideright");

            // �ִϸ��̼��� ����ϰ� ���� �ٽ� ���� �ӵ��� ����
            animator.speed = 1f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            // ���� ���� ���� ��� �ִϸ��̼��� ����
            animator.speed = 0f;

            animator.SetTrigger("Walk");

            // �ִϸ��̼��� ����ϰ� ���� �ٽ� ���� �ӵ��� ����
            animator.speed = 1f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // ���� ���� ���� ��� �ִϸ��̼��� ����
            animator.speed = 0f;

            animator.SetTrigger("Sideright");

            // �ִϸ��̼��� ����ϰ� ���� �ٽ� ���� �ӵ��� ����
            animator.speed = 1f;
        }

    }
}