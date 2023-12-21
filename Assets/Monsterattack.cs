using UnityEngine;

public class Monsterattack : MonoBehaviour
{
    public float clickCooldown = 1f;  // 클릭 쿨다운 시간

    private float lastClickTime;       // 마지막 클릭 시간
    public GameObject Candamageobject;
    public float destroyDelay = 0.1f;
    public float knockbackForce = 2f;  // KnockBack에 가해질 힘

    private void Update()
    {
        // 마우스 왼쪽 버튼 클릭 감지
        
    }

    private void Attackplayer()
    {
        // 구 형태의 콜라이더 충돌 여부 체크
        
        mCandamage();

    }

    
    void mCandamage()
    {
        // 플레이어의 현재 위치를 얻어옵니다.
        Vector3 mPosition = transform.position;

        // 플레이어 앞쪽에 프리팹을 생성하되, Y 좌표를 1로 설정합니다.
        Vector3 mspawnPosition = new Vector3(mPosition.x, 1f, mPosition.z) + transform.forward * 1f; // Y = 1로 변경

        // 프리팹을 생성합니다.
        GameObject mspawnedPrefab = Instantiate(Candamageobject, mspawnPosition, Quaternion.identity);

        // 일정 시간이 지난 후에 프리팹을 제거합니다.
        Destroy(mspawnedPrefab, destroyDelay);
    }
}