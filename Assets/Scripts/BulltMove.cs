using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulltMove : MonoBehaviour
{
    
    [SerializeField]
    GameObject objplayer;

    Vector3 posi;

    Vector3 _target;

    private void Awake()
    {
        _target = new Vector3(objplayer.transform.position.x, objplayer.transform.position.y, 0);
        //Debug.Log(posi = objplayer.transform.position);
    }
    void Update()
    {

        this.transform.position += _target * 2f * Time.deltaTime;
    }
}
