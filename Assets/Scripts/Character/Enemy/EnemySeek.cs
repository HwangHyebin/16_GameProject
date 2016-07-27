using UnityEngine;
using System.Collections;

public class EnemySeek : EnemyState
{
    private static EnemySeek instance;
    public static EnemySeek Instance
    {
        get
        {
            if (instance == null)
                instance = new EnemySeek();
            return instance;
        }
    }
    public sealed override void Enter(Enemy _enemy)
    {
        _enemy.my_body.velocity = Vector3.zero;
        _enemy.enemy_anim       = Enemy.ENEMY_ANIMATOR.IDLE;
    }
    public override void Execute(Enemy _enemy)
    {
        float speed = 1.5f;
        _enemy.transform.LookAt(_enemy.target.transform.position);
        _enemy.transform.position += (_enemy.transform.forward * speed * Time.deltaTime);
        float dis   = Vector3.Magnitude(_enemy.transform.position - _enemy.target.transform.position);
        if (dis < 1.4f)
        {
            _enemy.enemy_anim = Enemy.ENEMY_ANIMATOR.ATTACK;
            _enemy.Enemy_State.ChangeState(EnemyAttack.Instance);
        }
        _enemy.Target_Check();
    }
    public override void Exit(Enemy _enemy)
    {
    }

}
