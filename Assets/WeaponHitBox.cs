using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    public Transform targetObject; // 따라다닐 대상 오브젝트
    public float followSpeed = 5f; // 따라가는 속도

    void Update()
    {
        if (targetObject != null)
        {
            // 대상 오브젝트의 위치를 현재 오브젝트가 따라가도록 보간
            transform.position = Vector3.Lerp(transform.position, targetObject.position, followSpeed * Time.deltaTime);
        }
    }
}