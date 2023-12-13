using UnityEngine;

public class Sword : MonoBehaviour
{
    public float knockbackForce = 10f; // 넉백 힘
    public GameObject knockbackObject; // 넉백을 받을 오브젝트
    public GameObject particlePrefab; // 파티클 프리팹

    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            // attack 함수 실행
            Attack();
        }
    }

    void Attack()
    {
        // 현재 오브젝트의 위치를 기준으로 'parrying' 태그를 가진 오브젝트 검사
        float radius = 0.25f; // 캡슐의 반지름
        float height = 1.5f; // 캡슐의 높이

        // 캡슐의 시작점과 끝점을 계산
        Vector3 startPoint = transform.position + new Vector3(0, height / 2f, 0);
        Vector3 endPoint = transform.position - new Vector3(0, height / 2f, 0);

        // Physics.OverlapCapsule을 사용하여 캡슐 형태의 충돌체 검출
        Collider[] colliders = Physics.OverlapCapsule(startPoint, endPoint, radius);

        foreach (var collider in colliders)
        {
            // 검사한 오브젝트가 'parrying' 태그를 가진 경우
            if (collider.CompareTag("parrying"))
            {
                // 'parrying' 태그를 가진 오브젝트와 충돌했을 때 실행할 코드
                Knockback(collider.gameObject);

                // 부딪힌 위치에 프리팹 소환
                ParryEffect(collider.ClosestPoint(transform.position));
            }
        }
    }

    void Knockback(GameObject parryingObject)
    {
        // parryingObject에도 넉백 힘을 가함 (x와 z 방향으로만)
        Rigidbody knockbackRigidbody = knockbackObject.GetComponent<Rigidbody>();
        if (knockbackRigidbody != null)
        {
            Vector3 knockbackDirection = (knockbackObject.transform.position - transform.position).normalized;
            knockbackDirection.y = 0; // y 방향은 0으로 설정하여 x와 z 방향만으로 넉백 발생
            knockbackRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
    }

    void ParryEffect(Vector3 position)
    {
        // 프리팹을 복제해서 소환
        GameObject spawnedPrefab = Instantiate(particlePrefab, position, Quaternion.identity);
        // 여기서는 Quaternion.identity를 사용하여 회전을 적용하지 않음
    }
}