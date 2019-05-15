using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemyStar : MonoBehaviour
{
    private float speed = 6.0f;

    Vector2 screen;

    public LayerMask LayerPlayer;

    RaycastHit2D hit;

    private void Awake()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        GameObject player = GameObject.Find("player");

        GameObject EnemyStar = GameObject.Find("EnemyYellow");
        if(EnemyStar)
        {
            if (EnemyStar.transform.position.y > player.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            hit = Physics2D.Raycast(transform.position, Vector2.up, LayerPlayer);
            if (!hit.collider)
            {
                PlayerController.instal.life--;
            }
        }
        

    }
}
