using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletStar : MonoBehaviour
{
    private float timeSecond = 5.0f;

    private void OnEnable()
    {
        Invoke("Destroy", timeSecond);
    }
    private void  Destroy()
    {
       
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
