using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class Player : MonoBehaviour 
{
    public float speed = 1;
    public void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        DoTranstion(hor,ver);
    }

    private void DoTranstion(float hor,float ver)
    {
        hor *= speed * Time.deltaTime;
        ver *= speed * Time.deltaTime;
        transform.Translate(hor , 0 , ver);
    }
}
