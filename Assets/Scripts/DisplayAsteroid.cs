using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAsteroid : MonoBehaviour
{
    public GameObject asteroidPrefab;

    //public GameObject item;

    private float respawnTime = 1.0f;

    private Vector2 screenBonus;

    void Start()
    {
        return;
        screenBonus = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWake());
    }
    
    void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBonus.x, screenBonus.x), screenBonus.y);
    }
    

    IEnumerator asteroidWake()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            if(GameController.game.timePart > 20)
            {
                break;
            }
            
            
        }
    }
    
}
