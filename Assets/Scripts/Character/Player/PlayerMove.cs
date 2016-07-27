using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : PlayerState
{
    private static PlayerMove instance;
    public static PlayerMove Instance
    {
        get
        {
            if (instance == null)
                instance = new PlayerMove();

            return instance;
        }
    }
    public sealed override void Enter(Player _player)
    {
        _player.my_body.velocity = Vector3.zero;
        _player.player_anim = Player.PLAYER_ANIMATOR.RUN;
        _player.anim.Play("Base Layer.run");
    }
    public sealed override void Execute(Player _player)
    {
        float speed = 5.0f;

        if (_player.Get_Joystick.drag == true)
        {
            _player.transform.position += (_player.transform.forward * speed * Time.deltaTime);
            Vector3 Velocity = (_player.Get_Joystick.stick.position - _player.Get_Joystick.defaultCenter);
            Velocity.z = Velocity.y;
            Velocity.y = 0.0f;
            Velocity.Normalize();
            _player.transform.forward += (Velocity * 100 * Time.deltaTime);

            _player.Get_SkillManager.Create_Skill();
        }
        else
        {
            _player.Get_PlayerState.ChangeState(PlayerIdle.Instance);
        }
    }
    public sealed override void Exit(Player _player)
    {
    }
}
