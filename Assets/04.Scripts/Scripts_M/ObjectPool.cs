using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    //[System.Serializable]
    //private struct PoolData
    //{
    //    public string type;
    //    public Queue<GameObject> objQueue;
    //}

    //[SerializeField]
    //private GameObject[] objPrefab;

    [SerializeField]
    private GameObject shipPrefab;
    [SerializeField]
    private GameObject subPrefab;
    [SerializeField]
    private GameObject motPrefab;
    [SerializeField]
    private GameObject huntPrefab;
    [SerializeField]
    private GameObject navalPrefab;

    [Header ("Attack Object Prefab")]
    [SerializeField]
    private GameObject trashPrefab;
    [SerializeField]
    private GameObject bulletPrefab;

    //[Header("Item Object Prefab")]
    //[SerializeField]
    //private GameObject Hel1Prefab;
    //[SerializeField]
    //private GameObject Hel2Prefab;
    //[SerializeField]
    //private GameObject Kit1Prefab;
    //[SerializeField]
    //private GameObject Kit2Prefab;
    //[SerializeField]
    //private GameObject ClockPrefab;

    //[SerializeField]
    //private List<PoolData> poolingObjQueue = new List<PoolData>();

    private Queue<GameObject> shipQueue = new Queue<GameObject>();
    private Queue<GameObject> subQueue = new Queue<GameObject>();
    private Queue<GameObject> motQueue = new Queue<GameObject>();
    private Queue<GameObject> huntQueue = new Queue<GameObject>();
    private Queue<GameObject> navalQueue = new Queue<GameObject>();

    private Queue<GameObject> trashQueue = new Queue<GameObject>();
    private Queue<GameObject> bulletQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;

        Initialize(10);
    }

    #region Create Object
    //private GameObject CreateNewObj(int ID)
    //{
    //    GameObject newObj = Instantiate(objPrefab[ID], transform);
    //    newObj.SetActive(false);
    //    return newObj;
    //}

    private GameObject CreateShipObject()
    {
        GameObject shipObj = Instantiate(shipPrefab, transform);
        shipObj.SetActive(false);
        return shipObj;
    }

    private GameObject CreateSubObject()
    {
        GameObject subObj = Instantiate(subPrefab, transform);
        subObj.SetActive(false);
        return subObj;
    }

    private GameObject CreateMotObject()
    {
        GameObject motObj = Instantiate(motPrefab, transform);
        motObj.SetActive(false);
        return motObj;
    }

    private GameObject CreateHuntObject()
    {
        GameObject shipObj = Instantiate(huntPrefab, transform);
        huntPrefab.SetActive(false);
        return huntPrefab;
    }

    private GameObject CreateNavalObject()
    {
        GameObject shipObj = Instantiate(navalPrefab, transform);
        navalPrefab.SetActive(false);
        return navalPrefab;
    }

    private GameObject CreateTrashObject()
    {
        GameObject trashObj = Instantiate(trashPrefab, transform);
        trashObj.SetActive(false);
        return trashObj;
    }

    private GameObject CreateBulletObject()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, transform);
        bulletObj.SetActive(false);
        return bulletObj;
    }
    #endregion

    private void Initialize(int count)
    {
        //for(int i = 0; i < poolingObjQueue.Count; i++)
        //{
        //    for(int j = 0; j < count; j++)
        //    {
        //        poolingObjQueue[i].objQueue.Enqueue(CreateNewObj(i));
        //    }
        //    shipQueue.Enqueue(CreateShipObject());
        //    subQueue.Enqueue(CreateShipObject());
        //    motQueue.Enqueue(CreateShipObject());
        //    huntQueue.Enqueue(CreateShipObject());
        //    navalQueue.Enqueue(CreateShipObject());
        //    trashQueue.Enqueue(CreateTrashObject());
        //    bulletQueue.Enqueue(CreateBulletObject());
        //}

        for (int j = 0; j < count; j++)
        {
            shipQueue.Enqueue(CreateShipObject());
            subQueue.Enqueue(CreateShipObject());
            motQueue.Enqueue(CreateShipObject());
            huntQueue.Enqueue(CreateShipObject());
            navalQueue.Enqueue(CreateShipObject());
            trashQueue.Enqueue(CreateTrashObject());
            bulletQueue.Enqueue(CreateBulletObject());
        }
    }

    #region Get Object
    //public static GameObject GetObj(string ID)
    //{
    //    if(Instance.poolingObjQueue.Find(ID).)
    //}

    public static GameObject GetObject(string ID)
    {
        GameObject obj;
        GameObject newObj;

        switch (ID)
        {
            case "SHIP":
                if(Instance.shipQueue.Count > 0)
                {
                    obj = Instance.shipQueue.Dequeue();
                    obj.transform.SetParent(null);
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                else
                {
                    newObj = Instance.CreateShipObject();
                    newObj.transform.SetParent(null);
                    newObj.gameObject.SetActive(true);
                    return newObj;
                }
            case "SUB":
                if (Instance.subQueue.Count > 0)
                {
                    obj = Instance.subQueue.Dequeue();
                    obj.transform.SetParent(null);
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                else
                {
                    newObj = Instance.CreateSubObject();
                    newObj.transform.SetParent(null);
                    newObj.gameObject.SetActive(true);
                    return newObj;
                }
            case "MOT":
                if (Instance.motQueue.Count > 0)
                {
                    obj = Instance.motQueue.Dequeue();
                    obj.transform.SetParent(null);
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                else
                {
                    newObj = Instance.CreateMotObject();
                    newObj.transform.SetParent(null);
                    newObj.gameObject.SetActive(true);
                    return newObj;
                }
            case "HUNT":
                if (Instance.huntQueue.Count > 0)
                {
                    obj = Instance.huntQueue.Dequeue();
                    obj.transform.SetParent(null);
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                else
                {
                    newObj = Instance.CreateHuntObject();
                    newObj.transform.SetParent(null);
                    newObj.gameObject.SetActive(true);
                    return newObj;
                }
            case "NAVAL":
                if (Instance.navalQueue.Count > 0)
                {
                    obj = Instance.navalQueue.Dequeue();
                    obj.transform.SetParent(null);
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                else
                {
                    newObj = Instance.CreateNavalObject();
                    newObj.transform.SetParent(null);
                    newObj.gameObject.SetActive(true);
                    return newObj;
                }
            case "TRASH":
                if (Instance.trashQueue.Count > 0)
                {
                    obj = Instance.trashQueue.Dequeue();
                    obj.transform.SetParent(null);
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                else
                {
                    newObj = Instance.CreateTrashObject();
                    newObj.transform.SetParent(null);
                    newObj.gameObject.SetActive(true);
                    return newObj;
                }
            case "BULLET":
                if (Instance.bulletQueue.Count > 0)
                {
                    obj = Instance.bulletQueue.Dequeue();
                    obj.transform.SetParent(null);
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                else
                {
                    newObj = Instance.CreateBulletObject();
                    newObj.transform.SetParent(null);
                    newObj.gameObject.SetActive(true);
                    return newObj;
                }
            default:
                return null;
        }
    }
    #endregion

    #region Return Object
    public static void ReturnObject(GameObject gameObject, string ID)
    {
        switch (ID)
        {
            case "SHIP":
                gameObject.SetActive(false);
                gameObject.transform.SetParent(Instance.transform);
                Instance.shipQueue.Enqueue(gameObject);
                break;
            case "SUB":
                gameObject.SetActive(false);
                gameObject.transform.SetParent(Instance.transform);
                Instance.subQueue.Enqueue(gameObject);
                break;
            case "MOT":
                gameObject.SetActive(false);
                gameObject.transform.SetParent(Instance.transform);
                Instance.motQueue.Enqueue(gameObject);
                break;
            case "HUNT":
                gameObject.SetActive(false);
                gameObject.transform.SetParent(Instance.transform);
                Instance.huntQueue.Enqueue(gameObject);
                break;
            case "NAVAL":
                gameObject.SetActive(false);
                gameObject.transform.SetParent(Instance.transform);
                Instance.navalQueue.Enqueue(gameObject);
                break;
            case "TRASH":
                gameObject.SetActive(false);
                gameObject.transform.SetParent(Instance.transform);
                Instance.trashQueue.Enqueue(gameObject);
                break;
            case "BULLET":
                gameObject.SetActive(false);
                gameObject.transform.SetParent(Instance.transform);
                Instance.bulletQueue.Enqueue(gameObject);
                break;
            default:
                break;
        }
    }
    #endregion
}
