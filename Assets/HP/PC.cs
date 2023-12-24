using UnityEngine;
using System.Collections;

public class PC : MonoBehaviour
{
    private Collider colliderComponent;
    private bool colliderEnabled = true;

    void Start()
    {
        colliderComponent = GetComponent<Collider>();

        if (colliderComponent == null)
        {
            Debug.LogError("�ݶ��̴��� �����ϴ�.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleCollider();
        }
    }

    void ToggleCollider()
    {
        colliderEnabled = !colliderEnabled;

        // �ݶ��̴��� ��Ȱ��ȭ
        colliderComponent.enabled = colliderEnabled;

        if (colliderEnabled)
        {
            Debug.Log("�ݶ��̴��� Ȱ��ȭ�Ǿ����ϴ�.");
        }
        else
        {
            Debug.Log("�ݶ��̴��� ��Ȱ��ȭ�Ǿ����ϴ�.");

            // 1�� �Ŀ� ActivateCollider �޼��带 ȣ���Ͽ� �ݶ��̴��� �ٽ� Ȱ��ȭ
            StartCoroutine(ActivateColliderAfterDelay(0.4f));
        }
    }

    IEnumerator ActivateColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // �ݶ��̴��� �ٽ� Ȱ��ȭ
        colliderComponent.enabled = true;
        Debug.Log("�ݶ��̴��� �ٽ� Ȱ��ȭ�Ǿ����ϴ�.");
    }
}