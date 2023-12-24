using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerHP playerhp;
    private Animator animator;
    public float clickCooldown = 1f;
    private float lastClickTime; // ������ Ŭ�� �ð� ���
    private float lastParryTime;
     // Ŭ�� ��Ÿ�� ���� (��)
    public float parryCooldown = 1f;
    public GameObject parryObject;
    public float destroyDelay = 0.5f;
    public GameObject targetObject; // �ܺο��� ������ ������Ʈ
    private Collider colliderComponent;
    private bool colliderEnabled = true;
    void Start()
    {
        // Animator ������Ʈ ��������
        animator = GetComponent<Animator>();
        if (targetObject == null)
        {
            Debug.LogError("Ÿ�� ������Ʈ�� �������� �ʾҽ��ϴ�.");
            return;
        }

        colliderComponent = targetObject.GetComponent<Collider>();

        if (colliderComponent == null)
        {
            Debug.LogError("�ݶ��̴��� �����ϴ�.");
        }
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
                ToggleCollider();
                StopAllAnimations();
                
                animator.SetTrigger("Parrying");
                
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
    void ToggleCollider()
    {
        colliderEnabled = !colliderEnabled;

        // �ݶ��̴��� ��Ȱ��ȭ
        colliderComponent.enabled = colliderEnabled;

        if (colliderEnabled)
        {
            Debug.Log("�ݶ��̴��� Ȱ��ȭ�Ǿ����ϴ�.");
        }
        else
        {
            Debug.Log("�ݶ��̴��� ��Ȱ��ȭ�Ǿ����ϴ�.");

            // 1�� �Ŀ� ActivateCollider �޼��带 ȣ���Ͽ� �ݶ��̴��� �ٽ� Ȱ��ȭ
            Invoke("ActivateCollider", 0.7f);
        }
    }
    void ActivateCollider()
    {
        // �ݶ��̴��� �ٽ� Ȱ��ȭ
        colliderComponent.enabled = true;
        Debug.Log("�ݶ��̴��� �ٽ� Ȱ��ȭ�Ǿ����ϴ�.");
    }


}