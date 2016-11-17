using UnityEngine;
using System.Collections;

public class Archer : SummonsBase
{
    public GameObject effect_prefab;
    private GameObject      prefab;
    private GameObject[]    _bullet;
    private GameObject[] effect_arr;
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
        StartCoroutine("Arrow");
    }
    protected void OnTriggerStay(Collider col)
    {
        base.OnTriggerStay(col);
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
        effect_arr      = new GameObject[_bulletCount];

        for (int i = 0; i < _bulletCount; ++i)
        {
            _bullet[i] = Instantiate(prefab, spwanPoint.position, Quaternion.identity) as GameObject;
            _bullet[i].tag = "Archer";
        }
    }
    IEnumerator Arrow()
    {
        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < _bulletCount; ++i)
        {
            if (_bullet[i] != null)
            {
                Vector3 right_vec = new Vector3((transform.forward.x + transform.right.x), (transform.forward.y + transform.right.y), (transform.forward.z + transform.right.z)).normalized;
                Vector3 left_vec = new Vector3((transform.forward.x + (transform.right.x * -1.0f)), (transform.forward.y + (transform.right.y * -1.0f)), (transform.forward.z + (transform.right.z * -1.0f))).normalized;

                _bullet[0].transform.Translate(transform.forward * 2.0f * Time.deltaTime);
                _bullet[1].transform.Translate(right_vec * 2.0f * Time.deltaTime);
                _bullet[2].transform.Translate(left_vec * 2.0f * Time.deltaTime);

                effect_arr[i] = Instantiate(effect_prefab, _bullet[i].transform.position, Quaternion.identity) as GameObject;
            }
        }
        StartCoroutine("Delete");
    }
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2.0f);
        for (int i =0; i < _bullet.Length; ++i)
        {
            Destroy(_bullet[i], 0.1f);
            Destroy(effect_arr[i], 0.1f);
        }
    }
}
