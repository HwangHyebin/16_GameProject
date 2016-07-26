using UnityEngine;
using System.Collections;

public class Archer : SummonsBase
{
    private GameObject prefab;
    private Vector3 _forward;
    private Vector3 _right;
    private Vector3 vec;
    private GameObject _bullet;
    private Rigidbody my_body;

    public override void Init()
    {
        base.Init();
        Get_Player.player_skills = Player.PLAYER_SKILLS.ARCHER;
        my_body = GetComponent<Rigidbody>();
        prefab = Resources.Load("Prefabs/bullet") as GameObject;
        _forward = gameObject.transform.forward;
        _right = gameObject.transform.right;

        vec = new Vector3(_forward.x + _right.x, _forward.y + _right.y, _forward.z + _right.z).normalized;

        GameObject _bullet = Instantiate(prefab, gameObject.transform.position, Quaternion.identity) as GameObject;
    }
    private void Update()
    {
        Debug.Log(vec);
        my_body.AddForce(vec * Time.deltaTime * 100.0f);
        //_bullet.transform.position += vec * Time.deltaTime * 5.0f;
        //Get_Player.player_skills = Player.PLAYER_SKILLS.DONE;
    }
    public void Archer_Attacked(string _str)
    {
        Debug.Log("Archer / sender = " + _str);
        Debug.Log("Archer attacked!");
    }
}
