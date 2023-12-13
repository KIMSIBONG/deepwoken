using UnityEngine;

public class particle : MonoBehaviour
{
    public GameObject prefabToSpawn;

    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ���Ǿ��� ��
        if (Input.GetMouseButtonDown(0))
        {
            // ��ũ��Ʈ�� ������ ������Ʈ�� ��ġ�� ������
            Vector3 spawnPosition = transform.position;

            // �ε��� ��ġ�� ������ ��ȯ
            SpawnPrefab(spawnPosition);
        }
    }

    void SpawnPrefab(Vector3 position)
    {
        // �������� �����ؼ� ��ȯ
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, position, Quaternion.identity);
        // ���⼭�� Quaternion.identity�� ����Ͽ� ȸ���� �������� ����
    }
}