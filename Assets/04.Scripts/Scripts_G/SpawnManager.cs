using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    Vector3[] enemyPosition= new Vector3[6];
   
    public GameObject[] enemies;
    public bool isSpawn = false;
    public float spawnTimer = 0f;
    public float spawnDelay = 1.5f;
   

    // Start is called before the first frame update
    void Start()
    {
        CreatePosition();
    }

    // Update is called once per frame
    

    void CreatePosition() //G:적이 생성될 위치값
    {
       
       
        float viewPosZ = -25f;
      
        float gapX = 1f / 7f;
       float viewPosX = 0f;
        
        for (int i = 0; i < enemyPosition.Length; i++)
        {
            
            viewPosX = gapX + gapX * i;

            Vector3 viewPos = new Vector3(viewPosX, 0, viewPosZ);

            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            worldPos.y = -0.2f;
           worldPos.z = 42f;
            
            enemyPosition[i] = worldPos;
            
           
        }
    }

    void StartSpawn()
    {
        if(isSpawn == true)
        {
            if(spawnTimer > spawnDelay)
            {
                int rand = Random.Range(0, enemyPosition.Length);
                int rand2 = Random.Range(0,enemies.Length);
                Instantiate(enemies[rand2], enemyPosition[rand], Quaternion.identity);

                spawnTimer = 0f;
            }
            spawnTimer += Time.deltaTime;
        }
    }
    
    void Update()
    {
        StartSpawn();
    }
}
