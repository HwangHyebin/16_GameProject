using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Enemy : CharacterBase 
{
    [HideInInspector]
    public GameObject target;
    [HideInInspector]
    public  bool                attack_check        = false;
    public  bool                collider_check      = false;
    public  ENEMY_ANIMATOR      enemy_anim;

    private bool                player_attack_check = false;
    private EnemyLife           life;
    private Transform           hp_bar;
    private EnemyStateMachine   enemy_state;
    
    public enum ENEMY_ANIMATOR
    {
        DONE = -1,
        IDLE = 0,
        ATTACK,
        DEAD
    };
    public sealed override void init()
    {
        base.Start();
        position    = this.transform.position;
        //_collider    = GetComponent<CapsuleCollider>();
        enemy_state = new EnemyStateMachine();
        hp_bar      = gameObject.transform.parent.FindChild("HP");
        life        = hp_bar.GetComponent<EnemyLife>();
        target      = GameObject.FindObjectOfType<Player>().gameObject;
        enemy_state.Init(this);
        //enemy의 y값도 계속 바뀜
    }
    public sealed override void update()
    {
        enemy_state.Update();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Magician")
        {
            life.m_HP -= (col.transform.parent.GetComponent<Magician>().status.power - this.status.defense);
        }
        else if (col.tag == "Archer")
        {
            life.m_HP -= (col.transform.parent.GetComponent<Archer>().status.power - this.status.defense);
        }
        else if (col.tag == "Pirate")
        {
            life.m_HP -= (col.transform.parent.GetComponent<Pirate>().status.power - this.status.defense);
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            Component component = col.GetComponent<Player>();
            HP_Control(col);
        }
    }
    private void HP_Control(Collider col)
    {
        if (startTime == 0.0f)
        {
            startTime = Time.time;
            nextTime = startTime + 1.0f;
            
            Debug.Log("Enemy 플레이어와 충돌!");
            Debug.Log(col.name);
            if (col.GetComponent<Player>().attack_check == true ||
                col.GetComponent<Player>().player_anim == Player.PLAYER_ANIMATOR.ATTACK)
            {
                Debug.Log("Enemy hp 줄어듦!");
                life.m_HP -= (col.GetComponent<Player>().status.power - this.status.defense);
            }
        }
        if (Time.time > nextTime && startTime != 0)
        {
            startTime = 0;
        }
    }
    //private void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        //Debug.Log("Enemy 플레이어와 충돌!");
    //        Debug.Log("attack check = " + col.gameObject.GetComponent<Player>().attack_check);
    //        Debug.Log("attack anim = " + col.gameObject.GetComponent<Player>().player_anim);
    //        if (col.gameObject.GetComponent<Player>().attack_check == true)
    //        {
    //            Debug.Log("Enemy hp 줄어듦!");
    //            life.m_HP -= (col.gameObject.GetComponent<Player>().status.power - this.status.defense);
    //        }
    //    }
    //}
    public void Target_Change(bool _check)
    {
        Debug.Log("change");
        player_attack_check = _check;
    }
    public void Target_Check()
    {
        if (Get_SkillManager.target != null)
        {
            if (player_attack_check == true)
            {
                target = GameObject.FindObjectOfType<Player>().gameObject;
            }
            else
            {
                target = Get_SkillManager.target;
            }            
        }
        else
        {
            player_attack_check = false;
            target = GameObject.FindObjectOfType<Player>().gameObject;
        }
    }
    public EnemyStateMachine Enemy_State
    {
        get{ return enemy_state; }
    }
}
