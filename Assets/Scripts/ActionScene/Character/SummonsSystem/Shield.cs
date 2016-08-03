using UnityEngine;
using System.Collections;

public class Shield : SummonsBase 
{
    private Vector3     position;
    
    public override void Init()
    {
        base.Init();
        Get_Player.player_skills = Player.PLAYER_SKILLS.SHIELD;
    }
    private void Start()
    {
        Invoke("Sheild_Destroy", status.removeTime);
    }
    private void Update()
    {
        position = new Vector3( Get_Player.transform.position.x, 
                                Get_Player.transform.position.y, 
                                Get_Player.transform.position.z);
        this.transform.position = position;
    }
    private void Sheild_Destroy()
    {
        Get_Player.player_skills = Player.PLAYER_SKILLS.DONE;
        Destroy(this.gameObject, 1.0f);
    }
}
