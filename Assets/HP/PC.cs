using UnityEngine;

public class PC : MonoBehaviour
{
    private Collider myCollider;
    private bool colliderEnabled = true;
    private float disableDuration = 1f;

    void Start()
    {
        // 스크립트가 붙은 오브젝트의 Collider 컴포넌트 가져오기
        myCollider = GetComponent<Collider>();

        if (myCollider == null)
        {
            Debug.LogError("Collider 컴포넌트를 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        // 'F' 키를 누르면 콜라이더를 일시적으로 비활성화
        if (Input.GetKeyDown(KeyCode.F) && colliderEnabled)
        {
            DisableCollider();
        }
    }

    void DisableCollider()
    {
        // 콜라이더 비활성화
        myCollider.enabled = false;

        // 지정된 시간 이후에 콜라이더 다시 활성화
        Invoke("EnableCollider", disableDuration);
    }

    void EnableCollider()
    {
        // 콜라이더 활성화
        myCollider.enabled = true;
    }
}