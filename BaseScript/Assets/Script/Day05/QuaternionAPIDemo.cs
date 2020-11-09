using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class QuaternionAPIDemo : MonoBehaviour 
{
    public Transform t1;
    private float x=0;
    private void OnGUI()
    {
        //if (GUILayout.Button("。。"))
        //{
        //    //1.欧拉角 --> 四元数
        //    //Quaternion.Euler();

        //    //2.四元数 --> 欧拉角
        //    Quaternion qt = transform.rotation;
        //    Vector3 euler = qt.eulerAngles;

        //    //3.轴/角
        //    //Quaternion.Euler(0,50,0)
        //    transform.rotation = Quaternion.AngleAxis(50, Vector3.up);
        //}

        if (GUILayout.RepeatButton("注视旋转"))
        {
            //Z轴指向指定物体
            x += Time.deltaTime;
            //Vector3 dir = t1.position - transform.position;
            //transform.rotation = Quaternion.LookRotation(t1.position - transform.position);
            Quaternion dir = Quaternion.LookRotation(t1.position - transform.position);
            //由快到慢
            //transform.rotation = Quaternion.Lerp(transform.rotation, dir,x);
            //匀速旋转
            transform.rotation = Quaternion.RotateTowards(transform.rotation, dir, x);

        }

        if (GUILayout.RepeatButton("Angle"))
        {
            Quaternion angle = Quaternion.Euler(0, 150, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, angle, x += Time.deltaTime);

            //if (Quaternion.Angle(transform.rotation, angle) < 30)
            //{
            //    transform.rotation = angle* Quaternion.Euler(0, 20, 0);
            //}
        }

        if (GUILayout.RepeatButton("right"))
        {
            //x轴的注视旋转
            //transform.right = t1.position-transform.position ;
            Quaternion angle = Quaternion.FromToRotation(Vector3.right, t1.position - transform.position);
            transform.rotation = angle;
        }
    }
}
