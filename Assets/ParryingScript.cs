using UnityEngine;

public class ParryingScript : MonoBehaviour
{
    public GameObject parryObject;  // 프리팹 설정
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
            // 현재 실행 중인 모든 애니메이션을 멈춤
            
            // 애니메이션을 재생하고 나서 다시 정상 속도로 변경

        }
    }

    void SpawnPrefab()
    {
        // 플레이어의 현재 위치와 앞 방향으로 프리팹 소환
        Vector3 spawnPosition = transform.position + transform.forward * 2f;  // 예시로 2f만큼 앞으로 이동
        Quaternion spawnRotation = transform.rotation;

        // 프리팹을 소환
        Instantiate(parryObject, spawnPosition, spawnRotation);
    }
}