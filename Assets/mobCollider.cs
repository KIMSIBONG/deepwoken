using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobCollider : MonoBehaviour
{
    // �� Collider�� ���� ����
    private void Start()
    {
        Collider enemyCollider = GetComponent<Collider>();
        if (enemyCollider != null)
        {
            enemyCollider.isTrigger = true; // �� Collider�� Ʈ���ſ��� ��
        }
    }
}