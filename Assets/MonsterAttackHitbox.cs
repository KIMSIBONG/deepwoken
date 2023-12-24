using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackHitbox : MonoBehaviour
{
    PlayerHP playerhp;
    PlayerAttack pat;
    public GameObject knockbackobject;
    public float knockbackForce;
    public float pushForce = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerhp = GetComponent<PlayerHP>();
        pat = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && pat.parryCan)
        {
            // parryCan�� true�� ���� ����
            Debug.Log("Parry!");

            // ���� ���ϴ� ���� ���� ����
            
        }
        else if (other.gameObject.CompareTag("Player") && !pat.parryCan)
        {
            // parryCan�� false�� ���� ����
            Debug.Log("Fail Parry!");
            Debug.Log("Damaged");
            PlayerHP.php();
        }
    }


}