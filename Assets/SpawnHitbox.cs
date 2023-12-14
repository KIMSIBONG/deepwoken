using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnHitbox : MonoBehaviour
{
    public float spawnDistance = 2f;
    public GameObject attackhitbox;
    private float lastClickTime = 0f;
    public float mouseCooldown = 1f;

    public float destroyDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if (Input.GetMouseButtonDown(0) && (currentTime - lastClickTime) >= mouseCooldown)
        {
            GameObject spawnedPrefab = SpawnPrefabInFrontOfObject();
            

            Destroy(spawnedPrefab, destroyDelay);
            lastClickTime = currentTime;
        }
            
    }
    GameObject SpawnPrefabInFrontOfObject()
    {
        Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;

        // 오브젝트의 앞에 프리팹 소환
        GameObject spawnedPrefab = Instantiate(attackhitbox, spawnPosition, transform.rotation);

        return spawnedPrefab;
    }
    
}
