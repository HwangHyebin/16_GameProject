using UnityEngine;
using System.Collections;

public class CharacterInformation
{
    private int     m_lv;
    private float   m_hp;
    private float   m_power;
    private float   m_defense;
    private float   m_removeTime;
    private float   m_coolTime;

    public int Level
    {
        set { m_lv = value; }
        get { return m_lv; }
    }
    public float HP
    {
        set { m_hp = value; }
        get { return m_hp; }
    }
    public float Power
    {
        set { m_power = value; }
        get { return m_power; }
    }
    public float Defence
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
}
