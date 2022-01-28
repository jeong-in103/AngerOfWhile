using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private static Vector3[] position = new Vector3[5];

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
    private int[] samePosition = new int[5];

    [SerializeField]
    private int type;

    // public int positionRand = 0;
    public float timer = 0f;
    public bool isSpawn = false;
    public bool isItemCreation = false;

    public GameObject FadeOut;

    public int randType;
    public int randType2;
    public int currentRandPosition;
    private float deleteTimer = 10f;
    private float deleteTime = 0f;
    // S 
    [SerializeField]
    private int level = 1;
    public int developLevel;
    public int[] levelTimes = new int[13];
    private List<GameObject> ships = new List<GameObject>();
    private System.Random random;
    private List<int> curPosition = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        WorldPositionInit();
    }

    void Update()
    {
        //개발용 Levle 설정
        if (developLevel != 0)
        {
            level = developLevel - 1;
            timer = levelTimes[developLevel - 1];
            ships.Clear();
            developLevel = 0;
        }
        //현재 Level에서 배들이 다 나왔을 경우
        if (ships.Count == 0 && !GameManager.endGame)
        {
            level++;
            LevelUpSetting(level);
            SpawnDelay(level);
        }

        if (level < 14)
        {
            EnemySpawn(); //적 생성
            ItemSpawn(level);  //아이템 생성
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
                enemyNumber[0] = 10;
                enemyNumber[1] = 3;
                SpawnCountInit();
                ships.Clear();
                shipsReady(0);
                shipsReady(1);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;

            case 2:
                timer = 30f;

                enemyNumber[0] = 6;
                enemyNumber[2] = 5;
                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(2);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;
            //------------------------------------------- 난이도 2  
            case 3:
                timer = 60f;

                enemyNumber[0] = 8;
                enemyNumber[1] = 3;
                enemyNumber[2] = 10;

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
                timer = 125f;

                enemyNumber[0] = 5;
                enemyNumber[1] = 5;
                enemyNumber[2] = 13;
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
                timer = 180f;

                enemyNumber[0] = 5;
                enemyNumber[1] = 3;
                enemyNumber[2] = 10;
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
            //-------------------------------------------- 난이도 5
            case 6:
                timer = 240f;

                enemyNumber[0] = 5;
                enemyNumber[1] = 3;
                enemyNumber[2] = 10;
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
            //-------------------------------------------- 난이도 6
            case 7:
                timer = 300f;

                enemyNumber[0] = 3;
                enemyNumber[1] = 5;
                enemyNumber[2] = 10;
                enemyNumber[3] = 6;

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
                timer = 360f;

                enemyNumber[0] = 5;
                enemyNumber[1] = 5;
                enemyNumber[2] = 5;
                enemyNumber[3] = 10;

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
                timer = 420f;

                enemyNumber[0] = 0;
                enemyNumber[1] = 5;
                enemyNumber[2] = 10;
                enemyNumber[3] = 10;

                SpawnCountInit();

                ships.Clear();
                shipsReady(0);
                shipsReady(1);
                shipsReady(2);
                shipsReady(3);

                random = new System.Random();
                ships = Shuffle.ShufflEnmey<List<GameObject>>(ships, level);
                break;
            //-------------------------------------------- 난이도 9
            case 10:
                timer = 480f;

                enemyNumber[0] = 0;
                enemyNumber[1] = 2;
                enemyNumber[2] = 10;
                enemyNumber[3] = 5;
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
            //-------------------------------------------- 난이도 10
            case 11:
                timer = 540f;

                enemyNumber[0] = 0;
                enemyNumber[1] = 4;
                enemyNumber[2] = 10;
                enemyNumber[3] = 5;
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
                timer = 600f;

                enemyNumber[0] = 3;
                enemyNumber[1] = 10;
                enemyNumber[2] = 8;
                enemyNumber[3] = 10;
                enemyNumber[4] = 13;

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
            case 13:
                timer = 780f;

                enemyNumber[0] = 3;
                enemyNumber[1] = 10;
                enemyNumber[2] = 12;
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

            case 14:
                GameManager.endGame = true;
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


                currentRandPosition = random.Next(0, position.Length);
                int a = currentRandPosition;
                if (samePosition[currentRandPosition] + 1 >= 4)
                {
                    while (true)
                    {
                        currentRandPosition = random.Next(0, position.Length);
                        if (currentRandPosition == a)
                            continue;
                        else
                            break;
                    }

                }
                samePosition[currentRandPosition] += 1;
                curPosition.Add(currentRandPosition);
                GameObject ship = ships[0];// 배 꺼내기
                ship.gameObject.SetActive(true);
                ships.RemoveAt(0); // 배 List에서 삭제
                ship.transform.position += position[currentRandPosition];// 배 위치 설정
                spawnCount[randType] += 1; // 배 카운트 UP
                if (GameManager.delete == true)
                {
                    DeletePosition();
                }
            }
            spawnTimer = 0f;
            SpawnDelay(level);
        }
        spawnTimer += Time.deltaTime;

    }
    public void DeletePosition()
    {
        samePosition[curPosition[0]] -= 1;
        curPosition.RemoveAt(0);
        GameManager.delete = false;
    }

    void SpawnDelay(int level)
    {
        switch (level)
        {
            case 1:
                spawnDelay = Random.Range(2.0f, 2.6f);
                break;
            case 2:
                spawnDelay = Random.Range(2.4f, 3.0f);
                break;
            case 3:
                spawnDelay = Random.Range(2.5f, 3.1f);
                break;
            case 4:
                spawnDelay = Random.Range(2.01f, 2.6f);
                break;
            case 5:
                spawnDelay = Random.Range(2.3f, 3.3f);
                break;
            case 6:
                spawnDelay = Random.Range(2.5f, 3.1f);
                break;
            case 7:
                spawnDelay = Random.Range(2.2f, 2.8f);
                break;
            case 8:
                spawnDelay = Random.Range(2.1f, 2.7f);
                break;
            case 9:
                spawnDelay = Random.Range(2.1f, 2.7f);
                break;
            case 10:
                spawnDelay = Random.Range(1.9f, 2.5f);
                break;
            case 11:
                spawnDelay = Random.Range(1.7f, 2.3f);
                break;
            case 12:
                spawnDelay = Random.Range(3.7f, 4.3f);
                break;
            case 13:
                spawnDelay = Random.Range(2.3f, 2.9f);
                break;
            case 14:

                break;
        }

    }
    #region Item
    // 아이템 생성 시간
    void ItemSpawn(int level)
    {
        timer += Time.deltaTime;
        switch (level)
        {

            //난이도 1
            case 1:
                if (timer >= 20f && timer < 21f)
                {
                    ItemCreation(10);
                }
                break;
            case 2:

                if (timer >= 50f && timer < 51f)
                {
                    ItemCreation(8);
                }
                break;

            //난이도 2
            case 3:
                if (timer >= 80f && timer < 81f)
                {
                    ItemCreation(10);
                }

                if (timer >= 94f && timer < 95f)
                {
                    ItemCreation(10);
                }
                if (timer >= 110f && timer < 111f)
                {
                    ItemCreation(10);
                }
                break;
            //난이도 3
            case 4:
                if (timer >= 140f && timer < 141f)
                {
                    ItemCreation(8);
                }
                break;
            //난이도 4
            case 5:
                if (timer >= 210f && timer < 211f)
                {
                    ItemCreation(11);
                }

                if (timer >= 230f && timer < 231f)
                {
                    ItemCreation(8);
                }
                break;

            //난이도 5
            case 6:
                if (timer >= 260f && timer < 261f)
                {
                    ItemCreation(11);
                }
                if (timer >= 290f && timer < 291f)
                {
                    ItemCreation(8);
                }
                break;
            //난이도 6
            case 7:
                break;
            //난이도 7
            case 8:
                if (timer >= 360f && timer < 361f)
                {
                    ItemCreation(10);
                }
                if (timer >= 390f && timer < 391f)
                {
                    ItemCreation(9);
                }
                break;
            //난이도 8
            case 9:
                if (timer >= 430f && timer < 431f)
                {
                    ItemCreation(10);
                }

                if (timer >= 435f && timer < 436f)
                {
                    ItemCreation(8);
                }
                if (timer >= 465f && timer < 467)
                {
                    ItemCreation(8);
                }
                break;
            //난이도 9
            case 10:
                if (timer >= 490f && timer < 491f)
                {
                    ItemCreation(11);
                }
                if (timer >= 510f && timer < 511f)
                {
                    ItemCreation(11);
                }
                break;
            //난이도 10
            case 11:
                if (timer >= 560f && timer < 561f)
                {
                    ItemCreation(11);
                }
                if (timer >= 580f && timer < 581f)
                {
                    ItemCreation(8);
                }
                break;
            //난이도 11
            case 12:
                if (timer >= 620f && timer < 621f)
                {
                    ItemCreation(11);
                }

                if (timer >= 630f && timer < 631f)
                {
                    ItemCreation(9);
                }

                if (timer >= 680f && timer < 681f)
                {
                    ItemCreation(10);
                }

                if (timer >= 740f && timer < 741f)
                {
                    ItemCreation(11);
                }
                break;
            //난이도 12
            case 13:
                if (timer >= 790f && timer < 791f)
                {
                    ItemCreation(10);
                }
                if (timer >= 840f && timer < 841f)
                {
                    ItemCreation(10);
                }
                if (timer >= 810f && timer < 811f)
                {
                    ItemCreation(8);
                }
                if (timer >= 870f && timer < 871f)
                {
                    ItemCreation(11);
                }
                break;
            case 14:
                break;
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
                Invoke("ItemFalse", 4f);
            }
        }

        void ItemFalse()
        {
            isItemCreation = false;
        }
        #endregion
        #endregion
    }
}