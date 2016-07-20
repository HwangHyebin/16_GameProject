using UnityEngine;
using System.Collections;

public class SkillCharacterBase : MonoBehaviour 
{
    private Player          srt_player;
    private SkillManager    srt_skillManager;
    public struct STATUS
    {
        float attack;
        float shield;
        float hp;
        float attackSpeed;
    };
    public virtual void Init()
    {
        srt_player          = GameObject.FindObjectOfType<Player>();
        srt_skillManager    = GameObject.FindObjectOfType<SkillManager>() as SkillManager;
        Debug.Log("base init");
    }
    public Player Get_Player
    {
        get
        {
            return srt_player;
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
