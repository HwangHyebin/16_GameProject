using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[ExecuteInEditMode]
public class Player : CharacterBase
{
    public  PLAYER_ANIMATOR         player_anim;
    public  PLAYER_SKILLS           player_skills;
    public  Transform               hp_bar;
    private ControlPlayerHPBar      life;
    [HideInInspector]
    public  bool                    attack_check        = false;
    private JoystickControl         srt_input;
    private AttackButton            srt_attackButton;
    private PlayerStateMachine      player_state;

    private GameObject robbyUI;


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
        robbyUI = GameObject.Find("RobbyUI").gameObject;
        robbyUI.transform.FindChild("Anchor").gameObject.SetActive(true);
        robbyUI.transform.FindChild("Anchor").FindChild("Top_Left").gameObject.SetActive(true);
        robbyUI.transform.FindChild("Anchor").FindChild("Top_right").gameObject.SetActive(false);
        robbyUI.transform.FindChild("Anchor").FindChild("Bottom_Left").gameObject.SetActive(false);
        robbyUI.transform.FindChild("Anchor").FindChild("Center").gameObject.SetActive(false);

        hp_bar = robbyUI.transform.FindChild("Anchor").FindChild("Top_Left").FindChild("GameObject").FindChild("HP").GetComponent<ControlPlayerHPBar>().transform;
        //hp_bar = robbyUI.GetComponentInChildren<ControlPlayerHPBar>().transform;
        //hp_bar = GameObject.FindObjectOfType<ControlPlayerHPBar>().transform;
        life = hp_bar.GetComponent<ControlPlayerHPBar>();

        player_state.Init(this);
    }
    public sealed override void update()
    {
        player_state.Update();
    }
    private void OnTriggerStay(Collider col)
    {
        col.GetComponent<Enemy>();
        if (col.tag == "Enemy")
        {
            HP_Control(col);
        }
    }
    private void HP_Control(Collider col)
    {
        if (startTime == 0.0f)
        {
            startTime = Time.time;
            nextTime = startTime + 1.0f;

            if (col.GetComponent<Enemy>().attack_check == true) 
            {
                if (player_skills != PLAYER_SKILLS.SHIELD)
                {
                    life.m_HP -= (col.GetComponent<Enemy>().status.power - this.status.defense);
                }
            }
        }
        if (Time.time > nextTime && startTime != 0)
        {
            startTime = 0;
        }
    }
    public AttackButton Get_AttackButton
    {
        get { return srt_attackButton; }
    }
    public PlayerStateMachine Get_PlayerState
    {
        get { return player_state;}
    }
    public JoystickControl Get_Joystick
    {
        get { return srt_input; }
    }
}
