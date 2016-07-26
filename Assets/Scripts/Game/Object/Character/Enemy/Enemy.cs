using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Enemy : CharacterBase 
{
    public ENEMY_ANIMATOR enemy_anim;
    private EnemyStateMachine enemy_state;
    private Life srt_life;
    public Transform hp_bar;
    private List<GameObject> Attack_list;
    private Enemy _enemy;

    //public  Transform           hp_bar;
 
    //private bool                m_attacked_enemy;
    //private bool                m_hit_skillCharacter;
    //private Transform hp;
    
    //몬스터 체력 150 데미지 25
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
        Attack_list = new List<GameObject>();
        //m_attacked_enemy = false;
        //m_hit_skillCharacter = false;
       
        hp_bar = gameObject.transform.parent.FindChild("HP");
        srt_life = hp_bar.GetComponent<Life>();

        enemy_state.Init(this);
        

        //enemy의 y값도 계속 바뀜
    }
    public sealed override void update()
    {
        enemy_state.Update();
    }
    public void Enemy_Attacked(string _str)
    {
        Debug.Log("enemy / sender = " + _str);
        Debug.Log("enemy attacked!");
    }
    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Magician" || 
    //        col.gameObject.tag == "Archer" ||
    //        col.gameObject.tag == "Pirate")
    //    {
    //        //attacked_enemy = true;
    //    }
    //    else if ( col.gameObject.tag =="Skill")
    //    {
    //        for (int i = 0; i < Get_GameManager._enemyArray.Length; ++i)
    //        {
    //            gameObject.SendMessage("")
    //            //Life life = hp.GetComponent<Life>();
    //            srt_life[i].m_HP -= status.power - status.defense;
    //        }
    //        m_hit_skillCharacter = true;
    //    }
    //}
    public sealed override void clean()
    {
    }
    //private void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Player" && enemy_anim == ENEMY_ANIMATOR.ATTACK)
    //    {
    //        enemy_state.ChangeState(EnemyAttack.Instance);
    //    }
    //}
    //public bool Attacked_Enemy
    //{
    //    set { m_attacked_enemy = false; }
    //    get { return m_attacked_enemy; }
    //}
    //public bool Hit_SkillCharacter
    //{
    //    set { m_hit_skillCharacter = false; }
    //    get { return m_hit_skillCharacter; }
    //}
    public EnemyStateMachine Enemy_State
    {
        get{ return enemy_state; }
    }
}
