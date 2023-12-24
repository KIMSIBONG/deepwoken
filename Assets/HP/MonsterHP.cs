using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class MonsterHP : MonoBehaviour
{
    [SerializeField]
    private Slider mhpbar;

    private bool hasSpawned = false;
    public Transform enemyob;
    public GameObject nextstageob; // 소환할 프리팹
    public float mmaxHp = 1000;
    public float mcurHp = 1000;
    public static Action mhp;
    private void Awake()
    {
        mhp = () =>
        {
            Damagetomonster(); mHandleHp();
        };

    }
    // Start is called before the first frame update
    void Start()
    {
        mhpbar.value = (float)mcurHp / (float)mmaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
        mHandleHp();
        if (mcurHp <= 0 && !hasSpawned)
        {
            
            SpawnPrefabAtOtherObjectPosition();
            Destroy(enemyob);
        }
    }

    private void mHandleHp()
    {
        mhpbar.value = Mathf.Lerp(mhpbar.value, (float)mcurHp / (float)mmaxHp, Time.deltaTime * 10);
    }
    private void Damagetomonster()
    {
        mcurHp -= 20;
    }
    void SpawnPrefabAtOtherObjectPosition()
    {
        // 다른 오브젝트의 위치 가져오기
        Vector3 otherObjectPosition = enemyob.position;

        // Y축을 1로 설정하여 지면 위에 소환되도록 함
        otherObjectPosition.y = 1f;

        // 프리팹 소환
        Instantiate(nextstageob, otherObjectPosition, Quaternion.identity);
        hasSpawned = true;
    }
}
