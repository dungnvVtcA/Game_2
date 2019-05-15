using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newObjectpoolerScript : MonoBehaviour
{
    public static newObjectpoolerScript current;

    public int Amountbullet = 20;

    public bool willGrow = true;

    private GameObject pooledObject;

    private GameObject pooledObjectdouble;

    private List<GameObject> pooledObjects;

    private List<GameObject> pooledObjectDoubleBullets;
    // wait for fix code
    private List<List<GameObject>> pooledObject_;

    private string[] pathResources = {
        "bullet/bullet",
        "bullet/bulletLvel_2"
    };

    private void Awake()
    {
        current = this;
        pooledObject_ = new List<List<GameObject>>();
    }
    void Start()
    {
        this.Init();
    }
    private void Init()
    {
        // load bullet2
        pooledObjectdouble = Instantiate(UnityEngine.Resources.Load("bullet/bulletLvel_2")) as GameObject;
        pooledObjectDoubleBullets = new List<GameObject>();
        for (int i = 0; i < Amountbullet; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObjectdouble);
            pooledObjectdouble.SetActive(false);
            pooledObjectDoubleBullets.Add(obj);
        }
        pooledObject = Instantiate(UnityEngine.Resources.Load("bullet/bullet")) as GameObject;
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < Amountbullet; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObject.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject getPooledObject(int currenBullet)
    {
        if(currenBullet == 1)
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            if (willGrow)
            {
                GameObject obj = (GameObject)Instantiate(pooledObject);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        if(currenBullet == 2)
        {
            for (int i = 0; i < pooledObjectDoubleBullets.Count; i++)
            {
                if (!pooledObjectDoubleBullets[i].activeInHierarchy)
                {
                    return pooledObjectDoubleBullets[i];
                }
            }
            if (willGrow)
            {
                GameObject obj = (GameObject)Instantiate(pooledObjectdouble);
                pooledObjectDoubleBullets.Add(obj);
                return obj;
            }
        }
        return null;
    }

    
}
