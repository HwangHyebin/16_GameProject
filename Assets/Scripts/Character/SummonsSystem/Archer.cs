using UnityEngine;
using System.Collections;

public class Archer : SummonsBase
{
    private GameObject      prefab;
    private GameObject[]    _bullet;
    private Transform       spwanPoint;
    private int             _bulletCount;

    public override void Init()
    {
        base.Init();
        Get_Player.player_skills    = Player.PLAYER_SKILLS.ARCHER;
        hp_bar                      = gameObject.transform.FindChild("HP");
        life                        = hp_bar.GetComponent<SummonsLife>();
        Bullet_Init();
        anim.SetInteger("animation", 1);
        anim.Play("Base Layer.atk3");
    }
    private void Start()
    {
        anim.SetInteger("animation", 0);
        Invoke("Destroy", (status.removeTime + 1.0f));
        Invoke("Bullet_Destroy", 3.0f);
    }
    private void Update()
    {
        for (int i = 0; i < _bulletCount; ++i)
        {
            if (_bullet[i] != null)
            {
                Vector3 right_vec = new Vector3((transform.forward.x + transform.right.x), (transform.forward.y + transform.right.y), (transform.forward.z + transform.right.z)).normalized;
                Vector3 left_vec = new Vector3((transform.forward.x + (transform.right.x * -1.0f)), (transform.forward.y + (transform.right.y * -1.0f)), (transform.forward.z + (transform.right.z * -1.0f))).normalized;

                _bullet[0].transform.Translate(transform.forward * 2.0f * Time.deltaTime);
                _bullet[1].transform.Translate(right_vec * 2.0f * Time.deltaTime);
                _bullet[2].transform.Translate(left_vec * 2.0f * Time.deltaTime);
            }
        }
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
    private void Bullet_Destroy()
    {
        for (int i = 0; i < _bulletCount; ++i)
        {
            Destroy(_bullet[i].gameObject, 0.1f);
        }
        CancelInvoke("Bullet_Destroy");
    }
    private void Bullet_Init()
    {
        spwanPoint      = gameObject.transform.FindChild("spwanPoint");
        prefab          = Resources.Load("Prefabs/bullet") as GameObject;
        _bulletCount    = 3;
        _bullet         = new GameObject[_bulletCount];

        for (int i = 0; i < _bulletCount; ++i)
        {
            _bullet[i] = Instantiate(prefab, spwanPoint.position, Quaternion.identity) as GameObject;
            _bullet[i].tag = "Archer";
        }
    }
}
