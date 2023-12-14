using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    public Transform targetObject; // ����ٴ� ��� ������Ʈ
    public float followSpeed = 5f; // ���󰡴� �ӵ�

    void Update()
    {
        if (targetObject != null)
        {
            // ��� ������Ʈ�� ��ġ�� ���� ������Ʈ�� ���󰡵��� ����
            transform.position = Vector3.Lerp(transform.position, targetObject.position, followSpeed * Time.deltaTime);
        }
    }
}