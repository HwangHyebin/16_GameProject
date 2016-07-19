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
        //startTime   = Time.time;
        //nextTime    = startTime + delay;
        ////skills 생성 부분
        
           
    }
    public sealed override void Execute(Player _player)
    {
        //Debug.Log("PlayerSkillsExecute");
        //if (nextTime < Time.time && Time.time != 0)
        //{
        //    Debug.Log("nexttime = "+nextTime);
        //    Debug.Log("Time.time = " + Time.time);
        //    _player.Get_PlayerState.ChangeState(PlayerIdle.Instance);
        //}
        //if (_player.Get_Joystick.drag == true) // move
        //{
        //    _player.Get_PlayerState.ChangeState(PlayerMove.Instance);
        //}
        //if (_player.Get_Button.Get_AttackButton() == true) // default attack
        //{
        //    _player.Get_PlayerState.ChangeState(PlayerAttack.Instance);
        //}
    }
    public sealed override void Exit(Player _player)
    {
        //if (_player.player_skills == Player.PLAYER_SKILLS.SKILL_1)
        //{
        //    _player.Get_Button.active_skillButtons[0] = false;
        //}
        //else if (_player.player_skills == Player.PLAYER_SKILLS.SKILL_2)
        //{
        //    _player.Get_Button.active_skillButtons[1] = false;
        //}
        //else if (_player.player_skills == Player.PLAYER_SKILLS.SKILL_3)
        //{
        //    _player.Get_Button.active_skillButtons[2] = false;
        //}
        //_player.player_skills = Player.PLAYER_SKILLS.DONE;
        //Debug.Log(""+_player.Get_Button.active_skillButtons);
    }
    public sealed override void Clear()
    {
    }
   
    //for (int i = 0; i < _player.string_array.Length; ++i)
    //{
    //    _player.Get_SkillFactory.CreateSkillCharacter(_player.string_array[i], ref _player.skill_array[i]);
    //}
}
