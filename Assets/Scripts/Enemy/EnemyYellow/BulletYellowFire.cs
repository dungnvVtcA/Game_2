using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletYellowFire : MonoBehaviour
{
    public float timeFire = 5.0f;

    void Start()
    {
        InvokeRepeating("fire", timeFire, 0.016f);
    }

    private void fire()
    {
        GameObject obj = newOfObjectBulletPooling.current.getBulletObject();
        if (obj == null)
        {
            return;
        }
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}
