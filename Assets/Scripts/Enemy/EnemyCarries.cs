using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarries : MonoBehaviour
{
    public static EnemyCarries intal;

    public int life = 100;

    private GameObject player;

    private Vector3 vec;

    public float speed = 0;

    public  int maxEnemy = 10;

    private bool startGo;

    private float active;

    private float activeAcount;


    private void Awake()
    {
        active = 0;

        intal = this;
        this.startGo = false;

        activeAcount = 0;
    }
    
    void Start()
    {
        this.Init();
    }

    private void Init()
    {
        active = Random.Range(0.1f, 1);
        this.gameObject.name = "EnemyCarries";
        speed = Random.Range(0.02f, 0.03f);
        player = GameObject.Find("player");
    }
    
    void Update()
    {
        if(life > 0 && player!= null)
        {
            if(!startGo)
            {
                startGo = true;
                Invoke("go", active);
            }
            transform.position = Vector2.MoveTowards(transform.position, vec, speed);
        }
    }
    private void go()
    {
        startGo = false;
        if(player)
        {
            vec = player.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bulletPlayer")
        {
            collision.gameObject.SetActive(false);
            life--;
        }
        if(collision.tag =="bulletDouble")
        {
            life -= 2;
            collision.gameObject.SetActive(false);
        }
        if (life == 0)
        {
            GameController.game.CountEnemyCarriesDead++;
            Destroy(gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
