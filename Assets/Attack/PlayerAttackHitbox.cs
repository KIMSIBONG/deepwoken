using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    MonsterHP monsterhp;
    // Start is called before the first frame update
    void Start()
    {
        monsterhp = GetComponent<MonsterHP>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±װ� "Enemy"���� Ȯ��
        if (other.gameObject.CompareTag("Enemy"))
        {
           
            MonsterHP.mhp();
            // ���� ���ϴ� ���� ���� ����
        }
    }
}
