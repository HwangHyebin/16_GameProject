using UnityEngine;
using System.Collections;

public class EnemyStateMachine
{
    public  EnemyState      enemy_state;
    private Enemy           enemy;
    
    public void Init(Enemy _enemy)
    {
        enemy_state = EnemySeek.Instance;
        enemy = _enemy;
        enemy.enemy_anim    = Enemy.ENEMY_ANIMATOR.IDLE;
    }
    public void ChangeState(EnemyState nextState)
    {
        if (enemy_state == null)
            enemy_state = EnemySeek.Instance;
        if (enemy_state == nextState)
            return;
        enemy_state.Exit(enemy);
        enemy_state = nextState;
        enemy_state.Enter(enemy);

        switch (enemy.enemy_anim)
        {
            case Enemy.ENEMY_ANIMATOR.IDLE:
                enemy.anim.SetInteger("animation", 0);
                break;
            case Enemy.ENEMY_ANIMATOR.ATTACK:
                enemy.anim.SetInteger("animation", 1);
                break;
            case Enemy.ENEMY_ANIMATOR.DEAD:
                enemy.anim.SetInteger("animation", 2);
                break;
        }
    }
   
    public void Update()
    {
        enemy_state.Execute(enemy);   
    }
}
