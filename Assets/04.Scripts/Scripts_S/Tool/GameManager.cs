using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static int score;
    public static float angerValue;
    public static int bestScore;
    public static bool delete = false;

    public static void StopGame()
    {
        GameObject[] enemyObj = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] itemObj = GameObject.FindGameObjectsWithTag("Item");

        for (int i = 0; i < enemyObj.Length; i++)
        {
            enemyObj[i].SetActive(false);
        }
        for (int i = 0; i < itemObj.Length; i++)
        {
            itemObj[i].SetActive(false);
        }
    }
}