using UnityEngine;
using System.Collections;

public class Pirate : SummonsBase 
{
    //public Animator anim;
    public override void Init()
    {
        base.Init();
        Get_Player.player_skills = Player.PLAYER_SKILLS.PIRATE;
        hp_bar = gameObject.transform.FindChild("HP");
        life = hp_bar.GetComponent<SummonsLife>();
        //anim.speed = 1.2f;
    }
    private void Update()
    {
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log("Pirate enemy와 충돌");
            if (col.GetComponent<Enemy>().attack_check == true ||
                col.GetComponent<Enemy>().enemy_anim == Enemy.ENEMY_ANIMATOR.ATTACK)
            {
                Debug.Log("Pirate hp깎임");
                //life.m_HP -= (col.GetComponent<Enemy>().status.power - this.status.defense);
            }
        }
    }

}
