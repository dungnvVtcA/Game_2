using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;

    public Transform circel;

    public Transform outCircel;

    public float speed = 5.0f;

    private bool touchStart;

    private Vector2 pointA;

    private Vector2 pointB;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            circel.transform.position = pointA * 1;
            //outCircel.transform.position = pointB * 1;
            //circel.GetComponent<SpriteRenderer>().enabled = true;
            //outCircel.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
      
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
           
            touchStart = false;
        }
    }
    
    void FixedUpdate()
    {
        if(touchStart)
        {
           
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            MoveCharacter(direction * 1);
            circel.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) *1;
            outCircel.transform.position = new Vector2(pointA.x, pointA.y);
        }
        else
        {
            circel.GetComponent<SpriteRenderer>().enabled = false;
            outCircel.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void MoveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
