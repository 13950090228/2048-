using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// </summary>

public class EventDemo : MonoBehaviour ,IPointerClickHandler,IDragHandler
{
    public void Func1()
    {
        print("Func1");
    }

    public void Func2(string str)
    {
        print("Func1:"+str);
    }

    private void Start()
    {
        //Button btn = transform.Find("Button").GetComponent<Button>();
        //btn.onClick.AddListener(Func1);

        //InputField input = transform.Find("InputField").GetComponent<InputField>();
        ////input.onEndEdit.AddListener(Func2);
        //input.onValueChanged.AddListener(Func2);

    }

    //光标单击时执行
    public void OnPointerClick(PointerEventData eventData)
    {
        //eventDate事件参数：提供了引发事件时的一些信息
        //双击两次
        if (eventData.clickCount == 2)
        {
            print("OnPointerClick" + eventData.clickCount);
        }
        
    }

    //光标拖拽时执行
    public void OnDrag(PointerEventData eventData)
    {
        //仅仅适用于overlay模式
        //transform.position = eventData.position;

        //通用
        //将屏幕坐标转化为世界坐标
        RectTransform parentRTF = transform.parent as RectTransform;
        Vector3 worldPoint;

        //(父物体变换组件、屏幕坐标、摄像机、 out 世界坐标)
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF, eventData.position, eventData.pressEventCamera, out worldPoint);
        transform.position = worldPoint;
    }

    
}
