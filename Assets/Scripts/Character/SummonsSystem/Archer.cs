using UnityEngine;
using System.Collections;

public class Archer : SummonsBase
{
    private GameObject  prefab;
    //private Vector3     _forward;
    //private Vector3     _right;
    //private Vector3     vec;
    //private GameObject  _bullet;

    public override void Init()
    {
        base.Init();
        Get_Player.player_skills    = Player.PLAYER_SKILLS.ARCHER;
        my_body                     = GetComponent<Rigidbody>();
        prefab                      = Resources.Load("Prefabs/bullet") as GameObject;
        hp_bar = gameObject.transform.FindChild("HP");
        life = hp_bar.GetComponent<SummonsLife>();

        //_forward                    = gameObject.transform.forward;
        //_right                      = gameObject.transform.right;
        //vec                         = new Vector3(_forward.x + _right.x, _forward.y + _right.y, _forward.z + _right.z).normalized;
        //GameObject _bullet          = Instantiate(prefab, gameObject.transform.position, Quaternion.identity) as GameObject;
    }
    private void Start()
    {
        anim.SetInteger("animation", 1);
        anim.Play("Base Layer.atk3");
        Invoke("Destroy", (status.removeTime + 1.0f));
    }
    private void Update()
    { 
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
