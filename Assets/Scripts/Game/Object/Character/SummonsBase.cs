using UnityEngine;
using System.Collections;

public class SummonsBase : Actor 
{
    public bool destroy = false;
    public STATUS status;
    private Player srt_player;

    //private     Enemy           srt_enemy;
    //private ObjectManager srt_GameManager;

    //각각 캐릭터 정보 파싱해서 딜레이에 영향 주기.
    public struct STATUS
    {
        public int lv;
        public float hp;
        public float power;
        public float defense;
        //public float    attackSpeed;
        public float removeTime;
        public float coolTime;
    };
    public virtual void Init()
    {
        //srt_enemy           = GameObject.FindObjectOfType<Enemy>();
        srt_player = GameObject.FindObjectOfType<Player>();
        //srt_GameManager = GameObject.FindObjectOfType<ObjectManager>();
    }
    public bool Destroy()
    {
        Get_Player.player_skills = Player.PLAYER_SKILLS.DONE;
        destroy = true;
        return destroy;
    }
    public void Set_Status(ref SummonsBase _base, int _lv, float _hp, float _power, float _defense, float _removeTime, float _coolTime)
    {
        _base.status.lv = _lv;
        _base.status.hp = _hp;
        _base.status.power = _power;
        _base.status.defense = _defense;
        _base.status.removeTime = _removeTime;
        _base.status.coolTime = _coolTime;
    }
    public Player Get_Player
    {
        get { return srt_player; }
    }
    //public Enemy Get_Enemy
    //{
    //    get { return srt_enemy; }
    //}
    //public ObjectManager Get_GameManager
    //{
    //    get { return srt_GameManager; }
    //}
}
