using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class DoRoationDemo : MonoBehaviour 
{

    public float rotateSpeed = 1;
    public void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");


        if(x!=0 || y != 0)
        {
            RotateView(x, y);
        }
        
    }

    private void RotateView(float x,float y)
    {
        x *= rotateSpeed;
        y *= rotateSpeed;

        this.transform.Rotate(-y, 0, 0);
        this.transform.Rotate(0, x, 0, Space.Self);
    }
}
