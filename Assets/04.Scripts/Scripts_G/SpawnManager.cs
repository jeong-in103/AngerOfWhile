using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    Vector3[] position = new Vector3[5];

    public GameObject[] enemies;

    public float spawnTimer;
    public float spawnDelay;
    public int[] spawnCount = new int[5];
    public int[] enemyNumber = new int[5];

    [SerializeField]
    private int type;

    [SerializeField]
    private int level = 1;
    private int levelBefore = 1;

    public float timer = 0f;
    public bool isSpawn = false;


    // Start is called before the first frame update
    void Start()
    {
        CreatePosition();
    }



    void CreatePosition() //G:���� ������ ��ġ��
    {

        float viewPosZ = -30f;
        float gapX = 1f / 6f;
        float viewPosX = 0f;

        for (int i = 0; i < position.Length; i++)
        {

            viewPosX = gapX + gapX * i;

            Vector3 viewPos = new Vector3(viewPosX, 0, viewPosZ);

            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            //worldPos.y = -0.2f;
            worldPos.y = -1f;

            position[i] = worldPos;
        }

    }
    #region ������ ���� ����
    void StartSpawn() //G: �� ���� ����
    {
        timer += Time.deltaTime;



        if (isSpawn == true)
        {
            if (level < 12)
            {
                LevelUpdate();
                LevelControl();
            }
            //------------------------------------------ ���̵� 1

            if (timer >= 60) //Mot ���� 
            {

                level = 2;
            }
            //------------------------------------------- ���̵� 2    

            if (timer >= 125) //sub ����
            {

                level = 3;
            }
            //-------------------------------------------- ���̵� 3
            if (timer >= 180)
            {

                level = 4;
            }
            //-------------------------------------------- ���̵� 4
            if (timer >= 240) // Naval ���� 
            {

                level = 5;
            }
            //-------------------------------------------- ���̵� 5
            if (timer >= 300) // Naval ���� 
            {
                level = 6;
            }
            //-------------------------------------------- ���̵� 6
            if (timer >= 360) // Naval ���� 
            {
                level = 7;
            }
            //-------------------------------------------- ���̵� 7
            if (timer >= 420) // Naval ���� 
            {
                level = 8;
            }
            //-------------------------------------------- ���̵� 8
            if (timer >= 483) // Naval ���� 
            {
                level = 9;
            }
            //-------------------------------------------- ���̵� 9
            if (timer >= 543) // Naval ���� 
            {
                level = 10;
            }
            //-------------------------------------------- ���̵� 10
            if (timer >= 600) // Naval ���� 
            {
                level = 11;
            }
            if(timer >= 780)
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
            //------------------------------------------ ���̵� 1
            case 1:
                spawnDelay = 3.1f;
                enemyNumber[0] = 20;
                Spawn(0); //Ship ����
                break;

            case 2:
                spawnDelay = 3.7f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 7;
                Spawn(1);  //Mot ����
                break;
            //------------------------------------------- ���̵� 2  
            case 3:
                spawnDelay = 3.1f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 3;
                enemyNumber[2] = 5;
                Spawn(2);  //sub ����          
                break;
            //-------------------------------------------- ���̵� 3
            case 4:
                spawnDelay = 2.8f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 6;
                enemyNumber[2] = 5;
                Spawn(2);
                break;
            //-------------------------------------------- ���̵� 4
            case 5:
                spawnDelay = 3.05f;
                enemyNumber[0] = 8;
                enemyNumber[1] = 7;
                enemyNumber[2] = 5;
                Spawn(2);
                break;
            //-------------------------------------------- ���̵� 5
            case 6:
                spawnDelay = 3.2f;
                enemyNumber[0] = 5;
                enemyNumber[1] = 8;
                enemyNumber[2] = 5;
                Spawn(2);
                break;
            //-------------------------------------------- ���̵� 6
            case 7:
                spawnDelay = 2.6f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 8;
                enemyNumber[2] = 2;
                enemyNumber[3] = 3;
                Spawn(3); // Hunt ����
                break;
            //-------------------------------------------- ���̵� 7
            case 8:
                spawnDelay = 2.4f;
                enemyNumber[0] = 10;
                enemyNumber[1] = 8;
                enemyNumber[2] = 5;
                enemyNumber[3] = 3;
                Spawn(3);
                break;
            //-------------------------------------------- ���̵� 8
            case 9:
                spawnDelay = 2.95f;
                enemyNumber[0] = 0;
                enemyNumber[1] = 10;
                enemyNumber[2] = 2;
                enemyNumber[3] = 5;
                enemyNumber[4] = 3;
                Spawn(4); // Naval ����
                break;
            //-------------------------------------------- ���̵� 9
            case 10:
                spawnDelay = 2.55f;
                enemyNumber[0] = 0;
                enemyNumber[1] = 10;
                enemyNumber[2] = 4;
                enemyNumber[3] = 5;
                enemyNumber[4] = 3;
                Spawn(4); 
                break;
            //-------------------------------------------- ���̵� 10
            case 11:
                spawnDelay = 3.0f;
                enemyNumber[0] = 15;
                enemyNumber[1] = 20;
                enemyNumber[2] = 5;
                enemyNumber[3] = 10;
                enemyNumber[4] = 10;
                Spawn(4); 
                break;
            case 12:
                GameObject.Find("FadeOut").GetComponent<FadeOut>().StartFadeAnim();
                level++;
                break;
        }
    }

    void Spawn(int type) //Spawn �߽����κ�
    {

        if (spawnTimer > spawnDelay)
        {

            int randPosition = Random.Range(0, position.Length);
            int randType = Random.Range(0, type + 1);
            int randType2 = Random.Range(0, type + 1);
            if (spawnCount[randType] < enemyNumber[randType])
            {
                Instantiate(enemies[randType], position[randPosition], Quaternion.identity);
                spawnCount[randType] += 1;
            }
            else { 
                while (randType == randType2 || spawnCount[randType2] == enemyNumber[randType2])
                {
                    randType2 = Random.Range(0, type + 1);
                }
                Instantiate(enemies[randType2], position[randPosition], Quaternion.identity);
                spawnCount[randType2] += 1;
                randType = randType2;
            }
           

            spawnTimer = 0f;

        }
        spawnTimer += Time.deltaTime;

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
        if(level<13)
         StartSpawn();
        
    }
}
