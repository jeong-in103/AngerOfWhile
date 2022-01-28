using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shuffle
{
    public static List<GameObject> ShufflEnmey<T>(List<GameObject> list)
    {
        System.Random prng = new System.Random();

        for (int i = 0; i < list.Count - 1; i++)
        {
            int randomIndex = prng.Next(i, list.Count);
            GameObject tempItem = list[randomIndex];
            list[randomIndex] = list[i];
            list[i] = tempItem;
        }
        return list;
    }
}
