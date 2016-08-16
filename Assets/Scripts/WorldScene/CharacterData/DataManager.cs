using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager
{
    public List<CharacterInformation> character_list = new List<CharacterInformation>();
    private static DataManager instance              = null;

    public static DataManager Instance
    {
        get
        {
            if(instance == null)
                instance = new DataManager();
            return instance;
        }
    }
    public CharacterInformation GetInfo(int _num)
    {
        return character_list[_num];
    }
}
//public class CharacterInformation
//{
//    private string  m_name;
//    private int     m_lv;
//    private int     m_hp;
//    private int     m_power;
//    private int     m_defense;
//    private float   m_removeTime;
//    private float   m_coolTime;

//    private int m_gold;

//    public string Name
//    {
//        set { m_name = value; }
//        get { return m_name; }
//    }
//    public int Level
//    {
//        set { m_lv = value; }
//        get { return m_lv; }
//    }
//    public int HP
//    {
//        set { m_hp = value; }
//        get { return m_hp; }
//    }
//    public int Power
//    {
//        set { m_power = value; }
//        get { return m_power; }
//    }
//    public int Defence
//    {
//        set { m_defense = value; }
//        get { return m_defense; }
//    }
//    public float RemoveTime
//    {
//        set { m_removeTime = value; }
//        get { return m_removeTime; }
//    }
//    public float CoolTime
//    {
//        set { m_coolTime = value; }
//        get { return m_coolTime; }
//    }
//    public int Gold
//    {
//        set { m_gold = value; }
//        get { return m_gold; }
//    }
//}
