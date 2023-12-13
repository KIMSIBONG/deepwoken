using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    public float AttackNumber = 0f;
    void Start()
    {
        // Animator ������Ʈ ��������
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        // ���� ���, �����̽� �ٸ� ������ "Attack" �ִϸ��̼��� ���
        if (Input.GetMouseButtonDown(0))
        {
            // "Attack" �ִϸ��̼��� ���
            animator.SetTrigger("Attack");

            // AttackNumber�� ������Ű��, ������ 0���� 2������ ����
            AttackNumber++;
            if (AttackNumber > 2)
            {
                AttackNumber = 0;
            }

            // "Blend" �Ķ���� ����
            animator.SetFloat("Blend", AttackNumber);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Parrying");
            
        }
        
    }
    
}