using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    // �ٴ� Collider�� ���� ����
    private void Start()
    {
        Collider groundCollider = GetComponent<Collider>();
        if (groundCollider != null)
        {
            groundCollider.isTrigger = false; // �ٴ� Collider�� Ʈ���Ű� �ƴϾ�� ��
        }
    }
}