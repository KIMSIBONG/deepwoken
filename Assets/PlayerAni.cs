using UnityEditor.Animations;
using UnityEngine;

public class PlayerAni : MonoBehaviour
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
    public Collider myCollider; // �ܺο��� ������ ������Ʈ
    private bool colliderEnabled = true;
    private float disableDuration = 0.4f;
    public GameObject particle;
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
            if (Input.GetKeyDown(KeyCode.F) && colliderEnabled)
            {
                DisableCollider();
                SpawnPrefab();
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
    void DisableCollider()
    {
        // �ݶ��̴� ��Ȱ��ȭ
        myCollider.enabled = false;

        // ������ �ð� ���Ŀ� �ݶ��̴� �ٽ� Ȱ��ȭ
        Invoke("EnableCollider", disableDuration);
    }

    void EnableCollider()
    {
        // �ݶ��̴� Ȱ��ȭ
        myCollider.enabled = true;
    }
    void SpawnPrefab()
    {
        // ���� ������Ʈ�� ��ġ�� �����ͼ� y ��ǥ�� 1�� ����
        Vector3 spawnPosition = new Vector3(transform.position.x, 1.3f, transform.position.z);

        // �������� y ��ǥ�� 1�� ��ġ�� ����
        GameObject spawnedPrefab = Instantiate(particle, spawnPosition, transform.rotation);

        // 1�� �Ŀ� ������ ������ �ı�
        Destroy(spawnedPrefab, 1f);
    }


}