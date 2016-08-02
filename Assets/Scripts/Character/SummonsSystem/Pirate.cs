using UnityEngine;
using System.Collections;

public class Pirate : SummonsBase 
{
    private Transform[]     spwanPoint_array;
    private GameObject      prefab;
    private GameObject[]    _bullet;
    private int             array_count;

    public override void Init()
    {
        base.Init();
        Get_Player.player_skills    = Player.PLAYER_SKILLS.PIRATE;
        hp_bar                      = gameObject.transform.FindChild("HP");
        life                        = hp_bar.GetComponent<SummonsLife>();
        Set_Init();
        Bullet_Instance();

        anim.SetInteger("animation", 1);
        anim.Play("Base Layer.atk3");
    }
    private void start()
    {
        anim.SetInteger("animation", 0);

        //반복하기
        //Invoke("Destroy", (status.removeTime + 1.0f));
        //Invoke("Bullet_Destroy", 2.0f);
    }
    private void Update()
    {
        for (int i = 0; i < array_count; ++i)
        {
            if (_bullet[i] != null)
            {
                _bullet[i].transform.Translate(spwanPoint_array[i].transform.forward * 2.0f * Time.deltaTime);
            }
        }
    }
    private void Bullet_Destroy()
    {
        for (int i = 0; i < array_count; ++i)
        {
            Destroy(_bullet[i].gameObject, 0.1f);
        }
        CancelInvoke("Bullet_Destroy");
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
    private void Set_Init() 
    {
        array_count = 4;
        spwanPoint_array    = new Transform[array_count];
        prefab              = Resources.Load("Prefabs/bullet") as GameObject;
        
        for (int i = 0; i < spwanPoint_array.Length; ++i)
        {
            string ObjectName = string.Format("spwanPoint{0:0}", (i + 1));
            spwanPoint_array[i] = GameObject.Find(ObjectName).transform;
        }
    }
    private void Bullet_Instance()
    {
        _bullet = new GameObject[array_count];
        for (int i = 0; i < spwanPoint_array.Length; ++i)
        {
            _bullet[i] = Instantiate(prefab, spwanPoint_array[i].position, Quaternion.identity) as GameObject;
            _bullet[i].tag = "Pirate";
        }
       
    }
}
