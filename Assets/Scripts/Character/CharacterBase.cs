using UnityEngine;
using System.Collections;

public class CharacterBase : MonoBehaviour 
{
    //public  int                 hp;
    public  float               damage;
    public  Animator            anim;
    public  Vector3             position;
    public  CharacterBase.S_CHARACTER_STATUS status;
    
    private Enemy               srt_enemy;
    private Player              srt_player;
    private ControlPlayerHPBar  srt_player_hp;
    private GameManager         srt_gameManager;
    private SkillManager        srt_skillManager;

    public struct S_CHARACTER_STATUS
    {
        public float demage;
        public float hp;
    };

    protected virtual void Start()
    {
        srt_enemy           = GameObject.FindObjectOfType<Enemy>() as Enemy;
        srt_player          = GameObject.FindObjectOfType<Player>() as Player;
        srt_player_hp       = GameObject.FindObjectOfType<ControlPlayerHPBar>() as ControlPlayerHPBar;
        srt_gameManager     = GameObject.FindObjectOfType<GameManager>() as GameManager;
        srt_skillManager    = GameObject.FindObjectOfType<SkillManager>() as SkillManager;
    }
    public virtual void init() 
    {}
    public virtual void update()
    {}
    public virtual void clean()
    {}
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
            return srt_player_hp;
        }
    }
    public Enemy Get_Enemy
    {
        get
        {
            return srt_enemy;
        }
    }
    public GameManager Get_Gamemanager
    {
        get
        {
            return srt_gameManager;
        }
    }
    public SkillManager Get_SkillManager
    {
        get
        {
            return srt_skillManager;
        }
    }
}
