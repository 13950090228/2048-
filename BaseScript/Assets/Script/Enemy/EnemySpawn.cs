using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敌人生成器
/// </summary>
public class EnemySpawn : MonoBehaviour
{
    /// <summary>
    /// 开始时需要创建的敌人数量
    /// </summary>
    public int startCount = 2;



    //计算路线
    private WayLine[] lines;
    private void CalculateWayLines()
    {
        //WayLine 路线  与 子物体   对应
        //lines[0].Points 该路线所有路点坐标   与  子物体的子物体.Position对应
        lines = new WayLine[transform.childCount];
        //创建路线
        for (int i = 0; i < lines.Length; i++)//0    1     2
        {
            Transform waylineTF = transform.GetChild(i);
            lines[i] = new WayLine(waylineTF.childCount);
            for (int pointIndex = 0; pointIndex < waylineTF.childCount; pointIndex++)
            {
                //获取每个路点坐标
                lines[i].Points[pointIndex] = waylineTF.GetChild(pointIndex).position;
            }
        }
    }

    //当前产生的敌人数量
    private int spawnedCount;
    /// <summary>
    /// 可以产生敌人的最大值
    /// </summary>
    public int maxCount;

    /// <summary>
    /// 产生敌人的最大延迟时间
    /// </summary>
    public int maxDelay = 10;

    /// <summary>
    /// 敌人类型
    /// </summary>
    public GameObject[] enemyTypes;

}
