using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPoolingObjectBulletBoos : MonoBehaviour
{
    public static newPoolingObjectBulletBoos boss;

    public GameObject poolingObject;

    public List<GameObject> poolingObjects;

    public int pooledAmount = 2;



    private void Awake()
    {
        boss = this;
    }
    private void Start()
    {
        poolingObjects = new List<GameObject>();
        Init();
    }
    private void Init()
    {
       
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(poolingObject);
            obj.SetActive(false);
            poolingObjects.Add(obj);
        }
    }
    public GameObject GetpooledObject()
    {
        for (int i = 0; i < poolingObjects.Count; i++)
        {
            if (!poolingObjects[i].activeInHierarchy)
            {
                return poolingObjects[i];
            }
        }
        return null;
    }
}