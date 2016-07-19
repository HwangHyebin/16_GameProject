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
        //_player.player_skills   = Player.PLAYER_SKILLS.DONE;
        _player.anim.Play("Base Layer.idle1");
    }
    public sealed override void Execute(Player _player)
    {
        if (_player.Get_Joystick.drag == true)
        {
            _player.Get_PlayerState.ChangeState(PlayerMove.Instance);
        }
        if (_player.Get_AttackButton.GetPressButton() == true)
        {
            _player.Get_PlayerState.ChangeState(PlayerAttack.Instance);
        }

        //_player.player_skills = _player.Get_Button.Check_Push_SkillButton();
        //if (_player.player_skills != Player.PLAYER_SKILLS.DONE)
        //{
        //    _player.Get_PlayerState.ChangeState(PlayerSkills.Instance);
        //}
    }
    public sealed override void Exit(Player _player)
    {
    }
    public sealed override void Clear()
    {
    }
}
