using UnityEngine;

public class Monsterattack : MonoBehaviour
{
    public float clickCooldown = 1f;  // Ŭ�� ��ٿ� �ð�

    private float lastClickTime;       // ������ Ŭ�� �ð�
    public GameObject Candamageobject;
    public float destroyDelay = 0.1f;
    public float knockbackForce = 2f;  // KnockBack�� ������ ��

    private void Update()
    {
        // ���콺 ���� ��ư Ŭ�� ����
        
    }

    private void Attackplayer()
    {
        // �� ������ �ݶ��̴� �浹 ���� üũ
        
        mCandamage();

    }

    
    void mCandamage()
    {
        // �÷��̾��� ���� ��ġ�� ���ɴϴ�.
        Vector3 mPosition = transform.position;

        // �÷��̾� ���ʿ� �������� �����ϵ�, Y ��ǥ�� 1�� �����մϴ�.
        Vector3 mspawnPosition = new Vector3(mPosition.x, 1f, mPosition.z) + transform.forward * 1f; // Y = 1�� ����

        // �������� �����մϴ�.
        GameObject mspawnedPrefab = Instantiate(Candamageobject, mspawnPosition, Quaternion.identity);

        // ���� �ð��� ���� �Ŀ� �������� �����մϴ�.
        Destroy(mspawnedPrefab, destroyDelay);
    }
}