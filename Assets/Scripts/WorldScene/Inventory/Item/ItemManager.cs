using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    Dictionary<int, Item_Info>  m_dicData   = new Dictionary<int, Item_Info>(); //파싱 정보 저장
    private static object       m_pLock     = new object();
    private static ItemManager instance;

    public static ItemManager Instance
    {
        get
        {
            lock (m_pLock)
            {
                if (instance == null)
                {
                    instance = (ItemManager)FindObjectOfType(typeof(ItemManager));

                    if (FindObjectsOfType(typeof(ItemManager)).Length > 1)
                    {
                        return instance;
                    }

                    if (instance == null)
                    {
                        GameObject singleton = new GameObject();
                        instance = singleton.AddComponent<ItemManager>();
                        singleton.name = typeof(ItemManager).ToString();

                        DontDestroyOnLoad(singleton);
                    }
                }
            }

            return instance;
        }
    }


    public void AddItem(Item_Info _cInfo) //아이템 추가
    {
        if (m_dicData.ContainsKey(_cInfo.ID)) 
            return;
        
        m_dicData.Add(_cInfo.ID, _cInfo);
    }
    public Item_Info GetItem(int _nID) // 하나의 아이템 얻기
    {
        if (m_dicData.ContainsKey(_nID))
            return m_dicData[_nID];
        
        return null;
    }
    public Dictionary<int, Item_Info> GetAllItems()
    {
        return m_dicData;
    }
    public int GetItemsCount()
    {
        return m_dicData.Count;
    }
}
public class Item_Info
{
    private int m_id;
    private string m_name;
    private int m_lv;
    private float m_status;
    private float m_min;
    private float m_max;
    private string m_info;
    private string m_tag;
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
        get { return m_tag;  }
    }
}
