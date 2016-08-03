using UnityEngine;
using System.Collections;

public class Pirate : SummonsBase 
{
    private Transform[]     spwanPoint_array;
    private GameObject      prefab;
    private GameObject[]    _bullet;
    private int             array_count;
    private int             bullet_count;

    public override void Init()
    {
        base.Init();
        Get_Player.player_skills    = Player.PLAYER_SKILLS.PIRATE;
        hp_bar                      = gameObject.transform.FindChild("HP");
        life                        = hp_bar.GetComponent<SummonsLife>();
        bullet_count                = 0;
        Set_Init();
        

        anim.SetInteger("animation", 1);
        anim.Play("Base Layer.atk3");
    }
    private void Start()
    {
        anim.SetInteger("animation", 0);
        Invoke("Destroy", (status.removeTime + 1.0f));
        StartCoroutine("Bullet");
        //Invoke("Bullet_Destroy", 1.5f);
    }
    private void Update()
    {
        for (int i = 0; i < array_count; ++i)
        {
            if (_bullet[i] != null)
            {
                anim.SetInteger("animation", 0);
                _bullet[i].transform.Translate(spwanPoint_array[i].transform.forward * 2.0f * Time.deltaTime);
            }
        }
    }
    IEnumerator Bullet()
    {
        Bullet_Instance();
        yield return new WaitForSeconds(1.5f);
        Bullet_Destroy();
        StartCoroutine("Bullet");
    }
    private void Bullet_Destroy()
    {
        for (int i = 0; i < array_count; ++i)
        {
            Destroy(_bullet[i].gameObject, 0.1f);
        }
        //++bullet_count;
        //CancelInvoke("Bullet_Destroy");
    }
    protected void OnTriggerStay(Collider col)
    {
        base.OnTriggerStay(col);
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
            _bullet[i].transform.parent = this.gameObject.transform;
        }
    }
}
