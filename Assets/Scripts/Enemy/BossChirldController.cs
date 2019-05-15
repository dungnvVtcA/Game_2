using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChirldController : MonoBehaviour
{
    private Rigidbody2D rigid;

    public GameObject player;

    private float positiony = 0f;

    Vector2 screen;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
       
    }

    // Update is called once per frame
    void Update()
    {
        //if(positiony <= screen.y / 2)
        //{
        //    transform.position = new Vector2(0, --positiony);
        //}
    }
}
