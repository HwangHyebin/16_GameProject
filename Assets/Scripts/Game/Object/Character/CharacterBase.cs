﻿using UnityEngine;
using System.Collections;

public class CharacterBase : Actor 
{
    //public  Animator            anim;
    public  Vector3             position;
    public  CharacterBase.S_CHARACTER_STATUS status;

    private Enemy               srt_enemy;
    private Player              srt_player;
    private PlayerHP            srt_player_hp;
    private ObjectManager       srt_gameManager;
    private SkillManager        srt_skillManager;

    public struct S_CHARACTER_STATUS
    {
        public int   lv;
        public float hp;
        public float power;
        public float defense;
    };

    protected virtual void Start()
    {
        srt_enemy           = GameObject.FindObjectOfType<Enemy>() as Enemy;
        srt_player          = GameObject.FindObjectOfType<Player>() as Player;
        srt_player_hp       = GameObject.FindObjectOfType<PlayerHP>() as PlayerHP;
        srt_gameManager     = ObjectManager.Instance;
        srt_skillManager    = GameObject.FindObjectOfType<SkillManager>() as SkillManager;
    }
    public virtual void init() { }
    public virtual void update(){}
    public virtual void clean(){}
    public void Set_Character_Status(int _lv, float _hp, float _power, float _defense)
    {
        status.lv = _lv;
        status.hp = _hp;
        status.power = _power;
        status.defense = _defense;
    }
    public Player Get_Player
    {
        get{return srt_player;}
    }
    public PlayerHP Get_Player_HP
    {
        get {return srt_player_hp;}
    }
    public Enemy Get_Enemy
    {
        get{return srt_enemy;}
    }
    public ObjectManager Get_GameManager
    {
        get{return srt_gameManager;}
    }
    public SkillManager Get_SkillManager
    {
        get {return srt_skillManager;}
    }
}