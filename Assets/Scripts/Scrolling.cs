using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    Rigidbody2D rigid;

    public float speed = -2.0f;
    void Start()
    {
        //rigid = GetComponent<Rigidbody2D>();
       // rigid.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y+ speed*Time.deltaTime, transform.position.z);
    }
}
