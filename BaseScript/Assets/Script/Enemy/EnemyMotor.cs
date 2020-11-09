using UnityEngine;
using System.Collections;

/// <summary>
/// 敌人马达，负责敌人运动功能
/// </summary>
public class EnemyMotor : MonoBehaviour
{
    //生成敌人时传递路线引用
    public Transform[] wayline;

    /// <summary>
    /// 移动速度
    /// </summary>
    public float moveSpeed = 2;

    /// <summary>
    /// 向前移动
    /// </summary>
    public void MovementForward()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 朝向目标点的旋转
    /// </summary>
    /// <param name="targetPos">目标位置</param> 
    public void LookRotation(Vector3 targetPos)
    {
        //暂时……  一帧旋转至目标方位
        transform.LookAt(targetPos);
    }

    private int currentIndex;
    /// <summary>
    /// 寻路
    /// </summary>
    public bool Pathfinding()
    { 
        //如果索引超过最大值  则 返回false ，表示寻路结束
        if (currentIndex >= wayline.Length) return false;

        LookRotation(wayline[currentIndex].position);
        MovementForward();

        if (Vector3.Distance(transform.position, wayline[currentIndex].position) <= 0.1)
            currentIndex++;

        return true;//返回true 表示 可以继续寻路
    }


}
