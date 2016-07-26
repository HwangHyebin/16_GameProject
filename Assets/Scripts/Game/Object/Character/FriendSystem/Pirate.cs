using UnityEngine;
using System.Collections;

public class Pirate : SummonsBase 
{
    //public Animator anim;
    public override void Init()
    {
        base.Init();
        Get_Player.player_skills = Player.PLAYER_SKILLS.PIRATE;
        //anim.speed = 1.2f;
    }
    private void Update()
    {
    }
    public void Pirate_Attacked(string _str)
    {
        Debug.Log("Pirate / sender = " + _str);
        Debug.Log("Pirate attacked!");
    }
}
