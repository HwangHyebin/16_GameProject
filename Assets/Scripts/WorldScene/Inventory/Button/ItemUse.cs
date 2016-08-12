using UnityEngine;
using System.Collections;

public class ItemUse : MonoBehaviour 
{
    [HideInInspector]
    public  int             start_hp;
    [HideInInspector]
    public  int             current_hp;

    private Inventory       srt_inven;
    private Set_PlayerInfo  srt_player;
    private StatusView      srt_stateView;
    
    //public bool[] destroy_check;

    private void Start()
    {
        srt_inven   = GameObject.FindObjectOfType<Inventory>();
        srt_player  = GameObject.FindObjectOfType<Set_PlayerInfo>();
        //destroy_check = new bool[12];
    }
    public void Use()
    {
        int result = 0;
        int max = current_hp + (int)srt_inven.m_currentItem.GetInfo().STATUS_RAND;
        if (current_hp < start_hp) // 사용
        {
            result = max;
            if (result > start_hp)
            {
                result = start_hp;
            }
            current_hp = result;
            ClearOne(srt_inven.m_currentItem);
        }
        else
        {
            Debug.Log("max = " + current_hp +"를 초과해서 사용할수 없습니다.");
        }
    }
    private void ClearOne(ItemScript _itemScript)
    {
        srt_inven.effect.transform.parent = srt_inven.transform;
        srt_inven.effect.gameObject.SetActive(false);
        srt_inven.use_button.gameObject.SetActive(false);
        for (int i = 0; i < srt_inven.m_Items.Count; i++)
        {
            if (_itemScript == srt_inven.m_Items[i])
            {
                --srt_inven.totalCount;
                DestroyImmediate(srt_inven.m_Items[i].gameObject);
                srt_inven.m_Items.RemoveAt(i);
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
