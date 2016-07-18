using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[ExecuteInEditMode]
public class Player : CharacterBase
{
    public  PLAYER_ANIMATOR         player_anim;
    public  PLAYER_SKILLS           player_skills;
    public  SkillButton[]           srt_skillButton;
    private Enemy                   srt_enemy;
    private AttackButton            srt_attackButton;
    private JoystickControl         srt_input;
    private PlayerStateMachine      player_state;
	private GameManager				srt_gameManager;

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
        SKILL_1 = 0,
        SKILL_2,
        SKILL_3
    };
    public sealed override void init()
    {
        position            = this.transform.position;
        player_state        = new PlayerStateMachine();
        srt_enemy           = GameObject.FindObjectOfType<Enemy>() as Enemy;
        srt_input           = GameObject.FindObjectOfType<JoystickControl>() as JoystickControl;
        srt_attackButton    = GameObject.FindObjectOfType<AttackButton>() as AttackButton;
		srt_gameManager 	= GameObject.FindObjectOfType<GameManager>() as GameManager;
        
		for (int i = 0; i < 3; ++i)
		{
			string ObjectName = string.Format ("SkillButton{0:0}", (i+1));
			srt_skillButton [i] = GameObject.Find (ObjectName).GetComponent<SkillButton> ();
		}

        player_state.Init(this);
        //player의 y값 계속 바뀜..
    }
    public sealed override void update()
    {
        player_state.Update();
    }
    public sealed override void clean()
    {
    }
    public Enemy Get_Enemy
    {
        get
        {
            return srt_enemy;
        }
    }
    public PlayerStateMachine Player_State
    {
        get
        {
            return player_state;
        }
    }
    public JoystickControl Srt_Input
    {
        get
        {
            return srt_input;
        }
    }
    public AttackButton Get_AttackButton
    {
        get
        {
            return srt_attackButton;
        }
    }
	public GameManager	Get_Gamemanager
	{
		get
		{
			return srt_gameManager;
		}
	}

}
