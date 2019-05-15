using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBulletScript : MonoBehaviour
{
    public float speed = 20.0f;

    public LayerMask asteroid;

    Rigidbody2D rig;

    Vector2 screen;

    RaycastHit2D hit;

    public GameObject explosion;

    private void Awake()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.up, 1.0f, asteroid);
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);

    }
}
