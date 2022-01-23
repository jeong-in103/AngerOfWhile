using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    Vector3[] position= new Vector3[5];

    public GameObject[] enemies;

    public float spawnTimer;
    public float spawnDelay;

    [SerializeField]
    private int type;

    [SerializeField]
    private int level = 1; 

    public float timer = 0f;
    public bool isSpawn = false;


    // Start is called before the first frame update
    void Start()
    {
        CreatePosition();
    }



    void CreatePosition() //G:적이 생성될 위치값
    {

        float viewPosZ = -30f;
        float gapX = 1f / 6f;
        float viewPosX = 0f;

        for (int i = 0; i < position.Length; i++)
        {

            viewPosX = gapX + gapX * i;

            Vector3 viewPos = new Vector3(viewPosX, 0, viewPosZ);

            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            worldPos.y = -0.2f;
           

            position[i] = worldPos;
        }

    }
    #region 레벨에 따른 스폰
    void StartSpawn() //G: 적 스폰 시작
    {
        timer += Time.deltaTime;
        if (isSpawn == true)
        {

            LevelUpdate();

            if (timer >= 60) //Sub_a 출현 
            {
                level = 2;
            }
            
            if (timer >=90) //Mot 출현
            {
                level = 3;
            }
             if (timer >= 150) // Hunt 출현 
            {
                level = 4;
            }
            if (timer >= 180) // Naval 출현 
            {
                level = 5;

            }
            
        }
    }
    
    void LevelUpdate()
    {
        switch (level)
        {
            
            case 1:
                Spawn(0); //Ship 출현
                break;

            case 2:
                Spawn(1);  //Sub_a 출현
                break;

            case 3:
                Spawn(2);  //Mot 출현          
                break;

            case 4:
                Spawn(3);  //Hunt 출현
                break;

            case 5:
                Spawn(4); //Naval 출현
                spawnDelay = 2.2f; 
                break;
        }
    }

    void Spawn(int type) //Spawn 중심적부분
    {

        if (spawnTimer > spawnDelay)
        {
            
            int randPosition = Random.Range(0, position.Length);
            int randType = Random.Range(0, type+1);
            int randType2 = Random.Range(0, 2);
            Instantiate(enemies[randType], position[randPosition], Quaternion.identity);
            randPosition = Random.Range(0, position.Length);

            if (randType == 2 || randType == 4) //적 밸런스 조정
            {
                Instantiate(enemies[randType2], position[randPosition], Quaternion.identity);
            }
            spawnTimer= 0f;
            
        }
        spawnTimer += Time.deltaTime;
        
    }

 
    #endregion


    void Update()
    {
        StartSpawn();
    }
}
