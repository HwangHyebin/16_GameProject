using UnityEngine;
using System.Collections;

public class Archer : SkillCharacterBase
{
    private SkillManager srt_skillManager;
    //public GameObject bullet;

    public sealed override void init()
    {
        srt_skillManager = GameObject.FindObjectOfType<SkillManager>() as SkillManager;
        Debug.Log("archer");
    }
    public sealed override void update()
    {
       
    }
    public sealed override void clean()
    {
    }
}
