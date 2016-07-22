using UnityEngine;
using System.Collections;

public class Archer : SkillCharacterBase
{
    //public GameObject bullet;

    public override void Init()
    {
        base.Init();
        Get_Player.player_skills = Player.PLAYER_SKILLS.ARCHER;
    }
    private void Update()
    {
        //Get_Player.player_skills = Player.PLAYER_SKILLS.DONE;
    }
}
