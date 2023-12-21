using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    public GameObject playerBlockPrefab;
    public GameObject parryBlockPrefab;
    private GameObject spawnedPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedPrefab != null)
        {
            // "PlayerLocation" �±׸� ���� ������Ʈ�� ��ġ�� �̵��մϴ�.
            GameObject playerObject = GameObject.FindGameObjectWithTag("PlayerLocation");

            if (playerObject != null)
            {
                // �������� Player ������Ʈ�� ��ġ�� �̵���ŵ�ϴ�.
                spawnedPrefab.transform.position = playerObject.transform.position;
            }
        }
        
    }
    private void PlayerBlockOn()
    {
        spawnedPrefab = Instantiate(playerBlockPrefab, Vector3.zero, Quaternion.identity);
    }
    private void ParryBlockOn()
    {
        spawnedPrefab = Instantiate(parryBlockPrefab, Vector3.zero, Quaternion.identity);
    }

}
