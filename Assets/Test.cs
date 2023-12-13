using UnityEngine;

public class Test : MonoBehaviour
{
    public float knockbackForce = 10f; // �˹� ��

    void Update()
    {
        // ���콺 ���� ��ư Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            // attack �Լ� ����
            Attack();
        }
    }

    void Attack()
    {
        // ���콺 Ŭ�� ��ġ�� ������
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // ����ĳ��Ʈ�� ���� �浹�� Ȯ��
        if (Physics.Raycast(ray, out hit))
        {
            // �浹�� ������Ʈ�� �±׸� Ȯ��
            if (hit.collider.CompareTag("parrying"))
            {
                // 'parrying' �±׸� ���� ������Ʈ�� �浹���� �� ������ �ڵ�
                Knockback(hit.collider.gameObject);
            }
        }
    }

    void Knockback(GameObject parryingObject)
    {
        // parryingObject�� �˹� ���� ����
        Rigidbody parryingRigidbody = parryingObject.GetComponent<Rigidbody>();
        if (parryingRigidbody != null)
        {
            Vector3 knockbackDirection = (parryingObject.transform.position - transform.position).normalized;
            parryingRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
    }
}