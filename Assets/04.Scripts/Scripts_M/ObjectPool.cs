using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeID
{
    SHIP = 0,
    MOT,
    SUB, 
    HUNT,
    NAVAL,
    TRASH,
    BULLET,
    OIL, 
    HEL1,
    HEL2,
    KIT1,
    KIT2,
    CLOCK, 
}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject[] objPrefab;

    private Queue<GameObject>[] poolingObjQueue = new Queue<GameObject>[13];

    private void Awake()
    {
        Instance = this;

        Initialize(10);
    }

    private GameObject CreateNewObj(int ID)
    {
        GameObject newObj = Instantiate(objPrefab[ID], transform);
        newObj.SetActive(false);
        return newObj;
    }

    private void Initialize(int count)
    {
        for (int i = 0; i < poolingObjQueue.Length; i++)
        {
            poolingObjQueue[i] = new Queue<GameObject>();
            for (int j = 0; j < count; j++)
            {
                poolingObjQueue[i].Enqueue(CreateNewObj(i));
            }
        }
    }

    public static GameObject GetObj(int ID)
    {
        if (Instance.poolingObjQueue[ID].Count > 0)
        {
            GameObject obj = Instance.poolingObjQueue[ID].Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            GameObject newObj = Instance.CreateNewObj(ID);
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObj(GameObject gameObj, int ID)
    {
        gameObj.SetActive(false);
        gameObj.transform.SetParent(Instance.transform);
        Instance.poolingObjQueue[ID].Enqueue(gameObj);
    }

    //게임 메니져에 넣는게 나을 듯
    public static void StopGame()
    {
        GameObject[] enemyObj = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] itemObj = GameObject.FindGameObjectsWithTag("Item");

        for(int i = 0; i < enemyObj.Length; i++)
        {
            enemyObj[i].SetActive(false);
        }
        for (int i = 0; i < itemObj.Length; i++)
        {
            itemObj[i].SetActive(false);
        }
    }

    public static void StartGame()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
}
