using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Enemy : CharacterBase 
{
    public  Transform           hp_bar;
    public  ENEMY_ANIMATOR      enemy_anim;
    private EnemyStateMachine   enemy_state;
    private Life[]              srt_life;
    private bool                m_attacked_enemy;
    private bool                m_hit_skillCharacter;

    private Transform hp;
    
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
        m_attacked_enemy = false;
        m_hit_skillCharacter = false;
        srt_life = new Life[Get_GameManager._enemyArray.Length];
        for (int i = 0; i < Get_GameManager._enemyArray.Length; ++i)
        {
            hp_bar = Get_GameManager._enemyArray[i].transform.parent.FindChild("HP");
            srt_life[i] = hp_bar.GetComponent<Life>();
        }
        enemy_state.Init(this);
        //enemy의 y값도 계속 바뀜
    }
    public sealed override void update()
    {
        enemy_state.Update();
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
    public bool Attacked_Enemy
    {
        set { m_attacked_enemy = false; }
        get { return m_attacked_enemy; }
    }
    public bool Hit_SkillCharacter
    {
        set { m_hit_skillCharacter = false; }
        get { return m_hit_skillCharacter; }
    }
    public EnemyStateMachine Enemy_State
    {
        get{ return enemy_state; }
    }
}
