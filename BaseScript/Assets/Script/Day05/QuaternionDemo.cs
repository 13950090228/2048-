using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class QuaternionDemo : MonoBehaviour 
{
    private Vector3 vect;

    public void Start()
    {
        vect = new Vector3(0, 0, 10);
    }
    private void OnGUI()
    {
        if (GUILayout.Button("四元数旋转"))
        {
            Vector3 axis = Vector3.up;

            float angle = 50 * Mathf.Deg2Rad;
            Quaternion qt = new Quaternion();

            qt.x = Mathf.Sin(angle / 2) * axis.x;
            qt.y = Mathf.Sin(angle / 2) * axis.y;
            qt.z = Mathf.Sin(angle / 2) * axis.z;
            qt.w = Mathf.Cos(angle / 2);

            //transform.rotation = qt;
            //transform.rotation = Quaternion.Euler(0, 10, 0);
        }

        if (GUILayout.Button("沿X轴旋转"))
        {
            //transform.rotation *= Quaternion.Euler(10, 0, 0);
            transform.Rotate(10, 0, 0);
        }

        if (GUILayout.Button("沿Y轴旋转"))
        {

            transform.rotation *= Quaternion.Euler(0, 10, 0);
        }

        if (GUILayout.Button("沿Z轴旋转"))
        {

            transform.rotation *= Quaternion.Euler(0, 0, 10);
        }

    }

    public void Update()
    {

        //vect = transform.rotation * new Vector3(0, 0, 10);
        //vect = Quaternion.Euler(0, 0, 30) * vect;
        //vect = transform.position + vect;
        vect = transform.position + new Vector3(0, 0, 10);
        vect = Quaternion.Euler(0, 0, 30) * vect;
        Debug.DrawLine(transform.position, vect);

    }

}
