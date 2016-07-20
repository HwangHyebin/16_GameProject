using UnityEngine;
using System.Collections;

public class CharacterFactory : MonoBehaviour 
{
    public  GameObject[]    prefabs;
    private Vector3         rand_pos;
    
    private void Start()
    {
    }
    public CharacterBase CreateCharacter(string _type, ref CharacterBase _base)
    {
        rand_pos = new Vector3(Random.Range(-12.0f, 12.0f), 0.0f, Random.Range(-12.0f, 12.0f));
        switch (_type)
        {
            case "Player" :
                GameObject player = Instantiate(prefabs[0], new Vector3(6.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
                _base = player.GetComponent<Player>();
                return _base;
            //player.AddComponent<Player>();
            case "Enemy" : //적군만 랜덤 생성 
                GameObject enemy = Instantiate(prefabs[1], rand_pos, Quaternion.identity) as GameObject;
                _base = enemy.GetComponentInChildren<Enemy>();
            //.GetComponent<Enemy>();
                return _base;
        }
        return null;
    }
}
