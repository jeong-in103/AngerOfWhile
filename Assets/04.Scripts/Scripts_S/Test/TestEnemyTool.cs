using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyTool : MonoBehaviour
{
    public Transform[] startPos;

    public GameObject[] enemies;

    private GameObject enemyParent;
    private GameObject clone;

    private void Start()
    {
        if (enemyParent != null)
        {
            enemyParent = new GameObject("enemyParent");
        }
    }

    private void Update()
    {
        EnemyStart();
    }

    private GameObject EnemyCreate(int num)
    {
        clone = Instantiate(enemies[Random.Range(0,3)], startPos[num].position, Quaternion.identity);
        return clone;
    }

    private void EnemyStart()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EnemyCreate(0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            EnemyCreate(1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            EnemyCreate(2);
        }
    }
}
