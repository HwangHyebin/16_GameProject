using UnityEngine;
using System.Collections;

public class SkillCharacterBase : MonoBehaviour 
{
    //public      Animator        anim;

    protected   float           startTime       = 0.0f;
    protected   float           nextTime        = 0.0f;
    protected   float           delay           = 0.0f;

    private     Player          srt_player;
    private     Enemy           srt_enemy;

    //각각 캐릭터 정보 파싱해서 딜레이에 영향 주기.

    public struct STATUS
    {
        float attack;
        float shield;
        float hp;
        float attackSpeed;
    };
    public virtual void Init()
    {
        srt_enemy           = GameObject.FindObjectOfType<Enemy>();
        srt_player          = GameObject.FindObjectOfType<Player>();
        
        Debug.Log("base init");
    }
    public Player Get_Player
    {
        get
        {
            return srt_player;
        }
    }
    public Enemy Get_Enemy
    {
        get
        {
            return srt_enemy;
        }
    }
}
