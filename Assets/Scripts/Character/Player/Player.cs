using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[ExecuteInEditMode]
public class Player : CharacterBase
{
    public  PLAYER_ANIMATOR         player_anim;
    [HideInInspector]
    public  Rigidbody               my_body;
    //플레이어 스킬부분
    public  PLAYER_SKILLS           player_skills;
    
    //다른 오브젝트의 스크립트을 참조
    
    private JoystickControl         srt_input;
    private AttackButton            srt_attackButton;
    private PlayerStateMachine      player_state;

    //플레이어 체력 200 공격력 35
    
    public enum PLAYER_ANIMATOR
    {
        DONE = -1,
        IDLE = 0,
        RUN,
        ATTACK,
        DEAD
    };
    public enum PLAYER_SKILLS
    {
        DONE = -1,
        ARCHER = 0,
        MAGICIAN,
        PIRATE,
        SHIELD
    };
    public sealed override void init()
    {
        base.Start();
        position            = this.transform.position;
        my_body             = GetComponent<Rigidbody>();
        player_state        = new PlayerStateMachine();
        player_skills       = PLAYER_SKILLS.DONE;
        srt_input           = GameObject.FindObjectOfType<JoystickControl>() as JoystickControl;
        srt_attackButton    = GameObject.FindObjectOfType<AttackButton>() as AttackButton;
        player_state.Init(this);
        
        //*문제점* player의 y값 계속 바뀜..
    }
    public sealed override void update()
    {
        Debug.Log("player skill = "+player_skills);
        //Debug.Log("enemy anim = " + Get_Enemy.enemy_anim);
        player_state.Update();
    }
    public sealed override void clean()
    {
    }
    public AttackButton Get_AttackButton
    {
        get
        {
            return srt_attackButton;
        }
    }
    public PlayerStateMachine Get_PlayerState
    {
        get
        {
            return player_state;
        }
    }
    public JoystickControl Get_Joystick
    {
        get
        {
            return srt_input;
        }
    }
}
