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
            Debug.LogError("콜라이더가 없습니다.");
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

        // 콜라이더를 비활성화
        colliderComponent.enabled = colliderEnabled;

        if (colliderEnabled)
        {
            Debug.Log("콜라이더가 활성화되었습니다.");
        }
        else
        {
            Debug.Log("콜라이더가 비활성화되었습니다.");

            // 1초 후에 ActivateCollider 메서드를 호출하여 콜라이더를 다시 활성화
            StartCoroutine(ActivateColliderAfterDelay(0.4f));
        }
    }

    IEnumerator ActivateColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 콜라이더를 다시 활성화
        colliderComponent.enabled = true;
        Debug.Log("콜라이더가 다시 활성화되었습니다.");
    }
}