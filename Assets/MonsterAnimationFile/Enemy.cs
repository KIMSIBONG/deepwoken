using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Transform player;
    public float speed;
    
    public float atkCooltime = 4;
    public float atkDelay;
    public bool MonsterFollow = false;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        

    }

    // Update is called once per frame
    void Update()
    {
        MonsterLook();
        if(atkDelay>=0)
            atkDelay -= Time.deltaTime;
        

    }
    void MonsterLook()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.position;
            playerPosition.y = transform.position.y; // Y �������δ� �ٶ��� �ʵ��� y ���� ���� ��ü�� y ������ ����
            transform.LookAt(playerPosition);
        }
    }

}
