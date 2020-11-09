using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class TrigonometricDemo : MonoBehaviour 
{

    public void Update()
    {
        Func3();
    }
    private void Func1()
    {
        //角度转弧度
        float d1 = 60;
        float f1 = d1 * Mathf.Deg2Rad;
        float f2 = d1 * Mathf.PI/180;

        print(f1 + "---" + f2);


        //弧度到角度

        float d2 = 3;
        float f3 = d2 * Mathf.Rad2Deg;
        float f4 = d2 * 180/ Mathf.PI;

        print(f3 + "---" + f4);
    }

    private void Func2()
    {
        //已知角度 x,边长b
        //求边长 a

        float x = 60, b = 10;

        float a = Mathf.Sin(x*Mathf.Deg2Rad) * 10;
        ;


        //已知边长 a,b
        //求角度 x

        float a1 = 10, b1 = 8;

        float c1 = Mathf.Acos(b1 / a1)* Mathf.Rad2Deg;
        float c2 = Mathf.Cos(c1 * Mathf.Deg2Rad) * 10;
        print(c2);
    }

    private void Func3()
    {
        float a = 10;
        float x = 30;
        float b = Mathf.Cos(x * Mathf.Deg2Rad) * a;
        float c = Mathf.Sin(x * Mathf.Deg2Rad) * a;

        Vector3 worldPoint = transform.TransformPoint(c, 0, b);

        Debug.DrawLine(worldPoint, transform.position, Color.red);
    }
}
