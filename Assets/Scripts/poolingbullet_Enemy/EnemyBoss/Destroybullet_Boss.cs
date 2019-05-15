using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroybullet_Boss : MonoBehaviour
{
    private float timeSeconds = 5.0f;
    private void OnEnable()
    {
        Invoke("Destroy", timeSeconds);
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
