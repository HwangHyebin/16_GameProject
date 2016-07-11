using UnityEngine;
using System.Collections;

public class PlayerAttack : PlayerState
{
    private int                 combo_count = 1;
    private float               startTime;
    private float               nextTime;

    private Transform           prev_hit;
    private static PlayerAttack instance;
    public static PlayerAttack Instance
    {
        get
        {
            if (instance == null)
                instance = new PlayerAttack();
            return instance;
        }
    }
    public sealed override void Enter(Player _player)
    {
        _player.player_anim = Player.PLAYER_ANIMATOR.ATTACK;
        _player.anim.SetInteger("combo", 1);
        _player.anim.Play("Base Layer.ark1");
    }
    public sealed override void Execute(Player _player)
    {
        //float dis = Vector3.Magnitude(_player.transform.position - _player.Get_Enemy.transform.position);

        if (_player.Srt_Input.drag == true)
        {
            _player.Player_State.ChangeState(PlayerMove.Instance);
        }

        if (_player.Get_AttackButton.GetPressButton() == true)
        {
            ++combo_count;
        }
      
        if (_player.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f) //현재 애니메이션이 끝나면
        {
            if (combo_count == 2) // 콤보가 2일때
            {
                _player.anim.SetInteger("combo", 2);
            }
            else if (combo_count >= 3) // 콤보가 3일때
            {
                _player.anim.SetInteger("combo", 3);
            }

            if ( startTime == 0 ) // 1번만 들어가게
            {
                startTime       = Time.time;
                float delay     = 1.0f;
                nextTime        = startTime + delay;
                RaycastHit hit;
                Ray ray = new Ray(_player.transform.position + _player.transform.up * 0.25f, _player.transform.forward);
                Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 100);
             
                if (Physics.Raycast(ray, out hit, 4))
                {
                    // hp 줄여주는 부분
                    Transform hp = hit.transform.parent.FindChild("HP");
                    if (hp != null)
                    {
                        Life life = hp.GetComponent<Life>();
                        life.m_HP -= 10;
                        //파티클 터지는 것 넣어줄 부분.
                    }
                    else
                    {
                        _player.Get_Enemy.enemy_anim = Enemy.ENEMY_ANIMATOR.DEAD;
                    }
                }
            }

            if (Time.time > nextTime && startTime != 0) //1초 후
            {
                if (_player.Get_AttackButton.GetPressButton() == false) //버튼이눌리지 않는다면
                {
                    startTime = 0;
                    combo_count = 0;
                    _player.anim.SetInteger("combo", 0);
                    _player.player_anim = Player.PLAYER_ANIMATOR.IDLE;
                    _player.Player_State.ChangeState(PlayerIdle.Instance);
                }
            }
        }
    }

    public sealed override void Exit(Player _player)
    {
        _player.player_anim = Player.PLAYER_ANIMATOR.IDLE;
    }
    public sealed override void Clear()
    {
    }
}
