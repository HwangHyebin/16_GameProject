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
    private int startHP;
    private int currentHP;

    public int GetStartHP()
    {
        return startHP;
    }
    public int GetCurrentHP
    {
        set{currentHP = value;}
        get { return currentHP; }
    }
    private void Start()
    {
        srt_data = GameObject.FindObjectOfType<SetData>();
    }
    private void Update()
    {
        if (startTime == 0)
        {
            if (srt_data.player.HP > 0 )
            {
                startHP = srt_data.player.StartHP;
                currentHP = srt_data.player.HP;
                m_gold = srt_data.player.Gold;
                startTime = 1;
            }
        }
        if (inven.activeInHierarchy == true)
        {
            ShowInfo();
        }
    }
    private void ShowInfo()
    {
        power.text      = srt_data.player.Power.ToString();
        defence.text    = srt_data.player.Defence.ToString();
        hp.text         = srt_data.player.HP.ToString();
        gold.text       = m_gold.ToString();
    }
}
