using UnityEngine;

public class PC : MonoBehaviour
{
    private Collider myCollider;
    private bool colliderEnabled = true;
    private float disableDuration = 1f;

    void Start()
    {
        // ��ũ��Ʈ�� ���� ������Ʈ�� Collider ������Ʈ ��������
        myCollider = GetComponent<Collider>();

        if (myCollider == null)
        {
            Debug.LogError("Collider ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    void Update()
    {
        // 'F' Ű�� ������ �ݶ��̴��� �Ͻ������� ��Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.F) && colliderEnabled)
        {
            DisableCollider();
        }
    }

    void DisableCollider()
    {
        // �ݶ��̴� ��Ȱ��ȭ
        myCollider.enabled = false;

        // ������ �ð� ���Ŀ� �ݶ��̴� �ٽ� Ȱ��ȭ
        Invoke("EnableCollider", disableDuration);
    }

    void EnableCollider()
    {
        // �ݶ��̴� Ȱ��ȭ
        myCollider.enabled = true;
    }
}