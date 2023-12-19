using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    private SkinnedMeshRenderer meshRenderer;
    private MeshCollider collider;
    private float updateTime = 0.1f; // ������Ʈ ����
    private float timer = 0f;

    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        collider = GetComponent<MeshCollider>();

        if (collider == null)
        {
            Debug.LogError("MeshCollider component not found on this GameObject.");
            enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= updateTime)
        {
            timer = 0f;
            UpdateCollider();
        }
    }

    void UpdateCollider()
    {
        Mesh colliderMesh = new Mesh();
        meshRenderer.BakeMesh(colliderMesh);
        collider.sharedMesh = colliderMesh;
    }
}