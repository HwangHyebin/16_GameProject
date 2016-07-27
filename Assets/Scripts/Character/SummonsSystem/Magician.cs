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
        attack_col.gameObject.SetActive(false);
        Set_CastTime(status.lv);
    }
    private void Start()
    {
        Invoke("Meteo", castTime);
        Invoke("Destroy", (status.removeTime + 10.0f));
    }
    private void Meteo()
    {
        anim.SetInteger("animation", 1);
        anim.Play("Base Layer.atk3");
        attack_col.gameObject.SetActive(true);
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
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("magician enemy와 충돌");
            if (col.gameObject.GetComponent<Enemy>().attack_check == true && col.gameObject.GetComponent<Enemy>().target == this.gameObject)
            {
                Debug.Log("magician hp깎임");
                life.m_HP -= (col.gameObject.GetComponent<Enemy>().status.power - this.status.defense);
            }
        }
    }
    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.tag == "Enemy")
    //    {
    //        Debug.Log("magician enemy와 충돌");
    //        if (col.GetComponent<Enemy>().attack_check == true && col.GetComponent<Enemy>().target == this.gameObject)
    //        {
    //            Debug.Log("magician hp깎임");
    //            life.m_HP -= (col.GetComponent<Enemy>().status.power - this.status.defense);
    //        }
    //    }
    //}
}
