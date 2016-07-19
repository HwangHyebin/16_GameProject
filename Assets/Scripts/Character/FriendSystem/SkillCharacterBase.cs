using UnityEngine;
using System.Collections;

public class SkillCharacterBase : MonoBehaviour 
{
    public struct STATUS
    {
        float attack;
        float shield;
        float hp;
        float attackSpeed;
    };
    public virtual void init()
    {
    }
    public virtual void update()
    {
    }
    public virtual void clean()
    {
    }

}
