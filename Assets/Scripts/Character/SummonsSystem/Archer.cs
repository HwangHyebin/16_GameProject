using UnityEngine;
using System.Collections;

public class Archer : SummonsBase
{
    private GameObject  prefab;
    private Transform   spwanPoint;
    private Vector3 right_vec;
   
    public override void Init()
    {
        base.Init();
        Get_Player.player_skills    = Player.PLAYER_SKILLS.ARCHER;
        my_body                     = GetComponent<Rigidbody>();
        prefab                      = Resources.Load("Prefabs/bullet") as GameObject;
        hp_bar                      = gameObject.transform.FindChild("HP");
        life                        = hp_bar.GetComponent<SummonsLife>();

        spwanPoint                  = gameObject.transform.FindChild("spwanPoint");
        GameObject _bullet          = Instantiate(prefab, spwanPoint.position, Quaternion.identity) as GameObject;
    }
    private void Start()
    {
        anim.SetInteger("animation", 1);
        anim.Play("Base Layer.atk3");
        Invoke("Destroy", (status.removeTime + 1.0f));
    }
    private void Update()
    {
        Vector3 _forward = this.transform.forward;
        Vector3 _riget = this.transform.right;

        right_vec = new Vector3(_forward.x + _riget.x, _forward.y + _riget.y, _forward.z + _riget.z);

        //float dis = Vector3.Magnitude(this.transform.position - _bullet.transform.position);
        //Debug.Log("distance = " + dis);
        //if (dis > 5.0f)
        //{
        //    Destroy(_bullet, 0.1f);
        //}
        //일정 범위이상 멀어지면 사라지게 하기.
        // archer와 자신의 position을 이용해 거리를 체크해서 bullet을 destroy
        //StartCoroutine("Bullet");
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
    IEnumerator Bullet()
    {
        
        //prefab.GetComponent<Rigidbody>().AddForce(spwanPoint.forward * 10.0f * Time.deltaTime);
        yield return new WaitForSeconds(3.0f);
    }
}
