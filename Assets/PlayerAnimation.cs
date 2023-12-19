using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private float lastClickTime; // ������ Ŭ�� �ð� ���
    private float lastParryTime;
    public float clickCooldown = 3f; // Ŭ�� ��Ÿ�� ���� (��)
    public float parryCooldown = 1f;
    public GameObject parryObject;
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
                StopAllAnimations();

                // "Attack" �ִϸ��̼��� ���
                animator.SetTrigger("Attack");

                // AttackNumber�� ������Ű��, ������ 0���� 2������ ����

                // "Blend" �Ķ���� ����

                // ������ Ŭ�� �ð� ����
                lastClickTime = Time.time;

                // �ִϸ��̼��� ����ϰ� ���� �ٽ� ���� �ӵ��� ����
                
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
            // ���� ���� ���� ��� �ִϸ��̼��� ����
            
            // �ִϸ��̼��� ����ϰ� ���� �ٽ� ���� �ӵ��� ����

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // ���� ���� ���� ��� �ִϸ��̼��� ����
            StopAllAnimations();

            animator.SetTrigger("SideStep");
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            // ���� ���� ���� ��� �ִϸ��̼��� ����
            animator.SetTrigger("Walk");

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            // ���� ���� ���� ��� �ִ�;���̼��� ����
            StopAllAnimations();

            animator.SetTrigger("Run");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // ���� ���� ���� ��� �ִϸ��̼��� ����
            StopAllAnimations();

            animator.SetTrigger("SideStep");
        }

        if (!Input.anyKey)
        {
            // �ƹ� Ű�� �ȴ����� "Idle" �ִϸ��̼��� ���
            StopAllAnimations();
            animator.SetTrigger("Idle");
            
        }

        // �Ʒ��� �ٸ� �Է¿� ���� ó�� �ڵ��...
    }

    // ���� ���� ���� ��� �ִϸ��̼��� ���ߴ� �޼���
    private void StopAllAnimations()
    {
        
        
        
        animator.ResetTrigger("Run");
        animator.ResetTrigger("SideStep");
        animator.ResetTrigger("Walk");
        // �ٸ� �ִϸ��̼� Ʈ���ŵ� �ʿ信 ���� �߰�
    }
    void SpawnPrefab()
    {
        // �÷��̾��� ���� ��ġ�� �� �������� ������ ��ȯ
        Vector3 spawnPosition = transform.position + transform.forward * 2f;  // ���÷� 2f��ŭ ������ �̵�
        Quaternion spawnRotation = transform.rotation;

        // �������� ��ȯ
        Instantiate(parryObject, spawnPosition, spawnRotation);
    }
}