using UnityEngine;
using System.Collections;

public class Magician : SummonsBase
{
    public  SphereCollider  attack_col;
    private float           castTime;
   
    public override void Init()
    {
        base.Init();
        Get_Player.player_skills    = Player.PLAYER_SKILLS.MAGICIAN;
        attack_col                  = GetComponentInChildren<SphereCollider>();
        attack_col.radius           = 0.0f;
        castTime                    = 5.0f;
    }
    private void Start()
    {
        Invoke("Meteo", castTime);
        Invoke("Destroy", (status.removeTime + 1.0f));
    }
    private void Update()
    {
        //Attacked_SkillCharacter();
    }
    public void Magician_Attacked(string _str)
    {
        Debug.Log("Magician / sender = " + _str);
        Debug.Log("Magician attacked!");
    }
    private void Meteo()
    {
        attack_col.radius = 3.0f;
    }
    //private void OnTriggerEnter(Collider col)
    //{
    //    Debug.Log(col);
    //    if (col.gameObject.tag == "Enemy")
    //    {
    //        for (int i = 0; i < Get_GameManager._enemyArray.Length; ++i)
    //        {
    //            life[i].m_HP -= 10.0f;//(status.power - Get_Enemy.status.defense);
    //            Debug.Log("magician =" + life[0].m_HP);
    //        }
    //    }
    //}
}
