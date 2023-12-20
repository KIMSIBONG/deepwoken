using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parry : MonoBehaviour
{
    public GameObject parryObject;
    public float destroyDelay = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void parryon()
    {
        SpawnPrefab();
    }
    private void SpawnPrefab()
    {
        // �÷��̾��� ���� ��ġ�� �� �������� ������ ��ȯ
        Vector3 spawnPosition = transform.position + transform.forward * 1f;  // ���÷� 2f��ŭ ������ �̵�
        Quaternion spawnRotation = transform.rotation;

        // �������� ��ȯ
        GameObject spawnedObject = Instantiate(parryObject, spawnPosition, spawnRotation);

        // ���� �ð��� ���� �Ŀ� ������ ������Ʈ�� �ı�
        Destroy(spawnedObject, destroyDelay);
    }
}
