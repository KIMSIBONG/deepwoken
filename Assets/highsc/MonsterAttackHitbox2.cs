using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackHitbox2 : MonoBehaviour
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
        
        if (other.gameObject.CompareTag("Player"))
        {
            // parryCan�� false�� ���� ����
            
            PlayerHP.php3();
        }
    }


}