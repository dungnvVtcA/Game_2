using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAssistant : MonoBehaviour
{
    public static bulletAssistant bulletASS;

    private GameObject obj;

    public void setGameObject(GameObject gameObj)
    {
        obj = gameObj;
    }

    private GameObject objEne;
    private void Awake()
    {
        bulletASS = this;

    }

    private void Start()
    {
        obj = GameObject.Find("assistant");
    }

    void Update()
    {
        if (GameController.game.GetLisEnemy().Count > 0 && objEne == null)
        {
            objEne = GameController.game.AssitantAinim(transform.position.y);

        }

        if (objEne != null)
        {   
            transform.position = Vector2.MoveTowards(transform.position, objEne.transform.position, 0.1f);   
        }
        

    }
}
