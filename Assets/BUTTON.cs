using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BUTTON : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickStart()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void ClickEnd()
    {
        SceneManager.LoadScene("Start");
    }
}
