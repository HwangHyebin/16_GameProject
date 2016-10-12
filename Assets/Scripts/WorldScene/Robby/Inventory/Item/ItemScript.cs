using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour 
{
    public  UISprite    img;
    public  UILabel     info_text;

    private Item_Info   m_item;
    private Inventory   srt_inven;
    private TouchManager srt_touchManager;

    private void Start()
    {
        srt_inven = GameObject.FindObjectOfType<Inventory>();
        srt_touchManager = GameObject.FindObjectOfType<TouchManager>();
    }
    private void OnClick()
    {
        info_text.text = m_item.INFO;
        srt_inven.SelectItem(this.gameObject.GetComponent<ItemScript>());
    }
    public void SetInfo(Item_Info _itemInfo)
    {
        m_item = _itemInfo;
        img.spriteName = m_item.NAME;
    }
    public Item_Info GetInfo()
    {
        return m_item;
    }
}

