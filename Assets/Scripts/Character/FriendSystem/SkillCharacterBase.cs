using UnityEngine;
using System.Collections;

public class SkillCharacterBase : MonoBehaviour 
{
    //public      Animator        anim;

    public      bool            destroy = false;
    public      STATUS          status;
    protected   Transform[]       hp;
    protected Life[] life;
    private     Player          srt_player;
    private     Enemy           srt_enemy;
    private GameManager srt_GameManager;

    //각각 캐릭터 정보 파싱해서 딜레이에 영향 주기.

    public struct STATUS
    {
        public int      lv;
        public float    hp;
        public float    power;
        public float    defense;
        //public float    attackSpeed;
        public float    removeTime;
        public float    coolTime;
    };
    public virtual void Init()
    {
        srt_enemy           = GameObject.FindObjectOfType<Enemy>();
        srt_player          = GameObject.FindObjectOfType<Player>();
        srt_GameManager = GameObject.FindObjectOfType<GameManager>();
        hp = new Transform[Get_GameManager._enemyArray.Length];
        life = new Life[Get_GameManager._enemyArray.Length];
        for (int i = 0; i < Get_GameManager._enemyArray.Length; ++i)
        {
            hp[i] = Get_GameManager._enemyArray[i].transform.parent.FindChild("HP");
            life[i] = hp[i].GetComponent<Life>();
        }
    }
    protected void Destroy()
    {
        Get_Player.player_skills = Player.PLAYER_SKILLS.DONE;
        destroy = true;
    }
    public void Attacked_SkillCharacter()
    {
        Debug.Log("적이 맞음 = " + Get_Enemy.Attacked_Enemy);
        Debug.Log("스킬 캐릭터 맞음 = " + Get_Enemy.Hit_SkillCharacter);
        if (Get_Enemy.enemy_anim == Enemy.ENEMY_ANIMATOR.ATTACK && Get_Enemy.Hit_SkillCharacter == true)
        {
            if (status.hp > 0.0f)
            {
                InvokeRepeating("HP_Control", 1.0f, 0.0f);
            }
        }
    }
    private void HP_Control()
    {
        status.hp -= (Get_Enemy.status.power - status.defense);
        Debug.Log("hp = " + status.hp);
    }
    public void Set_Status(ref SkillCharacterBase _base, int _lv, float _hp, float _power, float _defense, float _removeTime, float _coolTime)
    {
        _base.status.lv         = _lv;
        _base.status.hp         = _hp;
        _base.status.power      = _power;
        _base.status.defense    = _defense;
        _base.status.removeTime = _removeTime;
        _base.status.coolTime   = _coolTime;
    }
    public Player Get_Player
    {
        get { return srt_player; }
    }
    public Enemy Get_Enemy
    {
        get { return srt_enemy; }
    }
    public GameManager Get_GameManager
    {
        get { return srt_GameManager; }
    }
}
