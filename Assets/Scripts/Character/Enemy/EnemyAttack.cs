using UnityEngine;
using System.Collections;

public class EnemyAttack : EnemyState
{
    private float  currentTime           = Time.time;
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
        Debug.Log("enemy attack enter");
    }
    public sealed override void Execute(Enemy _enemy)
    {
        Debug.Log("enemy seek execute");
        float delay         = 2.0f;
        float damage        = 3.0f;
        float nextTime      = currentTime + delay;
        _enemy.transform.LookAt(_enemy.Get_Player.transform.position);
        float dis           = Vector3.Magnitude(_enemy.transform.position - _enemy.Get_Player.transform.position);
        if (dis > 1.1f)
        {
            _enemy.Enemy_State.ChangeState(EnemySeek.Instance);
        }
        if (Time.time > nextTime)
        {
            currentTime = Time.time;
            _enemy.Get_Player_HP.hp -= damage;
        }
    }
    public sealed override void Exit(Enemy _enemy)
    {
    }
    public sealed override void Clean()
    { 
    }
}
