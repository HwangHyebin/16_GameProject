using UnityEngine;
using System.Collections;

public class Magician : SummonsBase
{
    public  GameObject      effect_prefab;
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
        GameObject effect = Instantiate(effect_prefab, new Vector3(this.transform.position.x, 3.8f, this.transform.position.z), Quaternion.identity) as GameObject;
        attack_col.gameObject.SetActive(true);
        CancelInvoke("Meteo");
        Destroy(effect, 2.0f);
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
    protected void OnTriggerStay(Collider col)
    {
        base.OnTriggerStay(col);
    }
}
