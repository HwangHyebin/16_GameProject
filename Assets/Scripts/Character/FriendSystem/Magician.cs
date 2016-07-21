using UnityEngine;
using System.Collections;

public class Magician : SkillCharacterBase 
{
    public override void Init()
    {
        base.Init();
        Get_Player.player_skills = Player.PLAYER_SKILLS.MAGICIAN;
    }
    private void Update()
    {
    }
}
