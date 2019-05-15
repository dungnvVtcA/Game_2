using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingRepeat : MonoBehaviour
{
    private BoxCollider2D colider;

    private float Horizontal;

    private void Awake()
    {
        //return;
        colider = GetComponent<BoxCollider2D>();
        Horizontal = colider.size.y;

    }
    void Update()
    {
        if (transform.position.y < -Horizontal)
        {
            RepositionBackground();
        }

    }
    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(0, Horizontal *2f);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
