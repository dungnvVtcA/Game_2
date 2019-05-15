using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    private float timeSeconds = 2.0f;

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
