using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStar : MonoBehaviour
{

    public static EnemyStar enemySmall;

    public int life = 40;


    private GameObject player;

    private Vector3 vec;

    private bool startGo ;

    public float speed;

    private float active;

    private float activeAcount;

    public LayerMask bulletPlayer;

    private RaycastHit2D hit;

    private void Awake()
    {
        enemySmall = this;
        startGo = false;
        speed = 0;
        active = 0;
        activeAcount = 0;
        
    }

    void Start()
    {
        Init();
    }

    private void Init()
    {
        active = Random.Range(0.1f, 1);
        this.gameObject.name = "EnemyStar";
        speed = Random.Range(0.03f, 0.06f);
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if( life > 0 && player!= null)
        {
            if(!startGo)
            {
                startGo = true;
                Invoke("Go", active);
    
            }
            // move to position player;
            transform.position = Vector2.MoveTowards(transform.position, vec, speed);
        }
        //EnemyDead();
    }
    private void EnemyDead()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, bulletPlayer);
      
        if (hit.collider!= null)
        {
            Destroy(this.gameObject);
            hit.collider.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bulletPlayer")
        {
      
            life--;
            other.gameObject.SetActive(false);
            if(life == 0)
            {
                for (int i = 0; i < GameController.game.GetLisEnemy().Count; i++)
                {
                    if (transform.position == GameController.game.GetLisEnemy()[i].transform.position)
                    {
                        //bulletAssistant.bulletASS.setGameObject(null);
                        GameController.game.GetLisEnemy().RemoveAt(i);
                    }
                }
            }

        }
        else if(other.tag =="bulletDouble")
        {
            other.gameObject.SetActive(false);
            life -= 2;
        }
        if (life == 0)
        {
            GameController.game.CountEnemySmallDead++;
            GameController.game.DestroyEnemy(transform.position.x, transform.position.y);
            Destroy(this.gameObject);
            other.gameObject.SetActive(false);
        }
        if(other.tag == "bulletAssistant")
        {
            life--;
            other.gameObject.SetActive(false);
            if(life == 0)
            {
                for (int i = 0; i < GameController.game.GetLisEnemy().Count; i++)
                {
                    if (transform.position == GameController.game.GetLisEnemy()[i].transform.position)
                    {
                        //bulletAssistant.bulletASS.setGameObject(null);
                        GameController.game.GetLisEnemy().RemoveAt(i);
                    }
                }
            }
        }


    }
    private void Go()
    {
        startGo = false;
        if(player)
        {
            vec = player.transform.position;
        }
    }
}
