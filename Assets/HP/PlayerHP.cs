using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private Slider phpbar;

    private float pmaxHp = 100;
    private float pcurHp = 100;
    public static Action php;
    public static Action php2;
    public static Action php3;
    private void Awake()
    {
        php = () =>
        {
            Damagetoplayer(); pHandleHp();
        };

        php2 = () =>
        {
            Damagetoplayer1(); pHandleHp();
        };
        php3 = () =>
        {
            Damagetoplayer2(); pHandleHp();
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        phpbar.value = (float)pcurHp / (float)pmaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pcurHp -= 10;
        }
        pHandleHp();
        if (pcurHp <= 0)
        {
            SceneManager.LoadScene("Stage2");
        }
    }

    private void pHandleHp()
    {
        phpbar.value = Mathf.Lerp(phpbar.value, (float)pcurHp / (float)pmaxHp, Time.deltaTime * 10);
    }
    private void Damagetoplayer()
    {
        pcurHp -= 10;
    }

    private void Damagetoplayer1()
    {
        pcurHp -= 15;

    }
    private void Damagetoplayer2()
    {
        pcurHp -= 20;

    }
}
