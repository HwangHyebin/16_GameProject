using UnityEngine;
using System.Collections;

public class PlayerIdle : PlayerState
{
    private static PlayerIdle instance;
    public static PlayerIdle Instance
    {
        get
        {
            if ( instance == null )
                instance = new PlayerIdle();
            
            return instance;
        }
    }
    public sealed override void Enter(Player _player)
    {
        _player.player_anim     = Player.PLAYER_ANIMATOR.IDLE;
        _player.player_skills   = Player.PLAYER_SKILLS.DONE;
        _player.anim.Play("Base Layer.idle1");
    }
    public sealed override void Execute(Player _player)
    {
        if (_player.Srt_Input.drag == true)
        {
            _player.Player_State.ChangeState(PlayerMove.Instance);
        }
        if (_player.Get_AttackButton.GetPressButton() == true)
        {
            _player.Player_State.ChangeState(PlayerAttack.Instance);
        }
        for (int i = 0; i < 3; ++i)
        {
            if (_player.srt_skillButton[i].GetPressButton() == true)
            {
                switch (i)
                {
                    case 0 :
                        _player.player_skills = Player.PLAYER_SKILLS.SKILL_1;
                        break;
                    case 1 :
                        _player.player_skills = Player.PLAYER_SKILLS.SKILL_2;
                        break;
                    case 2 :
                        _player.player_skills = Player.PLAYER_SKILLS.SKILL_3;
                        break;
                }
                _player.Player_State.ChangeState(PlayerSkills.Instance);
            }
        }
    }
    public sealed override void Exit(Player _player)
    {
    }
    public sealed override void Clear()
    {
    }
}
