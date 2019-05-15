using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public float speedMove = 0;

    GameObject game;

    private int life = 3000;

    Rigidbody2D rigid;

    private float countPosition = 0.0f;

    Vector2 screen;

    public float width;

    public float height;

    private bool checkLeft;

    private bool checkRight;

    private Vector3 offset;

    private void Awake()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        width = transform.GetComponent<SpriteRenderer>().bounds.extents.x;

        height = transform.GetComponent<SpriteRenderer>().bounds.extents.y;

        checkLeft = true;
        checkRight = false;

        speedMove = 0.5f;

        
    }

    private void Start()
    {
        
        this.gameObject.name = "bossParent";
        game = GameObject.Find("background");

        offset = game.transform.position - this.transform.position;
        


    }
    // Update is called once per frame
    void Update()
    {
        
        if(!GameController.game.isBoss)
        {
            return;
        }
        
       
        countPosition += Time.deltaTime;
        if (transform.position.y >= 2.2)
        {
            
            transform.position = new Vector3(transform.position.x, transform.position.y - (speedMove * Time.deltaTime), transform.position.z);
        }

        if (countPosition > screen.y / 5)
        {
            if (checkLeft)
            {
                //transform.position += new Vector3(-1, -1, 0) * 3f * Time.deltaTime;
                transform.position += new Vector3(-1, 0, 0) * 0.5f * Time.deltaTime;
                game.transform.position += new Vector3(-1, 0, 0) * 20f* Time.deltaTime;
                if (transform.position.x <= -1.5)
                {
                    checkLeft = false;
                    checkRight = true;
                }
            }
            if (checkRight)
            {
                transform.position += new Vector3(1, 0, 0) * 0.5f  * Time.deltaTime;
                game.transform.position += new Vector3(1, 0, 0) * 20f* Time.deltaTime;
                if (transform.position.x >= 1.5)
                {
                    checkLeft = true;
                    checkRight = false;
                }
            }
            
           
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!GameController.game.isBoss)
        {
            return;
        }
        if(collision.tag == "bulletPlayer" )
        {
            collision.gameObject.SetActive(false);
            HP_Boss.health -= 1;
            
            
            life--;
        }
        if(collision.tag == "bulletDouble")
        {
            collision.gameObject.SetActive(false);
            life -= 2;
        }
        if (life == 0)
        {

            Destroy(gameObject);
            collision.gameObject.SetActive(false);
        }
    }


}
