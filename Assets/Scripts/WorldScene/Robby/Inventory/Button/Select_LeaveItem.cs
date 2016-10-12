using UnityEngine;
using System.Collections;

public class Select_LeaveItem : MonoBehaviour 
{

    private Set_PlayerInfo  srt_player;
    private ItemDrag        srt_item;
    private Inventory srt_inven;

    private void Start()
    {
        srt_inven = GameObject.FindObjectOfType<Inventory>();
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
        //if(_itemScript.transform.parent.tag == "Weapon")
        //{
        //    srt_player.Get_Player().Power = srt_item.power_start;
        //}
        //else if (_itemScript.transform.parent.tag == "Armor")
        //{
        //    srt_player.Get_Player().Defence = srt_item.defence_start;
        //}
        for (int i = 0; i < Data.m_Items.Count; i++)
        {
            if (_itemScript == Data.m_Items[i])
            {
                DestroyImmediate(Data.m_Items[i].gameObject);
                Data.m_Items.RemoveAt(i);
                if (i < 12)
                {
                    --srt_inven.page1_total;
                }
                else if (i >= 12)
                {
                    --srt_inven.page2_total;
                }
                break;
            }
        }
    }
}
