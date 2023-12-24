using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal1 : MonoBehaviour
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
        // 충돌한 오브젝트가 Player 태그를 가지고 있는지 확인
        if (other.CompareTag("Player"))
        {
            // 다음 씬으로 이동
            SceneManager.LoadScene("Stage3");
        }
    }
}
