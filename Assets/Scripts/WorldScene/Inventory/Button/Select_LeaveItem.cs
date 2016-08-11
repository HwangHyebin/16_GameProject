using UnityEngine;
using System.Collections;

public class Select_LeaveItem : MonoBehaviour 
{
    private Inventory       srt_inven;
    private Set_PlayerInfo  srt_player;
    private ItemDrag        srt_item;

    private void Start()
    {
        srt_inven   = GameObject.FindObjectOfType<Inventory>();
        srt_player  = GameObject.FindObjectOfType<Set_PlayerInfo>();
        srt_item    = GameObject.FindObjectOfType<ItemDrag>();
    }
    public void YES()
    {
        ClearOne(srt_inven.m_currentItem);
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
    public void NO()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
    private void ClearOne(ItemScript _itemScript)
    {
        srt_inven.effect.transform.parent = srt_inven.transform;
        srt_inven.effect.gameObject.SetActive(false);
        if(_itemScript.transform.parent.tag == "Weapon")
        {
            srt_player.Get_Player().Power = srt_item.power_start;
        }
        else if (_itemScript.transform.parent.tag == "Armor")
        {
            srt_player.Get_Player().Defence = srt_item.defence_start;
        }
        for (int i = 0; i < srt_inven.m_Items.Count; i++)
        {
            if (_itemScript == srt_inven.m_Items[i])
            {
                --srt_inven.totalCount;
                DestroyImmediate(srt_inven.m_Items[i].gameObject);
                srt_inven.m_Items.RemoveAt(i);
                break;
            }
        }
    }
}
