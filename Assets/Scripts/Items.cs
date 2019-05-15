using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public float speed = 0.5f;

    Rigidbody2D rid;

    private Vector2 ScreenCamera;

    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        rid.velocity = new Vector2(0, -speed);

        ScreenCamera = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
   

    void Update()
    {
        if (transform.position.y < -ScreenCamera.y)
        {
            Destroy(this.gameObject);
        }


    }
    
}
