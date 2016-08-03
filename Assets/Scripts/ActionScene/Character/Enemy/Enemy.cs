using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Enemy : CharacterBase 
{
    [HideInInspector]
    public GameObject current_target;

    [HideInInspector]
    public  bool                attack_check        = false;
    public  ENEMY_ANIMATOR      enemy_anim;

    private EnemyLife           life;
    private Transform           hp_bar;
    private EnemyStateMachine   enemy_state;

    private bool _test = false;
    
    public enum ENEMY_ANIMATOR
    {
        DONE = -1,
        IDLE = 0,
        ATTACK,
        DEAD
    };
    private void Start()
    {
        current_target = Get_SkillManager.target;
    }
    public sealed override void init()
    {
        base.Start();
        position    = this.transform.position;
        enemy_state = new EnemyStateMachine();
        hp_bar      = gameObject.transform.parent.FindChild("HP");
        life        = hp_bar.GetComponent<EnemyLife>();
        
        enemy_state.Init(this);
    }
    public sealed override void update()
    {
        enemy_state.Update();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Magician")
        {
            if (col.transform.parent.GetComponent<Magician>().status.power > this.status.defense)
                life.m_HP -= (col.transform.parent.GetComponent<Magician>().status.power - this.status.defense);
        }
        else if (col.tag == "Archer")
        {
            if (GameObject.FindObjectOfType<Archer>().status.power > this.status.defense)
                life.m_HP -= (GameObject.FindObjectOfType<Archer>().status.power - this.status.defense);
        }
        else if (col.tag == "Pirate")
        {
            if (GameObject.FindObjectOfType<Pirate>().status.power > this.status.defense)
                life.m_HP -= (GameObject.FindObjectOfType<Pirate>().status.power - this.status.defense);
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Player>();
            HP_Control(col);
        }
    }
    private void HP_Control(Collider col)
    {
        if (startTime == 0.0f)
        {
            startTime = Time.time;
            nextTime = startTime + 1.0f;

            if (col.GetComponent<Player>().attack_check == true)
            {
                life.m_HP -= (col.GetComponent<Player>().status.power - this.status.defense);
            }
        }
        if (Time.time > nextTime && startTime != 0)
        {
            startTime = 0;
        }
    }
    private void Target_Change(GameObject _target)
    {
        current_target = _target;
    }
    public void Target_Check()
    {
        current_target = Get_SkillManager.target;
    }
    public EnemyStateMachine Enemy_State
    {
        get{ return enemy_state; }
    }
}
