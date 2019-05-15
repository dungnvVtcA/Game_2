using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10.0f;

    public LayerMask asteroid;

    Vector2 screen;

    RaycastHit2D hit;

    public GameObject explosion;

    void Start()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }
    void Update()
    {
        // use Raycast
        hit = Physics2D.Raycast(transform.position, Vector2.up, 1.0f, asteroid);
        if (hit.collider != null)
        {
            //GameController.game.type = 2;
            //GameObject game = Instantiate(explosion) as GameObject;
            //game.transform.position = transform.position;
            Destroy(hit.collider.gameObject);
            //Destroy(asteroid);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "asteroid")
    //    {
    //        GameObject game = Instantiate(explosion) as GameObject;
    //        game.transform.position = transform.position;
    //        Destroy(gameObject);
    //        Destroy(collision.gameObject);

    //    }

    //}
    //public GameObject getPooledObject(int currenBullet)
    //{
    //    for (int i = 0; i < pooledObject_.Count; i++)
    //    {
    //        if (i == currenBullet)
    //        {
    //            for (int j = 0; j < pooledObject_[0].Count; j++)
    //            {
    //                if (!pooledObject_[0][j].activeInHierarchy)
    //                {
    //                    return pooledObject_[0][j];
    //                }
    //            }
    //            if (willGrow)
    //            {
    //                GameObject obj = (GameObject)Instantiate(pooledObject);
    //                pooledObject_[0].Add(obj);
    //                return obj;
    //            }
    //        }
    //    }

    //    return null;
    //}
}
