using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    // 바닥 Collider에 대한 설정
    private void Start()
    {
        Collider groundCollider = GetComponent<Collider>();
        if (groundCollider != null)
        {
            groundCollider.isTrigger = false; // 바닥 Collider는 트리거가 아니어야 함
        }
    }
}