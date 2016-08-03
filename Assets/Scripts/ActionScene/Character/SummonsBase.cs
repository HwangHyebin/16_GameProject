using UnityEngine;
using System.Collections;

public class SummonsBase : Actor 
{
    public      bool            destroy             = false;
    public      STATUS          status;
    protected   Transform       hp_bar;
    protected   SummonsLife     life;
    protected   float           startTime;
    protected   float           nextTime;
    private     Player          srt_player;
    private     ObjectManager   srt_objectManager;
    
    //각각 캐릭터 정보 파싱해서 딜레이에 영향 주기.
    public struct STATUS
    {
        public int      lv;
        public float    hp;
        public float    power;
        public float    defense;
        public float    removeTime;
        public float    coolTime;
    };
    public virtual void Init()
    {
        base.Start();
        startTime           = 0.0f;
        nextTime            = startTime + 1.0f;
        srt_player          = GameObject.FindObjectOfType<Player>();
        srt_objectManager   = GameObject.FindObjectOfType<ObjectManager>();
        
    }
    protected void Destroy()
    {
        destroy = true;
        Debug.Log("Destroy");
    }
    protected void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<Enemy>();
            HP_Control(col);
        }
    }
    protected void HP_Control(Collider col)
    {
        if (startTime == 0.0f)
        {
            startTime = Time.time;
            nextTime = startTime + 1.0f;
            if (col.GetComponent<Enemy>().attack_check == true && col.GetComponent<Enemy>().current_target == this.gameObject)
            {
                life.m_HP -= (col.GetComponent<Enemy>().status.power - this.status.defense);
                if (life.m_HP <= 0.0f)
                {
                    Destroy();
                }
            }
        }
        if (Time.time > nextTime && startTime != 0)
        {
            startTime = 0;
        }
    }
    public void Set_Status(ref SummonsBase _base, int _lv, float _hp, float _power, float _defense, float _removeTime, float _coolTime)
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
    //public Enemy Get_Enemy
    //{
    //    get { return srt_enemy; }
    //}
    public ObjectManager Get_GameManager
    {
        get { return srt_objectManager; }
    }
}
