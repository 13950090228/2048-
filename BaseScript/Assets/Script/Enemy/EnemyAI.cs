using UnityEngine;
using System.Collections;

/// <summary>
/// 人工智能
/// </summary>

public class EnemyAI : MonoBehaviour
{
    /// <summary>
    /// 敌人状态
    /// </summary>
    public enum State
    { 
        /// <summary>
        /// 攻击状态
        /// </summary>
        Attack,
        /// <summary>
        /// 死亡状态
        /// </summary>
        Death,
        /// <summary>
        /// 寻路状态
        /// </summary>
        Pathfinding
    }

    private State currentState = State.Pathfinding;
    private EnemyMotor motor;
    private EnemyAnimation anim;

    private void Start()
    {
        anim = GetComponent<EnemyAnimation>();
        motor = GetComponent<EnemyMotor>();


    }

    /// <summary>
    /// 敌人状态
    /// </summary>
    public State state = State.Pathfinding;

    private void Update()
    {
        switch (state)
        {
            case State.Pathfinding:
                anim.action.Play(anim.runAnimName);
                if (motor.Pathfinding() == false)
                {
                    state = State.Attack;
                };
                break;
            case State.Attack:
                anim.action.Play(anim.shootingAnimName);
                break;
        }
    }



}
