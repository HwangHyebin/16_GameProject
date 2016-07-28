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
    public sealed override void init()
    {
        base.Start();
        position    = this.transform.position;
        enemy_state = new EnemyStateMachine();
        hp_bar      = gameObject.transform.parent.FindChild("HP");
        life        = hp_bar.GetComponent<EnemyLife>();
        //current_target = GameObject.FindObjectOfType<Player>().gameObject;
        enemy_state.Init(this);
    }
    public sealed override void update()
    {
        Debug.Log("enemy attack = " + attack_check);
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
            if (col.transform.parent.GetComponent<Archer>().status.power > this.status.defense)
                life.m_HP -= (col.transform.parent.GetComponent<Archer>().status.power - this.status.defense);
        }
        else if (col.tag == "Pirate")
        {
            if (col.transform.parent.GetComponent<Pirate>().status.power > this.status.defense)
                life.m_HP -= (col.transform.parent.GetComponent<Pirate>().status.power - this.status.defense);
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
            //player_attack_check = false;
        }
    }
    private void Target_Change(GameObject _target)
    {
        current_target = _target;
    }

    //public void Target_Change(bool _check)
    //{
    //    target = GameObject.FindObjectOfType<Player>().gameObject;
    //    player_attack_check = _check;
    //}
    //private void think()
    //{
    //    if (리스트가 비었다면)
    //    {
    //        현재 타겟을 플레이어.
    //    }
    //    else(리스트가 차 있다면)
    //    {
    //        if (플레이어가 공격을 하지 않았다면) //공격을 안한다면
    //        {
    //            현재 타겟은 리스트 타겟.
    //        }
    //        else (플레이어가 공격했다면)
    //        {
    //              if(새로운 리스트에 오브젝트가 생기지 않았다면.) - 플레이어
    //              else(리스트에 새로운 오브젝트가 생겼다면) - 새로운 오브젝트
    //            if(리스트목록의 오브젝트가 사라지지 않았다면)
    //                현재의 타겟을 플레이어로 교체.
    //            else(리스트 목록의 오브젝트가 사라졌다면)
    //                플레이어의 공격 상태를 false로 바꿔줌.
    //        }
    //    }
    //}
    public void Target_Check()
    {
        Player player = GameObject.FindObjectOfType<Player>();

        if (Get_SkillManager.target == null)
        {
            current_target = player.gameObject;
        }
        else
        {
            current_target = Get_SkillManager.target;
            //if (_check == false)
            //{
            //    current_target = Get_SkillManager.target;
            //}
            //else
            //{
            //    if (Get_SkillManager.new_Object == true)
            //    {
            //        current_target = Get_SkillManager.target;
            //    }
            //}
        }
    }
        //Player player = GameObject.FindObjectOfType<Player>();

        //if (Get_SkillManager.target == null)
        //{
        //    current_target = player.gameObject;
        //}
        //else
        //{
        //    if (_test == true) // 공격당함
        //    {
        //        if (Get_SkillManager.destroy_Object == false)
        //        {
        //            before_target = Get_SkillManager.target.gameObject;
        //            current_target = player.gameObject;
        //        }
        //        else
        //        {
        //            _test = false;
        //        }
        //    }
        //    else
        //    {
        //        before_target = player.gameObject;
        //        current_target = Get_SkillManager.target.gameObject;
        //    }
            
        //    //if (_test.attack_check == true)
        //    //{
        //    //    target = _test.gameObject;
        //    //}
        //    //else
        //    //{
        //    //    target = Get_SkillManager.target;
        //    //}
        //}
    //}
    public EnemyStateMachine Enemy_State
    {
        get{ return enemy_state; }
    }
}
