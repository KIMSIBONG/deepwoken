using UnityEngine;
using System;
public class PlayerAttack : MonoBehaviour
{
    public float clickCooldown = 1f;  // 클릭 쿨다운 시간
    
    private float lastClickTime;       // 마지막 클릭 시간
    public GameObject Candamageobject;
    public float destroyDelay = 0.1f;
    public float knockbackForce = 2f;  // KnockBack에 가해질 힘
    public GameObject knockbackEnemy;
    public static Action knock;
    public bool parryCan = false; // 초기값은 true로 설정합니다.
    
    private void Awake()
    {
        knock = () =>
        {
            KnockBack();
        };

    }
    private void Update()
    {
        // 마우스 왼쪽 버튼 클릭 감지
        if (Input.GetMouseButtonDown(0) && Time.time - lastClickTime > clickCooldown)
        {
            lastClickTime = Time.time;

            
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            
        }

        
    }

    private void AttackDamage()
    {
        // 구 형태의 콜라이더 충돌 여부 체크
        Debug.Log("Damage");
        Candamage();
        
    }

    private void KnockBack()
    {
        // KnockBack 오브젝트가 뒤로 밀리게 설정
        Vector3 knockbackDirection = transform.position - knockbackEnemy.transform.position;
        knockbackDirection.y = 0;
        knockbackEnemy.GetComponent<Rigidbody>().AddForce(knockbackDirection.normalized * knockbackForce, ForceMode.Impulse);
    }
    void Candamage()
    {
        // 플레이어의 현재 위치를 얻어옵니다.
        Vector3 playerPosition = transform.position;

        // 플레이어 앞쪽에 프리팹을 생성하되, Y 좌표를 1로 설정합니다.
        Vector3 spawnPosition = new Vector3(playerPosition.x, 1f, playerPosition.z) + transform.forward * 1f; // Y = 1로 변경

        // 프리팹을 생성합니다.
        GameObject spawnedPrefab = Instantiate(Candamageobject, spawnPosition, Quaternion.identity);

        // 일정 시간이 지난 후에 프리팹을 제거합니다.
        Destroy(spawnedPrefab, destroyDelay);
    }
}