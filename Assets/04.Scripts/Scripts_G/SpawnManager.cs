using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    Vector3[] enemyPosition= new Vector3[6];

    public GameObject[] enemies;

    public float[] spawnTimer = new float[5];
    public float[] spawnDelay = new float[5];

    [SerializeField]
    private int type = 0;
    [SerializeField]
    private int randBefore = 0;

    public float timer = 0f;
    public bool isSpawn = false;


    // Start is called before the first frame update
    void Start()
    {
        CreatePosition();
    }

    

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
            worldPos.z = 20f;
            
            enemyPosition[i] = worldPos;
            
           
        }
    }

    #region 레벨에 따른 스폰
    void StartSpawn() //G: 적 스폰 시작
    {
        timer += Time.deltaTime;
        if (isSpawn == true)
        {

            TypeSpawn(0); //Ship 출현
            if (timer >= 40) // 스폰 딜레이 변경 
            {
                spawnDelay[0] = 3f;
              
            }
            if (timer >= 60) //Sub_a 출현
            {   spawnDelay[0] = 5f;
                TypeSpawn(1);
            }
            
            if (timer >=90) //Mot 출현
            {
                spawnDelay[0] = 5f;
                spawnDelay[1] = 5f;
                TypeSpawn(2);
            }
             if (timer >= 150) // Hunt 출현
            {
                spawnDelay[0] = 7f;
                spawnDelay[1] = 10f;
                spawnDelay[2] = 15f;
                TypeSpawn(3);
            }
            if (timer >= 180) // Naval 출현
            {
                spawnDelay[0] = 6f;
                spawnDelay[1] = 9f;
                spawnDelay[2] = 12f;
                spawnDelay[3] = 19f;
                TypeSpawn(4);
            }
        }
    }
    
    void TypeSpawn(int type)
    {

        if (spawnTimer[type] > spawnDelay[type])
        {
            
            int rand = Random.Range(0, enemyPosition.Length);

            // 포지션 연속 중복 방지
            if (randBefore != rand)
            {
                Instantiate(enemies[type], enemyPosition[rand], Quaternion.identity);
            }
            else if(rand <5)
            {
                Instantiate(enemies[type], enemyPosition[rand+1], Quaternion.identity);
            }
            else if (rand == 5)
            {
                Instantiate(enemies[type], enemyPosition[0], Quaternion.identity);
            }
            spawnTimer[type] = 0f;
            randBefore = rand;
        }
        spawnTimer[type] += Time.deltaTime;
        
    }

    #endregion


    void Update()
    {
        StartSpawn();
    }
}
