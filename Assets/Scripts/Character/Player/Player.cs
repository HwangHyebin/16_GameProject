using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[ExecuteInEditMode]
public class Player : CharacterBase
{
    public  PLAYER_ANIMATOR         player_anim;
    //플레이어 스킬부분
    //public  PLAYER_SKILLS           player_skills;
    
    
    //다른 오브젝트의 스크립트을 참조
    private Enemy                   srt_enemy;
    private JoystickControl         srt_input;
    private AttackButton            srt_attackButton;
	private GameManager				srt_gameManager;
    private PlayerStateMachine      player_state;
   
    public enum PLAYER_ANIMATOR
    {
        DONE = -1,
        IDLE = 0,
        RUN,
        ATTACK,
        DEAD
    };
    //public enum PLAYER_SKILLS
    //{
    //    DONE = -1,
    //    SKILL_1 = 0,
    //    SKILL_2,
    //    SKILL_3
    //};
    public sealed override void init()
    {
        position            = this.transform.position;
        player_state        = new PlayerStateMachine();
        srt_enemy           = GameObject.FindObjectOfType<Enemy>() as Enemy;
        srt_input           = GameObject.FindObjectOfType<JoystickControl>() as JoystickControl;
        srt_attackButton = GameObject.FindObjectOfType<AttackButton>() as AttackButton;
		srt_gameManager 	= GameObject.FindObjectOfType<GameManager>() as GameManager;
       

        player_state.Init(this);
        
        //*문제점* player의 y값 계속 바뀜..
    }
    public sealed override void update()
    {
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
    public Enemy Get_Enemy
    {
        get
        {
            return srt_enemy;
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
	public GameManager	Get_Gamemanager
	{
		get
		{
			return srt_gameManager;
		}
	}
    //public SkillCharacterFactory Get_SkillFactory
    //{
    //    get
    //    {
    //        return srt_skillFactory;
    //    }
    //}

}
