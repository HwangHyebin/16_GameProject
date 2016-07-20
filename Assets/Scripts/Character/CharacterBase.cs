using UnityEngine;
using System.Collections;

public class CharacterBase : MonoBehaviour 
{
    public  Animator            anim;
    public  Vector3             position;

    private Enemy               srt_enemy;
    private Player              srt_player;
    private ControlPlayerHPBar  player_hp;
    private GameManager         srt_gameManager;

    protected virtual void Start()
    {
        srt_enemy       = GameObject.FindObjectOfType<Enemy>() as Enemy;
        srt_player      = GameObject.FindObjectOfType<Player>() as Player;
        player_hp       = GameObject.FindObjectOfType<ControlPlayerHPBar>() as ControlPlayerHPBar;
        srt_gameManager = GameObject.FindObjectOfType<GameManager>() as GameManager;
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
            return player_hp;
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
}
