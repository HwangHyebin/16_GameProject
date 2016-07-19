using UnityEngine;
using System.Collections;

public class CharacterBase : MonoBehaviour 
{
    public  Animator    anim;
    public  Vector3     position;

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
