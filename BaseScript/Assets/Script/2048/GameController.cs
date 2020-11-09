using Console2048;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 用于控制游戏逻辑
/// </summary>

public class GameController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private GameCore Core;
    private NumberSprite[,] spriteActionArray;
    private bool isDwon = false;
    private void Start()
    {
        Core = new GameCore();
        spriteActionArray = new NumberSprite[4, 4];
        Init();
        GenerateNewNumber();
        GenerateNewNumber();
    }

    private void Update()
    {
        if (Core.isChange == true)
        {
            //更新界面
            UpdateMap();
            //产生新数字
            GenerateNewNumber();
            Core.isChange = false;
        }
    }

    private void Init()
    {
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                CreateSprite(r,c);
            }
        }
    }

    private void UpdateMap()
    {
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                spriteActionArray[r, c].SetImage(Core.Map[r, c]);
            }
        }
    }


    private void CreateSprite(int r,int c)
    {
        GameObject go = new GameObject(r.ToString()+c.ToString());
        go.AddComponent<Image>();
        NumberSprite action = go.AddComponent<NumberSprite>();
        //将引用存储到二维数组
        spriteActionArray[r, c] = action;
        action.SetImage(0);
        go.transform.SetParent(transform,false);
    }

    private void GenerateNewNumber()
    {
        Location? loc;
        int? number;
        //生成一个新数字
        Core.GenerateBlank(out loc,out number);
        //根据位置获得精灵行为脚本引用
        spriteActionArray[loc.Value.rIndex, loc.Value.cIndex].SetImage(number.Value);
        //播放生成动画
        spriteActionArray[loc.Value.rIndex, loc.Value.cIndex].CreateEffect();
    }

    public Vector2 startPoint;
    public void OnPointerDown(PointerEventData eventData)
    {
        startPoint = eventData.position;
        isDwon = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
  
        if(isDwon == false)
        {
            return;
        }
        Vector2 offset = eventData.position - startPoint;

        float x = Mathf.Abs( offset.x);
        float y = Mathf.Abs(offset.y);

        //Console2048.MoveDirection dir;
        //水平方向
        Console2048.MoveDirection? dir = null;
        if (x > y )
        {
            
            if (offset.x > 0)
            {
                dir = Console2048.MoveDirection.Rgiht;
            }
            else
            {
                dir = Console2048.MoveDirection.Left;
            }
        }

        //垂直方向
        if (x < y )
        {
            if (offset.y>0)
            {
                dir = Console2048.MoveDirection.Up;
            }
            else
            {
                dir = Console2048.MoveDirection.Down;
            }
        }
        if(dir!=null)
        {
            Core.Move(dir.Value);

        }
        isDwon = false;

    }
}
