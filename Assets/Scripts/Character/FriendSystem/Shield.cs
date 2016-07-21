using UnityEngine;
using System.Collections;

public class Shield : SkillCharacterBase 
{
    private Vector3     position;
    private float       startTime;
    private float       nextTime;
    private float       delay;
    public override void Init()
    {
        base.Init();
        Get_Player.player_skills = Player.PLAYER_SKILLS.SHIELD;
    }
    private void Start()
    {
        startTime   = Time.time;
        delay       = 5.0f;
        nextTime    = startTime + delay;
    }
    private void Update()
    {
        position = new Vector3( Get_Player.transform.position.x, 
                                Get_Player.transform.position.y, 
                                Get_Player.transform.position.z);
        this.transform.position = position;

        if ( startTime != 0 && Time.time > nextTime )
        {
            Get_Player.player_skills = Player.PLAYER_SKILLS.DONE;
            Destroy(this.gameObject, 0.1f);
        }
    }
}
