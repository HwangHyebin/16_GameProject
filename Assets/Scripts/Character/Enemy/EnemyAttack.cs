using UnityEngine;
using System.Collections;

public class EnemyAttack : EnemyState
{
    private float startTime;
    private float nextTime;

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
        _enemy.Target_Check();
        _enemy.transform.LookAt(_enemy.target.transform.position);
        float dis = Vector3.Magnitude(_enemy.transform.position - _enemy.target.transform.position);

        if (dis > 0.8f)
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
                _enemy.attack_check = true;
            }
            if (Time.time > nextTime && startTime != 0)
            {
                startTime = 0.0f;
                _enemy.attack_check = false;
            }
        }
    }
    public sealed override void Exit(Enemy _enemy)
    {
    }
}
