using UnityEngine;

public class Monsterattack : MonoBehaviour
{
    public float knockbackForce = 10f; // �˹� ��
    public GameObject knockbackObject; // �˹��� ���� ������Ʈ
    public GameObject particlePrefab; // ��ƼŬ ������
    private float lastClickTime = 0f;
    public float mouseCooldown = 1f;


    void Update()
    {
        float currentTime = Time.time;
        // ���콺 ���� ��ư Ŭ�� ����
        if (Input.GetMouseButtonDown(0) && (currentTime - lastClickTime) >= mouseCooldown)
        {
            // attack �Լ� ����
            Attack();
            lastClickTime = currentTime;
        }
    }

    void Attack()
    {
        // ���� ������Ʈ�� ��ġ�� �������� 'parrying' �±׸� ���� ������Ʈ �˻�
        float radius = 0.5f; // ���� ������ (ũ���� �ݰ�)
        Debug.Log("attack");
        // Physics.OverlapSphere�� ����Ͽ� �� ������ �浹ü ����
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var collider in colliders)
        {
            // �˻��� ������Ʈ�� 'parrying' �±׸� ���� ���
            if (collider.CompareTag("parrying"))
            {
                // 'parrying' �±׸� ���� ������Ʈ�� �浹���� �� ������ �ڵ�
                Knockback(collider.gameObject);

                // �ε��� ��ġ�� ������ ��ȯ
                ParryEffect(collider.ClosestPoint(transform.position));
            }
        }
    }

    void Knockback(GameObject parryingObject)
    {
        Debug.Log("parry");
        // parryingObject���� �˹� ���� ���� (x�� z �������θ�)
        Rigidbody knockbackRigidbody = knockbackObject.GetComponent<Rigidbody>();
        if (knockbackRigidbody != null)
        {
            Vector3 knockbackDirection = (knockbackObject.transform.position - transform.position).normalized;
            knockbackDirection.y = 0; // y ������ 0���� �����Ͽ� x�� z ���⸸���� �˹� �߻�
            knockbackRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
    }
    void ParryEffect(Vector3 position)
    {
        // �������� �����ؼ� ��ȯ
        GameObject spawnedPrefab = Instantiate(particlePrefab, position, Quaternion.identity);
        // ���⼭�� Quaternion.identity�� ����Ͽ� ȸ���� �������� ����
    }
}