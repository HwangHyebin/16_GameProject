using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Enemy : CharacterBase 
{
    public  ENEMY_ANIMATOR      enemy_anim;
    private EnemyStateMachine   enemy_state;
    private S_CHARACTER_STATUS  status;

    //몬스터 체력 150 데미지 25
    public enum ENEMY_ANIMATOR
    {
        DONE = -1,
        IDLE = 0,
        ATTACK,
        DEAD
    };
    public sealed override void init()
    {
        base.Start();
        position    = this.transform.position;
        enemy_state = new EnemyStateMachine();
        status      = new S_CHARACTER_STATUS();
        enemy_state.Init(this);
        //enemy의 y값도 계속 바뀜
    }
    public sealed override void update()
    {
        enemy_state.Update();
    }
    private void OnTriggerEnter(Collider col)
    {
        if ( col.gameObject.tag == "Magician")
        {
            status.hp -= 50.0f;
        }
    }
    public sealed override void clean()
    {
    }
    //private void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Player" && enemy_anim == ENEMY_ANIMATOR.ATTACK)
    //    {
    //        enemy_state.ChangeState(EnemyAttack.Instance);
    //    }
    //}
    public EnemyStateMachine Enemy_State
    {
        get
        {
            return enemy_state;
        }
    }
}
