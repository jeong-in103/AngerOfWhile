using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Vector3[] position = new Vector3[5];

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
    private int samePosition;

    [SerializeField]
    private int type;

   // public int positionRand = 0;
    public float timer = 0f;
    public bool isSpawn = false;
    public bool isItemCreation=false;

    public GameObject FadeOut;

    public int randType;
    public int randType2;
    public int currentRandPosition;
    public int beforeRandPosition;

    // S 
    [SerializeField]
    private int level = 1;
    public int developLevel;

    public int[] levelTimes = new int[13];
    private List<GameObject> ships = new List<GameObject>();
    private System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        WorldPositionInit();
    }

    void Update()
    {
        //개발용 Levle 설정
        if (developLevel!=0)
        {
            level = developLevel-1;
            timer = levelTimes[developLevel - 1];
            ships.Clear();
            developLevel = 0;
        }
        //현재 Level에서 배들이 다 나왔을 경우
        if(ships.Count == 0)
        {
            level++;
            LevelUpSetting(level);
        }

        if (level < 13)
        {
            EnemySpawn(); //적 생성
            ItemSpawn();  //아이템 생성
        }
    }
    void WorldPositionInit()
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
    private void SpawnCountInit()
    {
        for (int i = 0; i < spawnCount.Length; i++)
        {
            spawnCount[i] = 0;
        }
    }
    // 현재 Level에 나올 배 List에 준비하기
    private void shipsReady(int num)
    {
        for (int i = 0; i < enemyNumber[num]; i++)
        {
            GameObject ship = ObjectPool.GetObj(num);
            ship.gameObject.SetActive(false);
            ships.Add(ship);
        }
    }

    #region 레벨에 따른 스폰
    void LevelUpSetting(int level)
    {
        switch (level)
        {
            //------------------------------------------ 난이도 1
            case 1:
                spawnDelay = 3.2f;
                enemyNumber[0] = 2;
                SpawnCountInit();

                ships.Clear();
                shipsReady(0);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;

            case 2:
                spawnDelay = 3.9f;
                enemyNumber[0] = 10;
                enemyNumber[2] = 7;
                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(2);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;
            //------------------------------------------- 난이도 2  
            case 3:
                spawnDelay = 3.3f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 5;
                enemyNumber[2] = 3;

                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(1);
                shipsReady(2);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;
            //-------------------------------------------- 난이도 3
            case 4:
                spawnDelay = 3.0f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 5;
                enemyNumber[2] = 6;
                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(1);
                shipsReady(2);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;
            //-------------------------------------------- 난이도 4
            case 5:
                spawnDelay = 3.25f;
                enemyNumber[0] = 8;
                enemyNumber[1] = 5;
                enemyNumber[2] = 7;

                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(1);
                shipsReady(2);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;
            //-------------------------------------------- 난이도 5
            case 6:
                spawnDelay = 3.4f;
                enemyNumber[0] = 5;
                enemyNumber[1] = 5;
                enemyNumber[2] = 8;

                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(1);
                shipsReady(2);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;
            //-------------------------------------------- 난이도 6
            case 7:
                spawnDelay = 2.8f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 2;
                enemyNumber[2] = 8;
                enemyNumber[3] = 3;

                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(1);
                shipsReady(2);
                shipsReady(3);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;
            //-------------------------------------------- 난이도 7
            case 8:
                spawnDelay = 2.6f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 5;
                enemyNumber[2] = 8;
                enemyNumber[3] = 3;

                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(1);
                shipsReady(2);
                shipsReady(3);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;
            //-------------------------------------------- 난이도 8
            case 9:
                spawnDelay = 3.15f;
                enemyNumber[0] = 0;
                enemyNumber[1] = 2;
                enemyNumber[2] = 10;
                enemyNumber[3] = 5;
                enemyNumber[4] = 3;

                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(1);
                shipsReady(2);
                shipsReady(3);
                shipsReady(4);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;
            //-------------------------------------------- 난이도 9
            case 10:
                spawnDelay = 2.75f;
                enemyNumber[0] = 0;
                enemyNumber[1] = 4;
                enemyNumber[2] = 10;
                enemyNumber[3] = 5;
                enemyNumber[4] = 3;

                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(1);
                shipsReady(2);
                shipsReady(3);
                shipsReady(4);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;
            //-------------------------------------------- 난이도 10
            case 11:
                spawnDelay = 3.2f;
                enemyNumber[0] = 15;
                enemyNumber[1] = 5;
                enemyNumber[2] = 20;
                enemyNumber[3] = 10;
                enemyNumber[4] = 10;

                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(1);
                shipsReady(2);
                shipsReady(3);
                shipsReady(4);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;

            case 12:
                FadeOut.GetComponent<FadeOut>().StartFadeAnim();
                break;
        }
    }

    void EnemySpawn() //Spawn 중심적부분
    {
        if (spawnTimer > spawnDelay)
        {
            if (ships.Count != 0)
            {
               currentRandPosition = random.Next(0,position.Length); // 배 나올 위치
                if (beforeRandPosition == currentRandPosition) //연속 포지션 3번 이상 금지
                {
                    samePosition += 1;
                    if(samePosition == 2)
                    {
                        while (currentRandPosition == beforeRandPosition)
                        {
                            currentRandPosition = random.Next(0, position.Length);
                        }
                    }
                }
                else
                {
                    samePosition = 0;
                }
                GameObject ship = ships[0];// 배 꺼내기
                ship.gameObject.SetActive(true);
                ships.RemoveAt(0); // 배 List에서 삭제
                ship.transform.position += position[currentRandPosition];// 배 위치 설정
                spawnCount[randType] += 1; // 배 카운트 UP
                beforeRandPosition = currentRandPosition;
            }
            spawnTimer = 0f;
        }
        spawnTimer += Time.deltaTime;

    }

    #region Item
    // 아이템 생성 시간
    void ItemSpawn() 
    {
        timer += Time.deltaTime;

             if (timer >= 50f && timer < 51f) // hel1 출현 
                {
                    ItemCreation(8);
                }
             if (timer >= 92f && timer < 93f) // hel1 출현 
                {
                    isItemCreation = false;
                }
                if (timer >= 93f && timer < 94f) // kit1 출현 
                {
            
                    ItemCreation(10);
                }
         if (timer >= 139f && timer < 140) // hel1 출현 
        {
            isItemCreation = false;
        }

        if (timer >= 140f && timer < 141f) //hel 출현
                {
                    ItemCreation(8);
                }
        if (timer >= 209f && timer < 210) // hel1 출현 
        {
            isItemCreation = false;
        }

            if (timer >= 210f && timer < 211f) //kit2 출현
                {
                    ItemCreation(11);
                }
        if (timer >= 229f && timer < 230) // hel1 출현 
        {
            isItemCreation = false;
        }

        if (timer >= 230f && timer < 231f) //hel 출현
                {
                    ItemCreation(8);
                }
        if (timer >= 259f && timer < 260) // hel1 출현 
        {
            isItemCreation = false;
        }

        if (timer >= 260f && timer < 261f) //kit2 출현
                {
                    ItemCreation(11);
                }

        if (timer >= 389f && timer < 390) // hel1 출현 
        {
            isItemCreation = false;
        }



        if (timer >= 390f && timer < 391f) //hel2 출현
                {
                    ItemCreation(9);
                }
        if (timer >= 429f && timer < 430) // hel1 출현 
        {
            isItemCreation = false;
        }

        if (timer >= 430f && timer < 431f)
                {
                    ItemCreation(10);
                }
        if (timer >= 434f && timer < 435) // hel1 출현 
        {
            isItemCreation = false;
        }
        if (timer >= 435f && timer < 436f)
                {
                    ItemCreation(8);
                }
        if (timer >= 489f && timer < 490) // hel1 출현 
        {
            isItemCreation = false;
        }

        if (timer >= 490f && timer < 491f) //kit2 출현
                {
                    ItemCreation(11);
                }
        if (timer >= 559f && timer < 560) // hel1 출현 
        {
            isItemCreation = false;
        }

        if (timer >= 560f && timer < 561f) //kit2 출현
                {
                    ItemCreation(11);
                }
        if (timer >= 619f && timer < 620) // hel1 출현 
        {
            isItemCreation = false;
        }
        if (timer >= 620f && timer < 621f) //kit2 출현
                {
                    ItemCreation(11);
                }
        if (timer >= 629f && timer < 630) // hel1 출현 
        {
            isItemCreation = false;
        }

        if (timer >= 630f && timer < 631f)  //kit2 출현
                {
                    ItemCreation(9);
                }
        if (timer >= 679f && timer < 680) // hel1 출현 
        {
            isItemCreation = false;
        }
        if (timer >= 680f && timer < 681f)  //kit2 출현
                {
                    ItemCreation(10);
                }
        if (timer >= 739f && timer < 740) // hel1 출현 
        {
            isItemCreation = false;
        }
        if (timer >= 740f && timer < 741f) //kit2 출현
                {
                    ItemCreation(11);
                }
               
        
    }

    //아이템 생성
    void ItemCreation(int type)
    {
        if (isItemCreation == false)
        {
            isItemCreation = true;
            currentRandPosition = Random.Range(0, position.Length);
            GameObject leaveObj = ObjectPool.GetObj(type);
            leaveObj.transform.position = position[currentRandPosition];           
        }
    }
    #endregion
    #endregion
}