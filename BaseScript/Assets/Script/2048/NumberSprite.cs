using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 附加到每个方格，定义方格行为
/// </summary>

public class NumberSprite : MonoBehaviour 
{
    private Image img;
    Sprite[] spriteArray;

    private void Awake()
    {
        img = GetComponent<Image>();
        spriteArray = Resources.LoadAll<Sprite>("2048Atlas");

    }

    public void SetImage(int number)
    {
        //2 --> 获取数字二精灵图 -->设置到image中
        //读取单个图用load，读取图集用loadAll
        img.sprite = ResourceManage.LoadSprite(number);

        //foreach (var item in spriteArray)
        //{
        //    if (item.name == number.ToString())
        //    {
        //        img.sprite = item;
        //    }
        //}
    }

    public void CreateEffect()
    {
        //小 --> 大
        iTween.ScaleFrom(gameObject, Vector3.zero, 0.3f);
    }

}
