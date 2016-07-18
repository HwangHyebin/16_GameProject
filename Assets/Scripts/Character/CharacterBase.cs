using UnityEngine;
using System.Collections;

public class CharacterBase : MonoBehaviour 
{
    public  Animator    anim;
    public  Vector3     position;

    public struct STATUS
    {
        float attack;
        float shield;
        float hp;
        float attackSpeed;
    };
    private void Start()
    {
    }

    public virtual void init() 
    {
       
    }
    public virtual void update()
    {
        Debug.Log("Base");
    }
    public virtual void clean()
    { 
    }
}
