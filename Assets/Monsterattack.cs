using UnityEngine;

public class Monsterattack : MonoBehaviour
{
    public float clickCooldown = 1f;  // Ŭ�� ��ٿ� �ð�
    public float sphereRadius = 0.5f; // ���� ������
    private float lastClickTime;       // ������ Ŭ�� �ð�

    public GameObject particlePrefab;  // �浹 �� ��ȯ�� ��ƼŬ ������
    public float knockbackForce = 2f;  // KnockBack�� ������ ��

    private void Update()
    {
        // ���콺 ���� ��ư Ŭ�� ����
        if (Input.GetMouseButtonDown(0) && Time.time - lastClickTime > clickCooldown)
        {
            lastClickTime = Time.time;
            Attack();
        }
    }

    private void Attack()
    {
        // �� ������ �ݶ��̴� �浹 ���� üũ
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereRadius);

        foreach (Collider collider in hitColliders)
        {
            // parrying �±׸� ���� ������Ʈ�� �浹 ��
            if (collider.CompareTag("parrying"))
            {
                Instantiate(particlePrefab, collider.transform.position, Quaternion.identity);
                KnockBack(collider.gameObject);
            }

            // Enemy �±׸� ���� ������Ʈ�� �浹 ��
            if (collider.CompareTag("Enemy"))
            {
                Debug.Log("Damage");
            }
        }
    }

    private void KnockBack(GameObject obj)
    {
        // KnockBack ������Ʈ�� �ڷ� �и��� ����
        Vector3 knockbackDirection = transform.position - obj.transform.position;
        knockbackDirection.y = 0;
        obj.GetComponent<Rigidbody>().AddForce(knockbackDirection.normalized * knockbackForce, ForceMode.Impulse);
    }
}