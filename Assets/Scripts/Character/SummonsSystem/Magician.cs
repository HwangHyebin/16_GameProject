using UnityEngine;
using System.Collections;

public class Magician : SummonsBase
{
    private SphereCollider  attack_col;
    private float           castTime;
   
    public override void Init()
    {
        base.Init();
        Get_Player.player_skills    = Player.PLAYER_SKILLS.MAGICIAN;
        attack_col                  = GetComponentInChildren<SphereCollider>();
        hp_bar                      = gameObject.transform.FindChild("HP");
        life                        = hp_bar.GetComponent<SummonsLife>();
        attack_col.gameObject.SetActive(false);
        Set_CastTime(status.lv);
    }
    private void Start()
    {
        Invoke("Meteo", castTime);
        Invoke("Destroy", (status.removeTime + 1.0f));
    }
    private void Meteo()
    {
        anim.SetInteger("animation", 1);
        anim.Play("Base Layer.atk3");
        attack_col.gameObject.SetActive(true);
        CancelInvoke("Meteo");
    }
    private void Set_CastTime(int _num)
    {
        if (_num < 7)
            castTime = 5.0f;
        else if (_num < 14 && _num >= 7)
            castTime = 4.0f;
        else if (_num <= 20 && _num >= 14)
            castTime = 3.0f;
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<Enemy>();
            HP_Control(col);
        }
    }
    private void HP_Control(Collider col)
    {
        if (startTime == 0.0f)
        {
            startTime = Time.time;
            nextTime = startTime + 1.0f;
            if (col.GetComponent<Enemy>().attack_check == true && col.GetComponent<Enemy>().current_target == this.gameObject)
            {
                life.m_HP -= (col.GetComponent<Enemy>().status.power - this.status.defense);
            }
        }
        if (Time.time > nextTime && startTime != 0)
        {
            startTime = 0;
        }
    }
}
