using UnityEngine;

public class Monsterattack : MonoBehaviour
{
    public float clickCooldown = 1f;  // 클릭 쿨다운 시간
    public float sphereRadius = 0.5f; // 구의 반지름
    private float lastClickTime;       // 마지막 클릭 시간

    public GameObject particlePrefab;  // 충돌 시 소환될 파티클 프리팹
    public float knockbackForce = 2f;  // KnockBack에 가해질 힘

    private void Update()
    {
        // 마우스 왼쪽 버튼 클릭 감지
        if (Input.GetMouseButtonDown(0) && Time.time - lastClickTime > clickCooldown)
        {
            lastClickTime = Time.time;
            Attack();
        }
    }

    private void Attack()
    {
        // 구 형태의 콜라이더 충돌 여부 체크
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereRadius);

        foreach (Collider collider in hitColliders)
        {
            // parrying 태그를 가진 오브젝트와 충돌 시
            if (collider.CompareTag("parrying"))
            {
                Instantiate(particlePrefab, collider.transform.position, Quaternion.identity);
                KnockBack(collider.gameObject);
            }

            // Enemy 태그를 가진 오브젝트와 충돌 시
            if (collider.CompareTag("Enemy"))
            {
                Debug.Log("Damage");
            }
        }
    }

    private void KnockBack(GameObject obj)
    {
        // KnockBack 오브젝트가 뒤로 밀리게 설정
        Vector3 knockbackDirection = transform.position - obj.transform.position;
        knockbackDirection.y = 0;
        obj.GetComponent<Rigidbody>().AddForce(knockbackDirection.normalized * knockbackForce, ForceMode.Impulse);
    }
}