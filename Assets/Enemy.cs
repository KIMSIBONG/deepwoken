using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Transform player;
    public float speed;
    public Vector3 home;
    public float atkCooltime = 4;
    public float atkDelay;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        home = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(atkDelay>=0)
            atkDelay -= Time.deltaTime;
        
    }
    
    
}
