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
        // 충돌한 오브젝트의 태그가 "Enemy"인지 확인
        if (other.gameObject.CompareTag("EnemyAttack"))
        {

            Debug.Log("hi");
            // 이후 원하는 동작 수행 가능
        }
    }

}