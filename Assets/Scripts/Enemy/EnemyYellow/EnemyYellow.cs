using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellow : MonoBehaviour
{
    public static EnemyYellow enemy_yellow;

    public int maxEnemy = 20;

    public int life = 100;

    private GameObject player;

    private Vector3 pos;

    private float distance = 0.0f;

    private bool shoot = false;

    private float speed = 2.0f;
    private void Awake()
    {
        enemy_yellow = this;
    }
    void Start()
    {
        this.Init();
    }
    private void Init()
    {
        this.gameObject.name = "EnemyYellow";
        player = GameObject.Find("player");
    }
    // Update is called once per frame
    void Update()
    {
        if(life > 0 && player)
        {
            pos = new Vector3(transform.position.x, transform.position.y + -0.2f * Time.deltaTime, transform.position.z);
            distance = Vector2.Distance(transform.position, player.transform.position);
            if(distance < 5)
            {
                
                transform.position = Vector2.MoveTowards(transform.position, pos, 0.02f);
            }
            else
            {
               
                transform.position = Vector2.MoveTowards(transform.position, pos, 0.05f);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bulletPlayer")
        {
            life--;
            collision.gameObject.SetActive(false);
            
        }else if(collision.tag == "bulletDouble")
        {
            life -= 2;
            collision.gameObject.SetActive(false);
        }
        if (life == 0)
        {
            GameController.game.CountEnemyYellowDead++;
            Destroy(gameObject);
            collision.gameObject.SetActive(false);
        }
    }

}
