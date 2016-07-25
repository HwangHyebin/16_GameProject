using UnityEngine;
using System.Collections;

public class Pirate : SkillCharacterBase 
{
    //public Animator anim;
    public override void Init()
    {
        base.Init();
        Get_Player.player_skills = Player.PLAYER_SKILLS.PIRATE;
        //anim.speed = 1.2f;
    }
    private void Update()
    {
    }
}
