using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController game;

   

    [SerializeField] GameObject enemySmaller;

    [SerializeField]
    GameObject EnemyYellow_;

    [SerializeField]
    GameObject EnemyCarries_;

    [SerializeField]
    GameObject Items_;

    public GameObject boss;

    List<GameObject> lisEnemy;

    public float timePart = 0.0f;

    public bool enemySmallDead = false;

    public bool enemyStarDead = false;

    public bool enemyCarries = false;

    public bool isBoss = false;

    public List<GameObject> GetLisEnemy()
    {
        return this.lisEnemy;
    }

    public  int typeBullet = 1;

    public float respawnTime = 5.0f;

    public int CountEnemySmallDead, CountEnemyYellowDead, CountEnemyCarriesDead;

    private int flagmaxEnySmall , flagmaxEneyYellow, flagmaxEneCarries;

    public Vector2 ScreenGame;

    GameObject obj;

    private void Awake()
    {
        game = this;
        flagmaxEnySmall = 0;
        flagmaxEneyYellow = 0;
        flagmaxEneCarries = 0;
        CountEnemySmallDead = 0;
        CountEnemyYellowDead = 0;
        CountEnemyYellowDead = 0;
        ScreenGame = Camera.main.ScreenToWorldPoint(new Vector3( Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }
    void Start()
    {
       
        //isBoss = true;
        lisEnemy = new List<GameObject>();
        StartCoroutine(asteroidWake());
    }

    // Update is called once per frame
    void Update()
    {
        //return;
        timePart += Time.deltaTime;
        if(CountEnemySmallDead == 20)
        {
            enemySmallDead = true;
        }
        if (CountEnemyYellowDead == 20)
        {
            enemyStarDead = true;
        }
        if (CountEnemyCarriesDead == 10)
        {
            enemyCarries = true;
        }
        if (lisEnemy.Count > 1)
        {
            //Debug.Log(lisEnemy[0].transform.position.x);
           
        }
        
    }
    void spawnEnemyScrolling()
    {
        GameObject a = Instantiate(enemySmaller) as GameObject;
        a.transform.position = new Vector2(Random.Range(-ScreenGame.x, ScreenGame.x), ScreenGame.y);
        lisEnemy.Add(a);
    }

    void spawnEnemyYellow()
    {
        GameObject b = Instantiate(EnemyYellow_) as GameObject;
        b.transform.position = new Vector2(Random.Range(-ScreenGame.x, ScreenGame.x), ScreenGame.y);
        lisEnemy.Add(b);
    }
    void spawnItem()
    {
        GameObject item = Instantiate(Items_) as GameObject;
        item.transform.position = new Vector2(Random.Range(-ScreenGame.x, ScreenGame.x), ScreenGame.y);
        
    }

    void spawnEnemyCarries()
    {
        GameObject c = Instantiate(EnemyCarries_) as GameObject;
        c.transform.position = new Vector2(Random.Range(-ScreenGame.x, ScreenGame.x), ScreenGame.y);
        lisEnemy.Add(c);
    }
    IEnumerator asteroidWake()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            if(timePart > 15)
            {
                if(flagmaxEnySmall <= 20)
                {
                    spawnEnemyScrolling();
                    flagmaxEnySmall++;
                }
                if (enemySmallDead && flagmaxEneyYellow <= 20)
                {
                    spawnEnemyYellow();
                    flagmaxEneyYellow++;

                }
                if (enemyStarDead && flagmaxEneCarries <= 10)
                {
                    if (flagmaxEneCarries == 4)
                    {
                        spawnItem();
                    }
                    spawnEnemyCarries();
                    flagmaxEneCarries++;
                }
                if (enemyCarries )
                {
                    GameObject boss_ = Instantiate(boss) as GameObject;
                    boss.transform.position = new Vector2(0f, ScreenGame.y *2);
                    lisEnemy.Add(boss_);
                    isBoss = true;
                }


            }
            
        }
        
    }
    public GameObject AssitantAinim(Transform transformObject)
    {
        float positionMin = 0f;
        if( lisEnemy == null)
        {
            return null;
        }
        positionMin = Vector2.Distance(lisEnemy[0].transform.position, transformObject.position);
        if (lisEnemy.Count >= 2)
        {
            for (int i = 1; i < lisEnemy.Count; i++)
            {
                var y = Vector2.Distance(lisEnemy[i].transform.position, transformObject.position);
                if (positionMin > y)
                {
                    Debug.Log("ddax check");
                    positionMin = y;
                    obj = lisEnemy[i];
                }
            }
        }else
        {
            
            obj = lisEnemy[0];

        }

        
        return obj;
        

    }
    public void CheckEnemyDead(GameObject game)
    {
        for(int i = 0; i <  lisEnemy.Count; i++ )
        {
            if(lisEnemy[i].transform.position.x == game.transform.position.x  && lisEnemy[i].transform.position.y == game.transform.position.y)
            {
                lisEnemy.RemoveAt(i);
            }
        }
    }
}

