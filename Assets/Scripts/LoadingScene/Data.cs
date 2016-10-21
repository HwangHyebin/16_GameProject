using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Data 
{
    public static List<CharacterInformation> characters = new List<CharacterInformation>();
    public static Dictionary<int, Item_Info> m_dicData = new Dictionary<int, Item_Info>();
    public static List<ItemScript> m_Items = new List<ItemScript>();   // 실질적인 아이템 저장
    public static List<GameObject> m_ItemsObj = new List<GameObject>();
    //public static GameObject[] slot_array1 = new GameObject[12];
    //public static GameObject[] slot_array2 = new GameObject[12];
    public static int parseCount;
}
public class CharacterInformation
{
    private string  m_name;
    private int     m_lv;
    private int     m_hp;
    private int     m_power;
    private int     m_defense;
    private float   m_removeTime;
    private float   m_coolTime;
    private string  m_info;

    private int     m_gold;
    private int     m_startHP;
    private string  m_tag;

    public string Name
    {
        set { m_name = value; }
        get { return m_name; }
    }
    public int Level
    {
        set { m_lv = value; }
        get { return m_lv; }
    }
    public int HP
    {
        set { m_hp = value; }
        get { return m_hp; }
    }
    public int StartHP
    {
        set { m_startHP = value; }
        get { return m_startHP;  }
    }
    public int Power
    {
        set { m_power = value; }
        get { return m_power; }
    }
    public int Defence
    {
        set { m_defense = value; }
        get { return m_defense; }
    }
    public float RemoveTime
    {
        set { m_removeTime = value; }
        get { return m_removeTime; }
    }
    public float CoolTime
    {
        set { m_coolTime = value; }
        get { return m_coolTime; }
    }
    public int Gold
    {
        set { m_gold = value; }
        get { return m_gold; }
    }
    public string TAG
    {
        set { m_tag = value; }
        get { return m_tag;  }
    }
    public string Info
    {
        set { m_info = value; }
        get { return m_info;  }
    }
}
public class Item_Info
{
    private int         m_id;
    private string      m_name;
    private int         m_lv;
    private float       m_status;
    private float       m_min;
    private float       m_max;
    private string      m_info;
    private string      m_tag;
    private string      m_itemName;
    public int ID
    {
        set { m_id = value; }
        get { return m_id; }
    }
    public string NAME
    {
        set { m_name = value; }
        get { return m_name; }
    }
    public int LV
    {
        set { m_lv = value; }
        get { return m_lv; }
    }
    public float MIN
    {
        set { m_min = value; }
        get { return m_min; }
    }
    public float MAX
    {
        set { m_max = value; }
        get { return m_max; }
    }
    public string INFO
    {
        set { m_info = value; }
        get { return m_info; }
    }
    public float STATUS_RAND
    {
        set { m_status = value; }
        get { return m_status; }
    }
    public string TAG
    {
        set { m_tag = value; }
        get { return m_tag; }
    }
    public string ITEMNAME
    {
        set { m_itemName = value; }
        get { return m_itemName;  }
    }
}

