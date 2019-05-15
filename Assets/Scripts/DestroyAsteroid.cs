using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "asteroid" || collision.tag == "EenemyStar")
        {
            Destroy(collision.gameObject);
        }
    }
}
