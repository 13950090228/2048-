using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 
/// </summary>

public class DialogDrag : MonoBehaviour , IPointerDownHandler,IDragHandler
{
    private RectTransform parentRTF;
    private Vector3 worldPoint;
    private Vector3 offset;

    public void Start()
    {
        parentRTF = transform.parent as RectTransform;
    }

    //求出拖拽点和对象的原点的距离
    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF, eventData.position, eventData.pressEventCamera, out worldPoint);

        offset = transform.position - worldPoint;
    }

    //再拖拽时加上拖拽点和对象的原点的距离
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPoint;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF, eventData.position, eventData.pressEventCamera, out worldPoint);

        transform.position = worldPoint + offset;
    }
}
