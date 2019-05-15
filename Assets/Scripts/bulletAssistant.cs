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
            objEne = GameController.game.AssitantAinim(this.transform);
            Debug.Log("vao 1 lan thoi vao deo gi lam the");

        }
        if(GameController.game.GetLisEnemy().Count == 0 || objEne == null) 
        {
            transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            Debug.Log("null nha");
        }
        if (objEne != null)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, objEne.transform.position, 0.1f);   
        }
        

    }
}
