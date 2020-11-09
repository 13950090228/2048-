using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class VectorDemo : MonoBehaviour 
{

    public Transform t1, t2,t3;
    public float angle;
    public void Update()
    {
        Func4();
    }

    private void Func1()
    {
        Vector3 pos = transform.position;

        //求向量长度
        float m01 = pos.magnitude;
        float m02 = Vector3.Distance(Vector3.zero, pos);
        float m03 = Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.y, 2) + Mathf.Pow(pos.z, 2));

        Debug.LogFormat("m01{0}--m02{1}--m03{2}", m01, m02, m03);
        Debug.DrawLine(Vector3.zero, pos);
    }

    private void Func2()
    {
        Vector3 pos = transform.position;
        Vector3 n01 = pos / pos.magnitude;

        //API 获取向量的方向， 归一化，标准化  ==> 计算单位向量
        Vector3 n02 = pos.normalized;

        Debug.DrawLine(Vector3.zero, pos);
        Debug.DrawLine(Vector3.zero, n01,Color.red);
    }

    private void Func3()
    {
        Vector3 relative = t1.position + t2.position;


        if (Input.GetKey(KeyCode.A))
        {
            t3.Translate(relative.normalized); //*Time.deltaTime

        }

        Debug.DrawLine(Vector3.zero, relative,Color.red);
        Debug.DrawLine(Vector3.zero, t1.position);
        Debug.DrawLine(Vector3.zero, t2.position);
    }

    private void Func4()
    {

        float dot = Vector3.Dot(t1.position.normalized, t2.position.normalized);

        angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        Vector3 cross = Vector3.Cross(t1.position, t2.position);


        if (cross.y < 0)
        {
            angle = 360 - angle;
        }
        Debug.DrawLine(Vector3.zero, t1.position);
        Debug.DrawLine(Vector3.zero, t2.position);
        Debug.DrawLine(Vector3.zero, cross, Color.red);
        Debug.Log(cross.y);
    }
}
