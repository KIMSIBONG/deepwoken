using UnityEngine;

public class Sword : MonoBehaviour
{
    public float knockbackForce = 10f; // �˹� ��
    public GameObject knockbackObject; // �˹��� ���� ������Ʈ

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
        // ���� ������Ʈ�� ��ġ�� �������� 'parrying' �±׸� ���� ������Ʈ �˻�
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.25f); // �ݰ� 1 ���� ��� �ݶ��̴� �˻�

        foreach (var collider in colliders)
        {
            // �˻��� ������Ʈ�� 'parrying' �±׸� ���� ���
            if (collider.CompareTag("parrying"))
            {
                // 'parrying' �±׸� ���� ������Ʈ�� �浹���� �� ������ �ڵ�
                Knockback(collider.gameObject);
            }
        }
    }

    void Knockback(GameObject parryingObject)
    {
        // parryingObject���� �˹� ���� ���� (x�� z �������θ�)
        Rigidbody knockbackRigidbody = knockbackObject.GetComponent<Rigidbody>();
        if (knockbackRigidbody != null)
        {
            Vector3 knockbackDirection = (knockbackObject.transform.position - transform.position).normalized;
            knockbackDirection.y = 0; // y ������ 0���� �����Ͽ� x�� z ���⸸���� �˹� �߻�
            knockbackRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
    }
}