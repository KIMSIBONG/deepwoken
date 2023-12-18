using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobCollider : MonoBehaviour
{
    // 몹 Collider에 대한 설정
    private void Start()
    {
        Collider enemyCollider = GetComponent<Collider>();
        if (enemyCollider != null)
        {
            enemyCollider.isTrigger = true; // 몹 Collider는 트리거여야 함
        }
    }
}