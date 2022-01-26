using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    Vector3[] position = new Vector3[5];

    //public GameObject[] enemies;
    private Vector3 worldPos;
    private float viewPosZ = -30f;
    private float gapX = 1f / 6f;
    private float viewPosX = 0f;
    private Vector3 viewPos;

    public float spawnTimer;
    public float spawnDelay;
    public int[] spawnCount = new int[5];
    public int[] enemyNumber = new int[5];

    [SerializeField]
    private int type;


    [SerializeField]
    private int level = 1;
    private int levelBefore = 1;
    public int positionRand = 0;
    public float timer = 0f;
    public bool isSpawn = false;
    public bool isItemSpawn = true;

    public GameObject FadeOut;

    public int randType;
    public int randType2;
    public int randPosition;
    // Start is called before the first frame update
    void Start()
    {
        CreatePosition(-1, positionRand);
    }



    void CreatePosition(int type, int positionRand) //G:적이 생성될 위치값
    {
        if (type == -1)
        {
            for (int i = 0; i < position.Length; i++)
            {

                viewPosX = gapX + gapX * i;

                Vector3 viewPos = new Vector3(viewPosX, 0, viewPosZ);

                worldPos = Camera.main.ViewportToWorldPoint(viewPos);

                worldPos.y = -1f;

                position[i] = worldPos;
            }
        }
        else if (type == 1)
        {
            worldPos = position[positionRand];

            worldPos.y = -2.1f;

            position[positionRand] = worldPos;
        }
        else
        {
            worldPos = position[positionRand];

            worldPos.y = -1f;

            position[positionRand] = worldPos;
        }

    }
    #region 레벨에 따른 스폰
    void StartSpawn() //G: 적 스폰 시작
    {
        timer += Time.deltaTime;

        if (isSpawn == true)
        {
            if (level < 12)
            {
                LevelUpdate();
                LevelControl();
            }
            //------------------------------------------ 난이도 1
            if (timer >= 50f && timer < 51f) // hel1 출현 
            {
                ItemSpawn(8);
            }
            if (timer >= 60f && timer < 125f) //Mot 출현 
            {
                level = 2;
                if (timer < 61f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 93f && timer < 94f) // kit1 출현 
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(10);
                    }
                }
            }

            //------------------------------------------- 난이도 2    

            if (timer >= 125f && timer < 180f) //sub 출현
            {
                level = 3;
                if (timer < 126f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 140f && timer < 141f) //hel 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(8);
                    }
                }
            }

            //-------------------------------------------- 난이도 3
            if (timer >= 180f && timer < 240f)
            {
                level = 4;
                if (timer < 181f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 210f && timer < 211f) //kit2 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(11);
                    }
                }
                else if (timer > 229 && timer < 230f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 230f && timer < 231f) //hel 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(8);
                    }
                }

            }
            //-------------------------------------------- 난이도 4
            if (timer >= 240f && timer < 300f) // Naval 출현 
            {
                level = 5;
                if (timer < 241f)
                {
                    isItemSpawn = false;
                }
                //else if (timer >= 250f && timer < 251f) //clock 출현
                //{
                //    if (isItemSpawn == false)
                //    {
                //        ItemSpawn(12);
                //    }
                //}
                //else if (timer > 251 && timer < 252f)
                //{
                //    isItemSpawn = false;
                //}
                else if (timer >= 260f && timer < 261f) //kit2 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(11);
                    }
                }
            }
            //-------------------------------------------- 난이도 5
            if (timer >= 300f && timer < 360f)
            {
                level = 6;
                if (timer < 301f)
                {
                    isItemSpawn = false;
                }
            }
            //-------------------------------------------- 난이도 6
            if (timer >= 360f && timer < 420f)
            {
                level = 7;
                if (timer >= 390f && timer < 391f) //hel2 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(9);
                    }
                }
                else if (timer > 391 && timer < 392f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 410f && timer < 411f) //kit2 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(11);
                    }
                }
            }
            //-------------------------------------------- 난이도 7
            if (timer >= 420f && timer < 483f)
            {
                level = 8;
                if (timer < 421f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 430f && timer < 431f) //kit1 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(10);
                    }
                }
                else if (timer > 431 && timer < 432f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 435f && timer < 436f) //hel1 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(8);
                    }
                }
            }
            //-------------------------------------------- 난이도 8
            if (timer >= 483f && timer < 543f)
            {
                level = 9;
                if (timer < 484f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 490f && timer < 491f) //kit2 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(11);
                    }
                }
            }
            //-------------------------------------------- 난이도 9
            if (timer >= 543f && timer < 600f)
            {
                level = 10;
                if (timer < 544f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 560f && timer < 561f) //kit2 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(11);
                    }
                }
            }
            //-------------------------------------------- 난이도 10
            if (timer >= 600f && timer <= 780f)
            {
                level = 11;
                if (timer < 601f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 620f && timer < 621f) //kit2 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(11);
                    }
                }
                else if (timer > 621 && timer < 622f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 630f && timer < 631f) //hel2 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(9);
                    }
                }
                else if (timer > 631 && timer < 632f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 680f && timer < 681f) //kit1 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(10);
                    }
                }
                else if (timer > 681 && timer < 682f)
                {
                    isItemSpawn = false;
                }
                else if (timer >= 740f && timer < 741f) //kit2 출현
                {
                    if (isItemSpawn == false)
                    {
                        ItemSpawn(11);
                    }
                }
            }
            // ---------------------------------------------- ending
            if (timer > 780f)
            {
                level = 12;
                LevelUpdate();
            }
        }
    }

    void LevelUpdate()
    {
        switch (level)
        {
            //------------------------------------------ 난이도 1
            case 1:  
                spawnDelay = 3.2f;
                enemyNumber[0] = 20;
                EnemySpawn(0); //Ship 출현
                break;

            case 2:
                spawnDelay = 3.9f;
                enemyNumber[0] = 10;
                enemyNumber[2] = 7;
                EnemySpawn(2);  //Mot 출현
                break;
            //------------------------------------------- 난이도 2  
            case 3:
                spawnDelay = 3.3f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 5;
                enemyNumber[2] = 3;
                EnemySpawn(2);  //sub 출현          
                break;
            //-------------------------------------------- 난이도 3
            case 4:
                spawnDelay = 3.0f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 5;
                enemyNumber[2] = 6;
                EnemySpawn(2);
                break;
            //-------------------------------------------- 난이도 4
            case 5:
                spawnDelay = 3.25f;
                enemyNumber[0] = 8;
                enemyNumber[1] = 5;
                enemyNumber[2] = 7;
                EnemySpawn(2);
                break;
            //-------------------------------------------- 난이도 5
            case 6:
                spawnDelay = 3.4f;
                enemyNumber[0] = 5;
                enemyNumber[1] = 5;
                enemyNumber[2] = 8;
                EnemySpawn(2);
                break;
            //-------------------------------------------- 난이도 6
            case 7:
                spawnDelay = 2.8f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 2;
                enemyNumber[2] = 8;
                enemyNumber[3] = 3;
                EnemySpawn(3); // Hunt 출현
                break;
            //-------------------------------------------- 난이도 7
            case 8:
                spawnDelay = 2.6f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 5;
                enemyNumber[2] = 8;
                enemyNumber[3] = 3;
                EnemySpawn(3);
                break;
            //-------------------------------------------- 난이도 8
            case 9:
                spawnDelay = 3.15f;
                enemyNumber[0] = 0;
                enemyNumber[1] = 2;
                enemyNumber[2] = 10;
                enemyNumber[3] = 5;
                enemyNumber[4] = 3;
                EnemySpawn(4); // Naval 출현
                break;
            //-------------------------------------------- 난이도 9
            case 10:
                spawnDelay = 2.75f;
                enemyNumber[0] = 0;
                enemyNumber[1] = 4;
                enemyNumber[2] = 10;
                enemyNumber[3] = 5;
                enemyNumber[4] = 3;
                EnemySpawn(4);
                break;
            //-------------------------------------------- 난이도 10
            case 11:
                spawnDelay = 3.2f;
                enemyNumber[0] = 15;
                enemyNumber[1] = 5;
                enemyNumber[2] = 20;
                enemyNumber[3] = 10;
                enemyNumber[4] = 10;
                EnemySpawn(4);
                break;
            case 12:
                FadeOut.GetComponent<FadeOut>().StartFadeAnim();
                level++;
                break;
        }
    }

    void EnemySpawn(int type) //Spawn 중심적부분
    {
        if (spawnTimer > spawnDelay)
        {

            randPosition = Random.Range(0, position.Length);
            randType = Random.Range(0, type + 1);
            randType2 = Random.Range(0, type + 1);
            if (spawnCount[randType] < enemyNumber[randType])
            {  
                CreatePosition(randType, randPosition);
                GameObject leaveObj = ObjectPool.GetObj(randType);                
                leaveObj.transform.position = position[randPosition];
                spawnCount[randType] += 1;
            }
            else
            {
                while (randType == randType2 || spawnCount[randType2] == enemyNumber[randType2])
                {
                    randType2 = Random.Range(0, type + 1);
                }
                CreatePosition(randType2, randPosition);
                GameObject leaveObj = ObjectPool.GetObj(randType2);
                leaveObj.transform.position = position[randPosition];

                spawnCount[randType2] += 1;
                randType = randType2;
            }


            spawnTimer = 0f;

        }
        spawnTimer += Time.deltaTime;

    }

    void ItemSpawn(int type)
    {
        if (isItemSpawn == false)
        {
            randPosition = Random.Range(0, position.Length);
            GameObject leaveObj = ObjectPool.GetObj(type);
            leaveObj.transform.position = position[randPosition];
            isItemSpawn = true;
        }
    }

    void LevelControl()
    {
        if (levelBefore < level)
        {
            spawnCount = new int[5];
            levelBefore++;
        }

    }


    #endregion


    void Update()
    {
        if (level < 13)
            StartSpawn();

    }
}