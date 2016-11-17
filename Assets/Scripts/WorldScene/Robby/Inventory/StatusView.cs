using UnityEngine;
using System.Collections;

public class StatusView : MonoBehaviour 
{
    public  UILabel         power;
    public  UILabel         defence;
    public  UILabel         hp;
    public  UILabel         gold;
    public  GameObject inven;

    private Set_PlayerInfo  srt_player;
    private ItemUse         srt_useButton;
    private SetData         srt_data;
    private int             startTime = 0;

    private int m_gold;

    public int GetStartHP
    {
        get { return srt_data.player.StartHP; }
    }
    public int GetCurrentHP
    {
        set { srt_data.player.HP = value; }
        get { return srt_data.player.HP; }
    }
    private void Start()
    {
       srt_data = GameObject.FindObjectOfType<SetData>();
        if (startTime == 0)
        {
            if (srt_data.player.HP > 0)
            {
                m_gold = srt_data.player.Gold;
                startTime = 1;
            }
        }
    }
    private void Update()
    {
        if (inven.activeInHierarchy == true)
        {
            ShowInfo();
        }
    }
    public void ShowInfo()
    {
        power.text      = srt_data.player.Power.ToString();
        defence.text    = srt_data.player.Defence.ToString();
        hp.text         = srt_data.player.HP.ToString();
        gold.text       = srt_data.player.Gold.ToString();
    }
}
