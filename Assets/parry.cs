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
        // 플레이어의 현재 위치와 앞 방향으로 프리팹 소환
        Vector3 spawnPosition = transform.position + transform.forward * 1f;  // 예시로 2f만큼 앞으로 이동
        Quaternion spawnRotation = transform.rotation;

        // 프리팹을 소환
        GameObject spawnedObject = Instantiate(parryObject, spawnPosition, spawnRotation);

        // 일정 시간이 지난 후에 생성된 오브젝트를 파괴
        Destroy(spawnedObject, destroyDelay);
    }
}
