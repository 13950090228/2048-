using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class BoomDemo : MonoBehaviour 
{
    public Transform t1, t2;
    private float radius;
    private Vector3 leftTangent;
    private Vector3 rightTangent;

    public void Start()
    {
         radius = t1.GetComponent<SphereCollider>().radius;
    }


    public void CalaculateTangent()
    {
        //炸弹到玩家之间距离的向量长度
        Vector3 distance = transform.position - t1.position;

        //玩家半径大小的向量
        Vector3 Radius = distance.normalized * radius;
        float angle = Mathf.Acos(radius / distance.magnitude)* Mathf.Rad2Deg;
        leftTangent = t1.position + Quaternion.Euler(0, angle, 0) * Radius;
        rightTangent = t1.position + Quaternion.Euler(0, -angle, 0) * Radius;
    }

    private void Update()
    {
        CalaculateTangent();

        Debug.DrawLine(transform.position, leftTangent);
        Debug.DrawLine(transform.position, rightTangent);
    }
    //public void Update()
    //{
    //    //半径
    //    float radius = t2.localScale.x;
    //    //两个物体之间距离
    //    float distance2 = Vector3.Distance(transform.position, t2.position);


    //    float angle = Mathf.Asin(radius / distance2) * Mathf.Rad2Deg;
    //    float cos = Mathf.Cos(angle * Mathf.Deg2Rad);
    //    //切线长度
    //    float tangent = distance2 * Mathf.Cos(angle * Mathf.Deg2Rad);

    //    Debug.Log("角度" + angle);
    //    Debug.Log("斜边:" + distance2);
    //    Debug.Log("半径:" + radius);
    //    Debug.Log("切线:" + tangent);
    //    Debug.DrawLine(transform.position, t2.position);
}








