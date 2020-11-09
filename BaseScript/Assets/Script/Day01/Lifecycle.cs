using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 脚本生命周期/必然事件/消息 Message
/// </summary>

public class Lifecycle : MonoBehaviour 
{
    //脚本：.cs的文本文件 类文件
    //附加到游戏物体，定义游戏对象行为指令代码
    public int a;

    //序列化字段 在编辑器中显示私有字段
    //[SerializeField]
    //private int b = 100;

    //在编辑器中隐藏字段
    [HideInInspector]
    public int c;

    //设置字段范围
    [Range(0, 100)]
    public int d;

    //      初始阶段
    //  创建完游戏对象后立即执行一次，早于 Start
    private void Awake()
    {
        //Debug.Log("Awake--" + Time.time + this.name);
    }

    private void Start()
    {

        //int a1 = 1;
        //int b1 = 2;
        //int c1 = a1 + b1;
        //Debug.Log("Start--" + Time.time + this.name);
    }

    //     物理阶段
    //每隔固定时间执行一次（可修改）
    //适合对物体做物理操作（移动、旋转。。） 不会受渲染影响

    //public float time;
    private void FixedUpdate()
    {
        //time = Time.time;
        //渲染时间不固定（每帧渲染量不同，受机器性能限制）

        //print("FixedUpdate" + time);
    }

    //鼠标按下
    //private void OnMouseDown()
    //{
    //    Debug.Log("OnMouseDown");
    //}

    //鼠标经过
    //private void OnMouseOver()
    //{
    //    Debug.Log("OnMouseOver");
    //}

    //鼠标离开
    //private void OnMouseExit()
    //{
    //    Debug.Log("OnMouseExit");
    //}

    //鼠标移入
    //private void OnMouseEnter()
    //{
    //    Debug.Log("OnMouseEnter");
    //}

    //鼠标抬起
    //private void OnMouseUp()
    //{
    //    Debug.Log("OnMouseUp");
    //}




    //    游戏逻辑
    // 渲染帧执行，执行间隔不固定
    // 处理游戏逻辑
    private void Update()
    {
        int a1 = 1;
        int b1 = 2;
        int c1 = a1 + b1;
        Debug.Log("Update--" + Time.time + this.name);

    }



}
