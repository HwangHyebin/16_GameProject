using UnityEngine;
using System.Collections;

public class CharacterBase : Actor 
{
    public      Vector3                             position;
    public      CharacterBase.S_CHARACTER_STATUS    status;
    protected   float                               startTime;
    protected   float                               nextTime;
    //public      CapsuleCollider                     _collider;
    private     ObjectManager                       srt_objectManager;
    private     SkillManager                        srt_skillManager;

    public struct S_CHARACTER_STATUS
    {
        public int   lv;
        public float hp;
        public float power;
        public float defense;
    };
    protected virtual void Start()
    {
        base.Start();
        startTime = 0.0f;
        nextTime = startTime + 1.0f;
        srt_objectManager   = GameObject.FindObjectOfType<ObjectManager>() as ObjectManager;
        srt_skillManager    = GameObject.FindObjectOfType<SkillManager>() as SkillManager;
    }
    public virtual void init() {}
    public virtual void update(){}
    public void Set_Character_Status(int _lv, float _hp, float _power, float _defense)
    {
        status.lv       = _lv;
        status.hp       = _hp;
        status.power    = _power;
        status.defense  = _defense;
    }
    public ObjectManager Get_GameManager
    {
        get { return srt_objectManager; }
    }
    public SkillManager Get_SkillManager
    {
        get { return srt_skillManager; }
    }
}
