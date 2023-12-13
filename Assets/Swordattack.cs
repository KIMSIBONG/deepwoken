using UnityEngine;

public class Swordattack : MonoBehaviour
{
    public GameObject attackPrefab; // Inspector���� �Ҵ��� ���� ������
    public Transform playerTransform; // Inspector���� �Ҵ��� �÷��̾��� Transform ������Ʈ
    public float destroyDelay = 0.3f; // Inspector���� �Ҵ��� �������� ������� �ð�

    private GameObject attackInstance; // ������ ���� �����տ� ���� ����

    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ���Ǿ��� ��
        if (Input.GetMouseButtonDown(0))
        {
            SpawnAttackPrefab();
        }

        // ������ �������� �����ϴ� ��� ��ġ�� ȸ���� �÷��̾ �°� ����
        if (attackInstance != null)
        {
            attackInstance.transform.position = playerTransform.position + playerTransform.forward * 1f;
            attackInstance.transform.rotation = playerTransform.rotation;
        }
    }

    void SpawnAttackPrefab()
    {
        // �̹� �������� ������ ��쿡�� �� �̻� �������� ����
        if (attackInstance != null)
        {
            return;
        }

        // �÷��̾��� ���� ��ġ�� ȸ���� ��������
        Vector3 playerPosition = playerTransform.position;
        Quaternion playerRotation = playerTransform.rotation;

        // �÷��̾��� ���� ������ �������� +1��ŭ ������
        Vector3 spawnOffset = playerTransform.forward * 1f;

        // �������� �÷��̾� ��ġ�� ������ �������� +1��ŭ �����µ� ��ġ�� ��ȯ
        attackInstance = Instantiate(attackPrefab, playerPosition + spawnOffset, playerRotation);

        // ���� �ð��� ���� �Ŀ� �������� �ı�
        Destroy(attackInstance, destroyDelay);
    }
}