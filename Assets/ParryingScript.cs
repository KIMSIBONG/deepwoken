using UnityEngine;

public class ParryingScript : MonoBehaviour
{
    public GameObject parryObject;  // ������ ����
    PlayerAnimation playerani;
    void Update()
    {
        if (Time.time - playerani.lastParryTime >= playerani.parryCooldown)
        {   
            if (Input.GetKeyDown(KeyCode.F))
            {
                SpawnPrefab();



                playerani.lastParryTime = Time.time;
            }
            // ���� ���� ���� ��� �ִϸ��̼��� ����
            
            // �ִϸ��̼��� ����ϰ� ���� �ٽ� ���� �ӵ��� ����

        }
    }

    void SpawnPrefab()
    {
        // �÷��̾��� ���� ��ġ�� �� �������� ������ ��ȯ
        Vector3 spawnPosition = transform.position + transform.forward * 2f;  // ���÷� 2f��ŭ ������ �̵�
        Quaternion spawnRotation = transform.rotation;

        // �������� ��ȯ
        Instantiate(parryObject, spawnPosition, spawnRotation);
    }
}