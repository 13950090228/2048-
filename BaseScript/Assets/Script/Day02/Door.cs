using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class Door : MonoBehaviour 
{
    public bool doorStart = false;
    public string animName = "Door";

    private Animation anim;

    public void Start()
    {
        anim = transform.GetComponent<Animation>();
    }
    public void OnMouseDown()
    {

        if (doorStart)
        {
            //关门
            //从最后开始
            if (anim.isPlaying==false)
            {
                anim[animName].time = anim[animName].length;
            }
            
            //倒序播放
            anim[animName].speed = -1;
           
        }
        else
        {
            //开门
            anim[animName].speed = 1;
        }
        //播放动画
        anim.Play(animName);
        doorStart = !doorStart;
    }
}
