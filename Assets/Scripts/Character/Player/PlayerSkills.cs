using UnityEngine;
using System.Collections;

public class PlayerSkills : PlayerState
{
    private static PlayerSkills instance;
    public static PlayerSkills Instance
    {
        get
        {
            if (instance == null)
                instance = new PlayerSkills();
            return instance;
        }
    }
    public sealed override void Enter(Player _player)
    {
        Debug.Log("PlayerSkillsEnter");
    }
    public sealed override void Execute(Player _player)
    {
        //skills
        if (_player.player_skills == Player.PLAYER_SKILLS.SKILL_1)
        {
        }
        else if (_player.player_skills == Player.PLAYER_SKILLS.SKILL_2)
        {
        }
        else if (_player.player_skills == Player.PLAYER_SKILLS.SKILL_3)
        {
        }

        if (_player.Srt_Input.drag == true) // move
        {
            _player.Player_State.ChangeState(PlayerMove.Instance);
        }
        if (_player.Get_AttackButton.GetPressButton() == true) // default attack
        {
            _player.Player_State.ChangeState(PlayerAttack.Instance);
        }
    }
    public sealed override void Exit(Player _player)
    {
    }
    public sealed override void Clear()
    {
    }
}
