using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBoss : MonoBehaviour
{
    private float speed = 5.0f;

    public LayerMask player;

    RaycastHit2D hit;
    void Update()
    {
        if(!GameController.game.isBoss)
        {
            return;
        }
        transform.Translate(0, -speed * Time.deltaTime, 0);
        //hit = Physics2D.Raycast(transform.position, Vector2.up, player);
        //if (!hit.collider)
        //{
        //    Debug.Log(" trung dan roi");
        //    gameObject.SetActive(false);
        //    //PlayerController.instal.life--;
        //}
    }
    
}
