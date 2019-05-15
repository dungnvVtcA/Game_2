using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    public float fireTime = 5.0f;
    void Start()
    {
        //return;
        InvokeRepeating("fire", fireTime, fireTime);
    }   
    private void fire()
    {
        GameObject obj = newPoolingObjectBulletBoos.boss.GetpooledObject();
        if(!obj)
        {
            return;
        }
        obj.transform.position = transform.position;
        obj.SetActive(true);
    }
}
