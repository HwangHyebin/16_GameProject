using UnityEngine;
using System.Collections;

public class StatusView : MonoBehaviour 
{
    public UILabel power;
    public UILabel defence;
    public UILabel hp;
    private Set_PlayerInfo srt_player;
    private ItemUse srt_useButton;

    private int startTime = 0;

    private void Start()
    {
        srt_player = GameObject.FindObjectOfType<Set_PlayerInfo>();
        srt_useButton = GameObject.FindObjectOfType<ItemUse>();
    }
    private void Update()
    {
        if ( startTime == 0)
        {
            if (srt_player.Get_Player().HP != 0)
            {
                srt_useButton.start_hp = srt_player.Get_Player().HP;
                srt_useButton.current_hp = 60;//srt_player.Get_Player().HP;
                startTime = 1;
                ShowInfo();
                Debug.Log("B current = " + srt_useButton.current_hp);
                Debug.Log("B start = " + srt_useButton.start_hp);
            }
        }
        if (srt_useButton.start_hp != srt_useButton.current_hp )
        {
            ShowInfo();
        }  
    }
    private void ShowInfo()
    {
        power.text = srt_player.Get_Player().Power.ToString();
        defence.text = srt_player.Get_Player().Defence.ToString();
        hp.text = srt_useButton.current_hp.ToString();
    }
}
