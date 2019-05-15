using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public  int life = 5;

    public static PlayerController instal;

    private float SpeedMove = 30.0f;

    private Vector2 direction;

    private Vector3 mousePositon;

    public Transform assistant;

    Rigidbody2D rigid;

    public LayerMask EnemySmall;

    RaycastHit2D Hit;
    private void Awake()
    {
        instal = this;
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        this.gameObject.name = "player";
    }

    // Update is called once per frame
    void Update()
    {
        Hit = Physics2D.Raycast(transform.position, Vector2.down, EnemySmall);
        if(!Hit.collider)
        {
            //life--;
        }
        if(life <0)
        {
            life = 0;
        }
        PlayerMove();
        Dead();
        moveCharater();
    }
    void moveCharater()
    { 
        assistant.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);

    }
    private void PlayerMove()
    {
        if(Input.GetMouseButton(0))
        {

            mousePositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePositon - transform.position).normalized;
            rigid.velocity = new Vector2(direction.x * SpeedMove, direction.y * SpeedMove);

            Shooter();
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }

    }
   
    private void Shooter()
    {
        //Debug.Log("vao shooter");
        GameObject obj = newObjectpoolerScript.current.getPooledObject(GameController.game.typeBullet);
        if (obj == null)
        {
            return;
        }

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "asteroid")
        {
            life--;
            Destroy(collision.gameObject);
            //transform.position = Vector2.MoveTowards(transform.position, PlayerStart, 0.2f);
        }if( collision.tag =="bossparent"|| collision.tag== "EnemyCarries" || collision.tag == "EnemyStar" || collision.tag == "bulletEnemyStar"|| collision.tag=="bulletBoss" )
        {
            life--;
        }
        if(collision.tag == "item")
        {
            GameController.game.typeBullet = 2;
            Destroy(collision.gameObject);
        }

       
    }
    public int getLifePlayer()
    {
        return this.life;
    }
    private void Dead()
    {
        if( this.life == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
