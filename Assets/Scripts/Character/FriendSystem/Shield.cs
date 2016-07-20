using UnityEngine;
using System.Collections;

public class Shield : SkillCharacterBase 
{
    private Vector3     position;
    public override void Init()
    {
        base.Init();
        
        //Debug.Log("shield init");
    }
    private void Update()
    {
        //Debug.Log("shield update");
        position = new Vector3( Get_Player.transform.position.x, 
                                Get_Player.transform.position.y, 
                                Get_Player.transform.position.z);
        this.transform.position = position;
    }
}
