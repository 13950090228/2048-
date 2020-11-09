﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动画行为类，提供有关动画行为
/// </summary>

public class AnimationAction
{
    private Animation anim;

    public AnimationAction(Animation anim)
    {
        this.anim = anim;
    }

    public void Play(string animName)
    {
        anim.CrossFade(animName);
    }
}
