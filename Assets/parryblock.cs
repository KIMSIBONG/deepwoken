using UnityEngine;
using System;
public class parryblock : MonoBehaviour
{
    PlayerAttack playerattack;
    public GameObject particlePrefab;
    public float knockbackForce = 10f;


    private void Start()
    {
        playerattack = GetComponent<PlayerAttack>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±װ� "Enemy"���� Ȯ��
        if (other.gameObject.CompareTag("EnemyAttack"))
        {

            Debug.Log("hi");
            // ���� ���ϴ� ���� ���� ����
        }
    }

}