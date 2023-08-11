using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public ScriptableItem scriptableItem;
        public int size;
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> _poolDictionary;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.scriptableItem.itemPrefab);

                IItem objectItem = obj.GetComponent<Item>();
                if (objectItem != null)
                {
                    objectItem.ClicksNeeded = pool.scriptableItem.clicksNeeded;
                    objectItem.ItemAddScore = pool.scriptableItem.clickedScore;
                    objectItem.ItemPointLoss = pool.scriptableItem.pointLoss;
                    objectItem.ItemLifeSpan = pool.scriptableItem.lifeSpan;
                }

                objectPool.Enqueue(obj);
                obj.SetActive(false);
            }

            _poolDictionary.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " does not exist.");
            return null;
        }

        GameObject objectToSpawn = _poolDictionary[tag].Dequeue();

        IItem objectItem = objectToSpawn.GetComponent<Item>();

        objectItem?.OnItemSpawn(true, position, rotation);

        _poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}