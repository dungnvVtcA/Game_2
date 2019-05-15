using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Player : MonoBehaviour
{
    public Sprite[] HeartSprite;

    //public PlayerController player;

    public Image heart;

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.instal.life >= 0)
        {
            PlayerController game = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            heart.sprite = HeartSprite[game.getLifePlayer()];
        }

    }
}
