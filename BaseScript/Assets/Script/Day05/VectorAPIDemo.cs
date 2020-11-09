using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class VectorAPIDemo : MonoBehaviour 
{
    public Transform t1;
    public Vector3 projection;
    public AnimationCurve curve;
    public float x = 0;
    private Vector3 terminus = new Vector3(0, 0, 20);

    public void Update()
    {
        //Vector3 result = Vector3.ProjectOnPlane(t1.position, projection);

        //Debug.DrawLine(Vector3.zero, t1.position);
        //Debug.DrawLine(Vector3.zero, result,Color.red);
    }

    public void OnGUI()
    {
        if (GUILayout.RepeatButton("MoveTowards"))
        {
            transform.position = Vector3.MoveTowards(transform.position, terminus, 0.1f);
        }

        if (GUILayout.RepeatButton("Lerp"))
        {
            //先快后慢，且永远不能到达终点
            //终点与比例固定
            transform.position = Vector3.Lerp(transform.position, terminus, 0.1f);
        }

        if (GUILayout.RepeatButton("LerpUnclamped"))
        {
            x += Time.deltaTime;
            //终点与起点固定   速度根据比例变化
            transform.position = Vector3.LerpUnclamped(transform.position, terminus, curve.Evaluate(0.1f));
        }
    }
}
