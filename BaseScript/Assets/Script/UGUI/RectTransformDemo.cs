using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class RectTransformDemo : MonoBehaviour 
{
    //世界坐标
    //当画布为overlay时，世界坐标（米）等同于屏幕坐标（像素）
    //transform.position

    // 当前轴心点 相对于父UI的轴心点位置（单位：像素）
    //transform.loaclPosition

    private void Start()
    {
        RectTransform rtf = GetComponent<RectTransform>();

        //高度
        //rtf.rect.height

        //设置UI高度
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 250);
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 250);
    }
}
