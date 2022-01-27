using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    private Vector3 worldPos;

    private float viewPosX = 0f;
    private float viewPosZ = -30f;

    [SerializeField]
    private int maxFishValue;
    private int fishValue = 0;

    [SerializeField]
    private float maxCoolTime;
    private float curCoolTime;

    [SerializeField]
    private float ranMinCoolTime;
    [SerializeField]
    private float ranMaxCoolTime;

    private void Start()
    {
        ResetSpawnTime();
        curCoolTime = maxCoolTime;
    }

    private void Update()
    {
        if(maxCoolTime <= curCoolTime)
        {
            curCoolTime = 0;
            ResetSpawnTime();
            fishValue = Random.Range(1, maxFishValue);
            SpawnFish(fishValue);
        }
        else
        {
            curCoolTime += Time.deltaTime;
        }
    }

    private void SpawnFish(int value)
    {
        for(int i = 0; i < value; i++)
        {
            viewPosX = Random.Range(0, 1f);

            Vector3 viewPos = new Vector3(viewPosX, 0, viewPosZ);
            worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            worldPos.y = -3f;

            GameObject fish = ObjectPool.GetObj((int)TypeID.FISH);
            fish.transform.position = worldPos;
        }       
    }

    private void ResetSpawnTime()
    {
        maxCoolTime = Random.Range(ranMinCoolTime, ranMaxCoolTime);
    }
}
