using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class EulerDemo : MonoBehaviour 
{
    public Vector3 euler;


    private void OnGUI()
    {
        euler = transform.eulerAngles;
        if (GUILayout.RepeatButton("旋转"))
        {
            transform.eulerAngles += new Vector3(1, 0, 0);
        }
    }

    private void Func1()
    {
        
        //new Vector3(1, 0, 0) = Vector3.right
        //new Vector3(0, 1, 0) = Vector3.up
        //new Vector3(0, 0, 1) = Vector3.forward
        

    }
}
