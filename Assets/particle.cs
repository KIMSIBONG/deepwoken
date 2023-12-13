using UnityEngine;

public class particle : MonoBehaviour
{
    public GameObject prefabToSpawn;

    void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 스크립트가 부착된 오브젝트의 위치를 가져옴
            Vector3 spawnPosition = transform.position;

            // 부딪힌 위치에 프리팹 소환
            SpawnPrefab(spawnPosition);
        }
    }

    void SpawnPrefab(Vector3 position)
    {
        // 프리팹을 복제해서 소환
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, position, Quaternion.identity);
        // 여기서는 Quaternion.identity를 사용하여 회전을 적용하지 않음
    }
}