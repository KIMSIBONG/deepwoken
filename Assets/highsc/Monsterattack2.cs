using UnityEngine;

public class Monsterattack2 : MonoBehaviour
{
    public float clickCooldown = 1f;  // Ŭ�� ��ٿ� �ð�

    private float lastClickTime;       // ������ Ŭ�� �ð�
    public GameObject Candamageobject2;
    public float destroyDelay2 = 0.1f;
    public float knockbackForce = 2f;  // KnockBack�� ������ ��

    private void Update()
    {
        // ���콺 ���� ��ư Ŭ�� ����
        
    }

    private void Attackplayer()
    {
        // �� ������ �ݶ��̴� �浹 ���� üũ
        
        mCandamage2();

    }

    
    void mCandamage2()
    {
        // �÷��̾��� ���� ��ġ�� ���ɴϴ�.
        Vector3 mPosition = transform.position;

        // �÷��̾� ���ʿ� �������� �����ϵ�, Y ��ǥ�� 1�� �����մϴ�.
        Vector3 mspawnPosition = new Vector3(mPosition.x, 1f, mPosition.z) + transform.forward * 1f; // Y = 1�� ����

        // �������� �����մϴ�.2
        GameObject mspawnedPrefab = Instantiate(Candamageobject2, mspawnPosition, Quaternion.identity);

        // ���� �ð��� ���� �Ŀ� �������� �����մϴ�.
        Destroy(mspawnedPrefab, destroyDelay2);
    }
}