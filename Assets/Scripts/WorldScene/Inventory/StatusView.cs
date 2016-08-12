using UnityEngine;
using System.Collections;

public class StatusView : MonoBehaviour 
{
    public  UILabel         power;
    public  UILabel         defence;
    public  UILabel         hp;
    public  UILabel         gold;
    private Set_PlayerInfo  srt_player;
    private ItemUse         srt_useButton;
    private int             startTime = 0;

    private int m_gold;

    private void Start()
    {
        srt_player      = GameObject.FindObjectOfType<Set_PlayerInfo>();
        srt_useButton   = GameObject.FindObjectOfType<ItemUse>();
    }
    private void Update()
    {
        if ( startTime == 0)
        {
            if (srt_player.Get_Player().HP != 0)
            {
                srt_useButton.start_hp = srt_player.Get_PlayerStartHP();
                srt_useButton.current_hp = 60;//srt_player.GeT_PlayerCurrentHP().HP;
                m_gold = srt_player.Get_Player().Gold;
                startTime = 1;
            }
        }
        ShowInfo();
    }
    private void ShowInfo()
    {
        power.text      = srt_player.Get_Player().Power.ToString();
        defence.text    = srt_player.Get_Player().Defence.ToString();
        hp.text         = srt_useButton.current_hp.ToString();
        gold.text       = m_gold.ToString();
    }
}
