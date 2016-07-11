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
        Debug.Log("enemy seek enter");
        _enemy.enemy_anim       = Enemy.ENEMY_ANIMATOR.IDLE;
    }
    public override void Execute(Enemy _enemy)
    {
        Debug.Log("enemy seek execute");
        float speed = 1.5f;
        _enemy.transform.LookAt(_enemy.Get_Player.transform.position);
        _enemy.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        float dis   = Vector3.Magnitude(_enemy.transform.position - _enemy.Get_Player.transform.position);
        if (dis < 1.5f)
        {
            _enemy.enemy_anim = Enemy.ENEMY_ANIMATOR.ATTACK;
        }
    }
    public override void Exit(Enemy _enemy)
    {
    }
    public sealed override void Clean()
    { 
    }

}
