using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destopMovement : MonoBehaviour
{
    public Transform player;

    public Transform assistant;

    public float speed = 5.0f;

    public float fireTime = 0.05f;

    private Vector3 mousePosition;




    // Update is called once per frame
    void Update()
    {
        return;
        moveCharater(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        
        if (Input.GetMouseButton(0))
        {
            Shooter();
        }

    }
    void moveCharater(Vector2 direction)
    {
        return;
        player.Translate(direction * speed * Time.deltaTime);

        assistant.transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y , player.transform.position.z);
        
    }
    void Shooter()
    {
        return;
        GameObject obj = newObjectpoolerScript.current.getPooledObject(GameController.game.typeBullet);
        if (obj == null)
        {
            return;
        }

        obj.transform.position = player.transform.position;
        obj.transform.rotation = player.transform.rotation;
        obj.SetActive(true);

    }
   
}
