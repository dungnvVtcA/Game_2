using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newOfObjectBulletPooling : MonoBehaviour
{
    public static newOfObjectBulletPooling current;

    public GameObject pooledObject;

    public List<GameObject> pooledObjects;

    public int pooledAmount = 1;

    private void Awake()
    {
        current = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        
        for(int i = 0; i <=pooledAmount;i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }
    
    public GameObject getBulletObject()
    {
        
        for (int i = 0; i <pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
         
                return pooledObjects[i];
            }
        }
        
        return null;
    }
}
