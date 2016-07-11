using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Enemy : CharacterBase 
{
    public  ENEMY_ANIMATOR      enemy_anim;

    private Player              srt_player;
    private ControlPlayerHPBar  player_hp;
    private EnemyStateMachine   enemy_state;
    public enum ENEMY_ANIMATOR
    {
        DONE = -1,
        IDLE = 0,
        ATTACK,
        DEAD
    };
    public sealed override void init()
    {
        position    = this.transform.position;
        enemy_state = new EnemyStateMachine();
        srt_player  = GameObject.FindObjectOfType<Player>() as Player;
        player_hp   = GameObject.FindObjectOfType<ControlPlayerHPBar>() as ControlPlayerHPBar;
        enemy_state.Init(this);
        //enemy의 y값도 계속 바뀜
    }
    public sealed override void update()
    {
        Debug.Log("enemy = " + position);
        Debug.Log("enemy transform position = " + this.transform.position);
        enemy_state.Update();
    }
    public sealed override void clean()
    {
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && enemy_anim == ENEMY_ANIMATOR.ATTACK)
        {
            enemy_state.ChangeState(EnemyAttack.Instance);
        }
    }
    public EnemyStateMachine Enemy_State
    {
        get
        {
            return enemy_state;
        }
    }
    public Player Get_Player
    {
        get
        {
            return srt_player;
        }
    }
    public ControlPlayerHPBar Get_Player_HP
    {
        get
        {
            return player_hp;
        }
    }
}
