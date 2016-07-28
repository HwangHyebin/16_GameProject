﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[ExecuteInEditMode]
public class Player : CharacterBase
{
    public  PLAYER_ANIMATOR         player_anim;
    public  PLAYER_SKILLS           player_skills;
    public  Transform               hp_bar;
    private ControlPlayerHPBar      life;
    [HideInInspector]
    public  bool                    attack_check        = false;
    private JoystickControl         srt_input;
    private AttackButton            srt_attackButton;
    private PlayerStateMachine      player_state;

    public enum PLAYER_ANIMATOR
    {
        DONE = -1,
        IDLE = 0,
        RUN,
        ATTACK,
        DEAD
    };
    public enum PLAYER_SKILLS
    {
        DONE = -1,
        ARCHER = 0,
        MAGICIAN,
        PIRATE,
        SHIELD
    };
    public sealed override void init()
    {
        base.Start();
        position            = this.transform.position;
        my_body             = GetComponent<Rigidbody>();
        player_state        = new PlayerStateMachine();
        player_skills       = PLAYER_SKILLS.DONE;
        srt_input           = GameObject.FindObjectOfType<JoystickControl>() as JoystickControl;
        srt_attackButton    = GameObject.FindObjectOfType<AttackButton>() as AttackButton;

        hp_bar = GameObject.FindObjectOfType<ControlPlayerHPBar>().transform;
        life = hp_bar.GetComponent<ControlPlayerHPBar>();

        player_state.Init(this);
    }
    public sealed override void update()
    {
        Debug.Log("player attack= " + attack_check);
        player_state.Update();
    }
    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.tag == "Enemy")
    //    {
    //        Debug.Log("충돌!");
    //        if (attack_check == true)
    //        {
    //            col.gameObject.SendMessage("Target_Change", true);
    //        }
    //        if (col.GetComponent<Enemy>().attack_check == true && col.GetComponent<Enemy>().target == this.gameObject)
    //        {
    //            if (player_skills != PLAYER_SKILLS.SHIELD)
    //            {
    //                Debug.Log("player hp 줄어듦!");
    //                life.m_HP -= (col.GetComponent<Enemy>().status.power - this.status.defense);
    //            }
    //        }
    //        Debug.Log("player enemy에 충돌");
    //    }
    //}
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<Enemy>();
            HP_Control(col);
        }
    }
    private void HP_Control(Collider col)
    {
        if (startTime == 0.0f)
        {
            startTime = Time.time;
            nextTime = startTime + 1.0f;
            Debug.Log("enemy attack check = " + col.GetComponent<Enemy>().attack_check);
            //Debug.Log("enemy target = " + col.GetComponent<Enemy>().target);

            if (col.GetComponent<Enemy>().attack_check == true) 
                //&&col.GetComponent<Enemy>().target == this.gameObject) //enemy가 공격상태면
            {
                Debug.Log("enemy의 attack!");
                if (player_skills != PLAYER_SKILLS.SHIELD)
                {
                    Debug.Log("player hp 줄어듦!");
                    life.m_HP -= (col.GetComponent<Enemy>().status.power - this.status.defense);
                }
            }
            //else if (col.GetComponent<Enemy>().attack_check == true &&
            //        col.GetComponent<Enemy>().target != this.gameObject) //enemy가 공격상태면
            //{
            //    col.gameObject.SendMessage("Target_Check");
            //}
        }
        if (Time.time > nextTime && startTime != 0)
        {
            startTime = 0;
        }
    }
    public AttackButton Get_AttackButton
    {
        get { return srt_attackButton; }
    }
    public PlayerStateMachine Get_PlayerState
    {
        get { return player_state;}
    }
    public JoystickControl Get_Joystick
    {
        get { return srt_input; }
    }
}
