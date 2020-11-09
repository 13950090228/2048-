using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class TimeDemo : MonoBehaviour 
{
    public float time1;
    public float time2;
    public void FixedUpdate()
    {
        time1 = Time.time; //收缩放影响的游戏消耗时间
        //transform.Rotate(0, 10, 0);
    }

    public void Update()
    {
        time2 = Time.unscaledTime;  //不收缩放影响的游戏消耗时间
        //受缩放影响的每帧间隔
        //transform.Rotate(0, 1000*Time.deltaTime, 0);

        //不受缩放影响的每帧间隔
        transform.Rotate(0, 1000 * Time.unscaledDeltaTime, 0);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("游戏暂停"))
        {
            Time.timeScale = 0;
        }

        if (GUILayout.Button("游戏开始"))
        {
            Time.timeScale = 1;
        }
    }
}
