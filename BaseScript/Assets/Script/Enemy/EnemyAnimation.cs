using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class EnemyAnimation : MonoBehaviour 
{
    public string runAnimName = "run";
    public string shootingAnimName = "shooting";
    //public string idleAnimName = "idle";
    public string deathAnimName = "death";
    public AnimationAction action;
    public void Awake()
    {
        action = new AnimationAction(GetComponentInChildren<Animation>());
    }
}
