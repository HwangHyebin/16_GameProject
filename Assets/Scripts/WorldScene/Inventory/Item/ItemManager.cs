using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
  //파싱 정보 저장
    //private static object       m_pLock     = new object();
    private static ItemManager instance;

    public static ItemManager Instance
    {
        get
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
            return instance;
        }
    }

    public Item_Info GetItem(int _nID) // 하나의 아이템 얻기
    {
        if (Data.m_dicData.ContainsKey(_nID))
            return Data.m_dicData[_nID];

        return null;
    }
    public Dictionary<int, Item_Info> GetAllItems()
    {
        return Data.m_dicData;
    }
    public int GetItemsCount()
    {
        return Data.m_dicData.Count;
    }
}

