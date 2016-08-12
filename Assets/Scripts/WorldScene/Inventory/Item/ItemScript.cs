using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour 
{
    //아이템 빛나는 효과 여기서 조절해주기.


    public  UISprite    img;
    public  UILabel     info_text;

    private Item_Info   m_item;
    private Inventory srt_inven;

    void Start()
    {
        srt_inven = GameObject.FindObjectOfType<Inventory>();
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
    private void OnClick()
    {
        info_text.text = m_item.INFO;
        srt_inven.SelectItem(this.gameObject.GetComponent<ItemScript>());
    }
}

