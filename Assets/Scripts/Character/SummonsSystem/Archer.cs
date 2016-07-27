using UnityEngine;
using System.Collections;

public class Archer : SummonsBase
{
    private GameObject  prefab;
    private Vector3     _forward;
    private Vector3     _right;
    private Vector3     vec;
    private GameObject  _bullet;

    public override void Init()
    {
        base.Init();
        Get_Player.player_skills    = Player.PLAYER_SKILLS.ARCHER;
        my_body                     = GetComponent<Rigidbody>();
        prefab                      = Resources.Load("Prefabs/bullet") as GameObject;
        _forward                    = gameObject.transform.forward;
        _right                      = gameObject.transform.right;
        vec                         = new Vector3(_forward.x + _right.x, _forward.y + _right.y, _forward.z + _right.z).normalized;
        GameObject _bullet          = Instantiate(prefab, gameObject.transform.position, Quaternion.identity) as GameObject;
    }
    private void Update()
    {
        //Debug.Log(vec);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log("archer 적군와 충돌!");
            if (col.GetComponent<Enemy>().attack_check == true ||
                col.GetComponent<Enemy>().enemy_anim == Enemy.ENEMY_ANIMATOR.ATTACK)
            {
                Debug.Log("archer hp감소!");
                //life.m_HP -= (col.GetComponent<Enemy>().status.power - this.status.defense);
            }
        }
    }
}
