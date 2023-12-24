using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageM3 : MonoBehaviour
{
    PlayerHP playerhp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerhp.pcurHp <= 0)
        {
            SceneManager.LoadScene("Finish");
        }
    }
}
