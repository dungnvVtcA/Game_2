using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScrolling : MonoBehaviour
{
    public float speed = 2.0f;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
    }
}
