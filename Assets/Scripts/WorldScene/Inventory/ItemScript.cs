using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour 
{
    public UISprite img;
    //private string m_strName;
    //private string m_spriteName;
    private Item_Info m_item;

	private void Start () 
    {
	
	}
	
	private void Update () 
    {
	
	}
    public void SetInfo(Item_Info _itemInfo)
    {
        m_item = _itemInfo;
        img.spriteName = m_item.NAME;
    }
    private void OnClick()
    {
        Debug.Log(m_item.NAME + "의 레벨은 " + m_item.LV + ", 공격력의 Max는 " + m_item.MAX + "입니다.");
    }
}
