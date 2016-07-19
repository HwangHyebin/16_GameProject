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

            //_player.player_skills = _player.Get_Button.Check_Push_SkillButton();
            //if (_player.player_skills != Player.PLAYER_SKILLS.DONE)
            //{
            //    _player.Get_PlayerState.ChangeState(PlayerSkills.Instance);
            //}

            //_player.position.x = _player.Srt_Input.Horizontal();
            //_player.position.z = _player.Srt_Input.Vertical();
            //_player.transform.position += (_player.position).normalized * Time.deltaTime * speed;
            //float ang = ContAngle(_player.transform.forward, _player.position);

            //if (ang > 3.0f && ang < 183.0f)
            //{
            //    _player.transform.Rotate(Vector3.up * Time.deltaTime * 200);
            //}
            //else if (ang > 184.0f && ang < 362.0f)
            //{
            //    _player.transform.Rotate(-Vector3.up * Time.deltaTime * 200);
            //}
        }
        else
        {
            _player.Get_PlayerState.ChangeState(PlayerIdle.Instance);
        }
    }
    public sealed override void Exit(Player _player)
    {
    }
    public sealed override void Clear()
    {
    }
    private float ContAngle(Vector3 fwd, Vector3 targetDir)
    {
        float angle = Vector3.Angle(fwd, targetDir);

        if (AngleDir(fwd, targetDir, Vector3.up) == -1)
        {
            angle = 360.0f - angle;
            if (angle > 359.9999f)
                angle -= 360.0f;
            return angle;
        }
        else
            return angle;
    }
    private int AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir); //벡터의 외적을 사용해서 어디가 앞인지를 판단.
        float dir = Vector3.Dot(perp, up); // 앞과 위의 벡터를 내적함으로써 그의 법선벡터를 구하여 x축을 찾음.

        if (dir > 0.0)
            return 1;
        else if (dir < 0.0)
            return -1;
        else
            return 0;
    }
}
