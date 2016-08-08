using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    // ItemManager는 Singleton으로 만들어 어디에서든 접근 가능하게!
    private static ItemManager instance;

    private static object m_pLock = new object();

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

    // 파싱한 정보를 다 저장할꺼에요.
    Dictionary<int, Item_Info> m_dicData = new Dictionary<int, Item_Info>();
    // 아이템 추가.
    public void AddItem(Item_Info _cInfo)
    {
        // 아이템은 고유해야 되니까, 먼저 체크!
        if (m_dicData.ContainsKey(_cInfo.ID)) return;

        // 이제 아이템을 추가.
        m_dicData.Add(_cInfo.ID, _cInfo);
    }
    // 하나의 아이템 얻기
    public Item_Info GetItem(int _nID)
    {
        // 있는지 체크 해야겠죠?
        if (m_dicData.ContainsKey(_nID))
            return m_dicData[_nID];

        // 없으면 null 리턴!
        return null;
    }
    // 전체 리스트 얻기
    public Dictionary<int, Item_Info> GetAllItems()
    {
        return m_dicData;
    }
    // 전체 갯수 얻기
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
    private float m_min;
    private float m_max;
    private string m_info;
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
}
