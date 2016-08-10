using UnityEngine;
using System.Collections;

public class StatusView : MonoBehaviour 
{
    public  UILabel         power;
    public  UILabel         defence;
    public  UILabel         hp;
    private Set_PlayerInfo  srt_gear;
	private void Start () 
    {
        srt_gear = GameObject.FindObjectOfType<Set_PlayerInfo>();
	}
	private void Update ()
    {
        power.text      = srt_gear.Get_Player().Power.ToString();
        defence.text    = srt_gear.Get_Player().Defence.ToString();
        hp.text         = srt_gear.Get_Player().HP.ToString();
	}
}
