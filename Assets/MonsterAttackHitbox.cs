using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackHitbox : MonoBehaviour
{
    PlayerHP playerhp;
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
        // 충돌한 오브젝트의 태그가 "Enemy"인지 확인
        if (other.gameObject.CompareTag("Player"))
        {

            PlayerHP.php();
            // 이후 원하는 동작 수행 가능
        }
    }
}