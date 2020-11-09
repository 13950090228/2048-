using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 读取精灵图资源
/// </summary>

public class ResourceManage : MonoBehaviour 
{
    private static Dictionary<int,Sprite> spriteDic;

    static ResourceManage()
    {
        spriteDic = new Dictionary<int, Sprite>();
        var spriteArray = Resources.LoadAll<Sprite>("2048Atlas");
        foreach (var item in spriteArray)
        {
            int intSprite = int.Parse(item.name);
            spriteDic.Add(intSprite, item);
        }
    }

    public static Sprite LoadSprite(int number)
    {
        return spriteDic[number];
    }


}
