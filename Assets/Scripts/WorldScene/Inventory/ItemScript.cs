using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour 
{
    public  UISprite    img;
    public  UILabel     info_text;
    private Item_Info   m_item;

    void Start()
    {
    }
    public void SetInfo(Item_Info _itemInfo)
    {
        m_item = _itemInfo;
        img.spriteName = m_item.NAME;
        info_text.text = m_item.INFO;

    }
    public Item_Info GetInfo()
    {
        return m_item;
    }
    private void OnClick()
    {
        Debug.Log(m_item.INFO);
    }
}

