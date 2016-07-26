﻿using UnityEngine;
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
        _player.Get_SkillManager.Create_Skill();
        if (_player.Get_Joystick.drag == true)
        {
            _player.Get_PlayerState.ChangeState(PlayerMove.Instance);
        }
        if (_player.Get_AttackButton.GetPressButton() == true)
        {
            ++combo_count;
        }
        if (_player.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f) //현재 애니메이션이 끝나면
        {
            if (combo_count == 2) 
            {
                _player.anim.SetInteger("combo", 2);
            }
            else if (combo_count >= 3)
            {
                _player.anim.SetInteger("combo", 3);
            }
            if ( startTime == 0 ) // 1번만 들어가게
            {
                startTime               = Time.time;
                nextTime                = startTime + 1.0f; //공격 속도 조절할때 delay 부분 수정해 줄것
                Vector3 _forward        = _player.transform.forward;

                //Debug.Log(AttackManager.Instance.Get_EnemyList);

                for (int i = 0; i < _player.Get_GameManager._enemyArray.Length; ++i) 
				{
                    if (ObjectManager.Instance._enemyArray != null) 
					{
                        Vector3 enemy_vec = (_player.Get_GameManager._enemyArray[i].transform.position - _player.transform.position).normalized;
                        float deg           = Mathf.Acos(Vector3.Dot(_forward, enemy_vec)) * Mathf.Rad2Deg;
                        float distance = Vector3.Magnitude(_player.transform.position - _player.Get_GameManager._enemyArray[i].transform.position);

                        //오른쪽이냐 왼쪽이냐를 알고 싶을때는 right벡터랑 enemy 벡터를 내적해서, 양수면 오른쪽 음수면 왼쪽
                        //float enemy_deg = Mathf.Acos(Vector3.Dot(_forward, pos)) * Mathf.Rad2Deg;
                        //각을 알고싶을때 아크코사인 사용, Rad2Deg는 라디안을 degree로 바꿔줌.(도)

                        if (deg < 45.0f && distance < 1.5f)
						{
                            AttackManager.Instance.AttackHandling("Player", "Enemy");
                            //수정하기 전
                            //Transform hp = _player.Get_GameManager._enemyArray[i].transform.parent.FindChild("HP");
                            //if (hp != null)
                            //{
                            //    Life life = hp.GetComponent<Life>();
                            //    life.m_HP -= (_player.status.power - _player.Get_Enemy.status.defense) * combo_count;
                                
                                //switch (_player.player_skills)
                                //{
                                //    case Player.PLAYER_SKILLS.DONE :
                                //        life.m_HP -= (_player.status.power - _player.Get_Enemy.status.defense) * combo_count;
                                //        break;
                                //    case Player.PLAYER_SKILLS.ARCHER:
                                //        if (_player.Get_Enemy.Enemy_Collision == true)
                                //        {
                                //            _player.Get_Enemy.Enemy_Collision = false;
                                //            life.m_HP -= (_player.Get_SkillManager.skill_array[i].status.power - _player.Get_Enemy.status.defense);
                                //        }
                                //        break;
                                //    case Player.PLAYER_SKILLS.MAGICIAN:
                                //        if (_player.Get_Enemy.Enemy_Collision == true)
                                //        {
                                //            _player.Get_Enemy.Enemy_Collision = false;
                                //            life.m_HP -= (_player.Get_SkillManager.skill_array[i].status.power - _player.Get_Enemy.status.defense);
                                //        }
                                //        break;
                                //    case Player.PLAYER_SKILLS.PIRATE:
                                //        break;
                                //    case Player.PLAYER_SKILLS.SHIELD:
                                //        break;
                                //    default:
                                //        break;
                                //}
                                //switch에 따라 플레이어 스킬을 발동하고 있는지를 구분하여, 그에 따른 데미지를 적용시킴.
                                
                                //life가 넘어가는것 개선하려면 메세지 처리 기반 클래스가 있어야 하는데 이건 시간나면 구조엎고 하는게 좋을듯함.
								//파티클 터지는 것 넣어줄 부분.
							}
							else
							{
								_player.Get_Enemy.enemy_anim = Enemy.ENEMY_ANIMATOR.DEAD;
							}
						}
					}
				//}
            }
            if (Time.time > nextTime && startTime != 0) //1초 후
            {
                if (_player.Get_AttackButton.GetPressButton() == false) //버튼이눌리지 않는다면
                {
                    startTime = 0;
                    combo_count = 0;
                    _player.anim.SetInteger("combo", 0);
                    _player.player_anim = Player.PLAYER_ANIMATOR.IDLE;
                    _player.Get_PlayerState.ChangeState(PlayerIdle.Instance);
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
    //raycast 사용시 맞추는것에 대한 정보 받아와서 hp 깎기.
    //RaycastHit hit;
    //Ray ray = new Ray(_player.transform.position + _player.transform.up * 0.25f, _player.transform.forward);
    //Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 100);

    //if (Physics.Raycast(ray, out hit, 4))
    //{
    //    // hp 줄여주는 부분
    //    Transform hp = hit.transform.parent.FindChild("HP");
    //    if (hp != null)
    //    {
    //        Life life = hp.GetComponent<Life>();
    //        life.m_HP -= 10;
    //        //파티클 터지는 것 넣어줄 부분.
    //    }
    //    else
    //    {
    //        _player.Get_Enemy.enemy_anim = Enemy.ENEMY_ANIMATOR.DEAD;
    //    }
    //}
}