using UnityEngine;
using System.Collections;

public class EnemyAttack : EnemyState
{
    private float startTime;
    private float nextTime;
    //private float  currentTime           = Time.time;
    private static EnemyAttack instance;
    public static EnemyAttack Instance
    {
        get
        {
            if (instance == null)
                instance = new EnemyAttack();
            return instance;
        }
    }
    public sealed override void Enter(Enemy _enemy)
    {
        _enemy.enemy_anim = Enemy.ENEMY_ANIMATOR.ATTACK;
        //Debug.Log("enemy attack enter");
    }
    public sealed override void Execute(Enemy _enemy)
    {
        //enemy공격1번에 1번 hp 깎일수 있게 
        //Debug.Log("enemy seek execute");
        float delay         = 1.0f;
        //float nextTime      = currentTime + delay;
        _enemy.transform.LookAt(_enemy.Get_Player.transform.position);
        float dis           = Vector3.Magnitude(_enemy.transform.position - _enemy.Get_Player.transform.position);
        if (dis > 1.1f)
        {
            _enemy.enemy_anim = Enemy.ENEMY_ANIMATOR.IDLE;
            _enemy.Enemy_State.ChangeState(EnemySeek.Instance);
        }
        if (_enemy.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            if (startTime == 0)
            {
                startTime = Time.time;
                nextTime = startTime + delay;
                if (_enemy.Get_Player.player_skills != Player.PLAYER_SKILLS.SHIELD)
                {
                    Debug.Log("player HP = " + _enemy.Get_Player_HP.m_HP);
                    Debug.Log("demage = " + _enemy.status.demage);
                    _enemy.Get_Player_HP.m_HP -= _enemy.status.demage;
                }
            }
            if (Time.time > nextTime && startTime != 0)
            {
                startTime = 0.0f;
            }
        }
        //if (Time.time > nextTime)
        //{
        //    currentTime = Time.time;
          
        //}
    }
    public sealed override void Exit(Enemy _enemy)
    {
    }
    public sealed override void Clean()
    { 
    }
}
