using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public float maxPos = 3.3f;


    // Use this for initialization
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    
    } 

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -(screenBounds.x - objectWidth), screenBounds.x  -objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -(screenBounds.y - objectHeight), screenBounds.y  - objectHeight);
        transform.position = viewPos;

        //viewPos.x = Mathf.Clamp(viewPos.x, -maxPos, maxPos);
        //transform.position = viewPos;
        //Debug.Log(objectWidth);
    }
}
