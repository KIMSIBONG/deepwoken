using UnityEngine;

public class Sword : MonoBehaviour
{
    public float knockbackForce = 10f; // 넉백 힘
    public GameObject knockbackObject; // 넉백을 받을 오브젝트

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
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.25f); // 반경 1 내의 모든 콜라이더 검사

        foreach (var collider in colliders)
        {
            // 검사한 오브젝트가 'parrying' 태그를 가진 경우
            if (collider.CompareTag("parrying"))
            {
                // 'parrying' 태그를 가진 오브젝트와 충돌했을 때 실행할 코드
                Knockback(collider.gameObject);
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
}