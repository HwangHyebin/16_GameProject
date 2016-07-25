using UnityEngine;
using System.Collections;

public class EnemyAttack : EnemyState
{
    private float startTime;
    private float nextTime;
    //우선순위를 만들어 사용 해야함. 
    //
   
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
    }
    public sealed override void Execute(Enemy _enemy)
    {
        _enemy.transform.LookAt(_enemy.Get_Player.transform.position);
        float dis           = Vector3.Magnitude(_enemy.transform.position - _enemy.Get_Player.transform.position);
        if (dis > 1.1f)
        {
            _enemy.enemy_anim = Enemy.ENEMY_ANIMATOR.IDLE;
            _enemy.Enemy_State.ChangeState(EnemySeek.Instance);
        }
        if (_enemy.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f) //애니메이션이 끝날때, 
        {
            if (startTime == 0)
            {
                startTime = Time.time;
                nextTime = startTime + 1.0f; // delay
                
                if (_enemy.Get_Player.player_skills != Player.PLAYER_SKILLS.SHIELD)
                {
                    _enemy.Get_Player_HP.m_HP -= (_enemy.status.power - _enemy.Get_Player.status.defense);
                }
            }
            if (Time.time > nextTime && startTime != 0)
            {
                startTime = 0.0f;
            }
        }
    }
    public sealed override void Exit(Enemy _enemy)
    {
    }
    public sealed override void Clean()
    { 
    }
}
