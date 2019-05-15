using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newObjectpooling_assistant : MonoBehaviour
{
    public static newObjectpooling_assistant assistant;

    public GameObject pooledObject;

    public int pooledAmount = 1;

    public List<GameObject> pooledObjects;

    private void Awake()
    {
        assistant = this;
    }


    void Start()
    {

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObject.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject getPooledObject()
    {
        if(GameController.game.GetLisEnemy().Count > 0)
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
        }
        Debug.Log(pooledObjects.Count);
        return null;
    }
}
