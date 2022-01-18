using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyTool : MonoBehaviour
{
    public Transform[] startPos;
    public Transform[] endPos;

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
            GameObject ship = EnemyCreate(0);
            ship.GetComponent<TestObstacle>().destination = endPos[0].position;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject ship = EnemyCreate(1);
            ship.GetComponent<TestObstacle>().destination = endPos[1].position;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject ship = EnemyCreate(2);
            ship.GetComponent<TestObstacle>().destination = endPos[2].position;
        }
    }
}
