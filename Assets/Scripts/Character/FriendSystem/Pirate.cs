using UnityEngine;
using System.Collections;

public class Pirate : SkillCharacterBase 
{
    public override void Init()
    {
        base.Init();
        Get_Player.player_skills = Player.PLAYER_SKILLS.PIRATE;
    }
    private void Update()
    {
    }
}
