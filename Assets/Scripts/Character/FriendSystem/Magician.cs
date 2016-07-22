using UnityEngine;
using System.Collections;

public class Magician : SkillCharacterBase
{
    public SphereCollider attack_col;
    //체력이 100, 데미지 100

    public override void Init()
    {
        base.Init();
        Get_Player.player_skills    = Player.PLAYER_SKILLS.MAGICIAN;
        attack_col                  = GetComponentInChildren<SphereCollider>();
        attack_col.radius           = 0.5f;
    }
    private void Start()
    {
        startTime = Time.time;
        delay = 5.0f;
        nextTime = startTime + delay;
    }
    private void Update()
    {
        if (Get_Enemy.enemy_anim == Enemy.ENEMY_ANIMATOR.ATTACK) 
        {
            //if (체력 감소),
            //if(체력 없어지면 없앰).
        }

        if (startTime != 0 && Time.time >= nextTime)
        {
            bool check = true;
            while (check)
            {
                if (attack_col.radius < 3.0f)
                {
                    attack_col.radius += 0.1f;
                }
                check = false;
            }
            Get_Player.player_skills = Player.PLAYER_SKILLS.DONE;
            Destroy(this.gameObject, 0.1f);
        }
    }
}
