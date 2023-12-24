using UnityEngine;
using System;
public class PlayerAttack : MonoBehaviour
{
    public float clickCooldown = 1f;  // Ŭ�� ��ٿ� �ð�
    
    private float lastClickTime;       // ������ Ŭ�� �ð�
    public GameObject Candamageobject;
    public float destroyDelay = 0.1f;
    public float knockbackForce = 2f;  // KnockBack�� ������ ��
    public GameObject knockbackEnemy;
    public static Action knock;
    public bool parryCan = false; // �ʱⰪ�� true�� �����մϴ�.
    public float parryDuration = 0.2f;
    public float parryTimer = 0f;
    private void Awake()
    {
        knock = () =>
        {
            KnockBack();
        };

    }
    private void Update()
    {
        // ���콺 ���� ��ư Ŭ�� ����
        if (Input.GetMouseButtonDown(0) && Time.time - lastClickTime > clickCooldown)
        {
            lastClickTime = Time.time;

            
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            parryCan = true;
            Debug.Log("parrycan true");
            parryTimer = parryDuration;
        }

        parryTimer -= Time.deltaTime;
        if (parryTimer <= 0f)
        {
            parryCan = false;
            Debug.Log("parrycan false");
        }
    }

    private void AttackDamage()
    {
        // �� ������ �ݶ��̴� �浹 ���� üũ
        Debug.Log("Damage");
        Candamage();
        
    }

    private void KnockBack()
    {
        // KnockBack ������Ʈ�� �ڷ� �и��� ����
        Vector3 knockbackDirection = transform.position - knockbackEnemy.transform.position;
        knockbackDirection.y = 0;
        knockbackEnemy.GetComponent<Rigidbody>().AddForce(knockbackDirection.normalized * knockbackForce, ForceMode.Impulse);
    }
    void Candamage()
    {
        // �÷��̾��� ���� ��ġ�� ���ɴϴ�.
        Vector3 playerPosition = transform.position;

        // �÷��̾� ���ʿ� �������� �����ϵ�, Y ��ǥ�� 1�� �����մϴ�.
        Vector3 spawnPosition = new Vector3(playerPosition.x, 1f, playerPosition.z) + transform.forward * 1f; // Y = 1�� ����

        // �������� �����մϴ�.
        GameObject spawnedPrefab = Instantiate(Candamageobject, spawnPosition, Quaternion.identity);

        // ���� �ð��� ���� �Ŀ� �������� �����մϴ�.
        Destroy(spawnedPrefab, destroyDelay);
    }
}