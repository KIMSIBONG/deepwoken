using UnityEngine;

public class Test : MonoBehaviour
{
    public float knockbackForce = 10f; // 넉백 힘

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
        // 마우스 클릭 위치를 가져옴
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // 레이캐스트를 통해 충돌을 확인
        if (Physics.Raycast(ray, out hit))
        {
            // 충돌한 오브젝트의 태그를 확인
            if (hit.collider.CompareTag("parrying"))
            {
                // 'parrying' 태그를 가진 오브젝트와 충돌했을 때 실행할 코드
                Knockback(hit.collider.gameObject);
            }
        }
    }

    void Knockback(GameObject parryingObject)
    {
        // parryingObject에 넉백 힘을 가함
        Rigidbody parryingRigidbody = parryingObject.GetComponent<Rigidbody>();
        if (parryingRigidbody != null)
        {
            Vector3 knockbackDirection = (parryingObject.transform.position - transform.position).normalized;
            parryingRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
    }
}