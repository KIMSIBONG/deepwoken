using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackHitbox : MonoBehaviour
{
    PlayerHP playerhp;
    public GameObject knockbackobject;
    public float knockbackForce;
    public float pushForce = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerhp = GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±װ� "Enemy"���� Ȯ��
        if (other.gameObject.CompareTag("Player"))
        {


            // ���� ���ϴ� ���� ���� ����
            
            PlayerHP.php();
        }
        
    }

}