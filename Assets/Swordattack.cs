using UnityEngine;

public class Swordattack : MonoBehaviour
{
    public GameObject attackPrefab; // Inspector에서 할당할 공격 프리팹
    public Transform playerTransform; // Inspector에서 할당할 플레이어의 Transform 컴포넌트
    public float destroyDelay = 0.3f; // Inspector에서 할당할 프리팹이 사라지는 시간

    private GameObject attackInstance; // 생성된 공격 프리팹에 대한 참조

    void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었을 때
        if (Input.GetMouseButtonDown(0))
        {
            SpawnAttackPrefab();
        }

        // 생성된 프리팹이 존재하는 경우 위치와 회전을 플레이어에 맞게 갱신
        if (attackInstance != null)
        {
            attackInstance.transform.position = playerTransform.position + playerTransform.forward * 1f;
            attackInstance.transform.rotation = playerTransform.rotation;
        }
    }

    void SpawnAttackPrefab()
    {
        // 이미 프리팹이 생성된 경우에는 더 이상 생성하지 않음
        if (attackInstance != null)
        {
            return;
        }

        // 플레이어의 현재 위치와 회전을 가져오기
        Vector3 playerPosition = playerTransform.position;
        Quaternion playerRotation = playerTransform.rotation;

        // 플레이어의 앞쪽 방향을 기준으로 +1만큼 오프셋
        Vector3 spawnOffset = playerTransform.forward * 1f;

        // 프리팹을 플레이어 위치와 방향을 기준으로 +1만큼 오프셋된 위치에 소환
        attackInstance = Instantiate(attackPrefab, playerPosition + spawnOffset, playerRotation);

        // 일정 시간이 지난 후에 프리팹을 파괴
        Destroy(attackInstance, destroyDelay);
    }
}