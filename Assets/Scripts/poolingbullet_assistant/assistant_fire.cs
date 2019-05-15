using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assistant_fire : MonoBehaviour
{
    public float fireTime = 0.05f;


    void Start()
    {

        InvokeRepeating("Fire", fireTime, fireTime);

    }

    void Fire()
    {
        GameObject obj = newObjectpooling_assistant.assistant.getPooledObject();
        if (obj == null)
        {
            return;
        }
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);


    }
}
