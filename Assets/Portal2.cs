using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� Player �±׸� ������ �ִ��� Ȯ��
        if (other.CompareTag("Player"))
        {
            // ���� ������ �̵�
            SceneManager.LoadScene("Finish");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
