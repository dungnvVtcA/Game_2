using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HP_Boss : MonoBehaviour
{

    public static float health;

    private float maxHp = 3000.0f;

    public Image healthbar;

    private void Start()
    {
        health = maxHp;
        healthbar = GetComponent<Image>();
       
    }


    void Update()
    {
        healthbar.fillAmount = health / maxHp;
    }
}
