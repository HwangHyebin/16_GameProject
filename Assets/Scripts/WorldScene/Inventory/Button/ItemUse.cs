using UnityEngine;
using System.Collections;

public class ItemUse : MonoBehaviour 
{
    //[HideInInspector]
    //public  int             start_hp;
    //[HideInInspector]
    //public  int             current_hp;

    //private StatusView srt_status;
    //private Set_PlayerInfo  srt_player;
    private StatusView      srt_stateView;
    private Inventory srt_inven;
    
    //public bool[] destroy_check;

    private void Start()
    {
  
        srt_stateView = GameObject.FindObjectOfType<StatusView>();
        srt_inven = GameObject.FindObjectOfType<Inventory>();
        //srt_player  = GameObject.FindObjectOfType<Set_PlayerInfo>();
        
        //destroy_check = new bool[12];
    }
    public void Use()
    {
        int result = 0;
        int max = srt_stateView.GetCurrentHP + (int)srt_inven.m_currentItem.GetInfo().STATUS_RAND;
        if (srt_stateView.GetCurrentHP < srt_stateView.GetStartHP()) // 사용
        {
            result = max;
            if (result > srt_stateView.GetStartHP())
            {
                result = srt_stateView.GetStartHP();
            }
            srt_stateView.GetCurrentHP = result;
            ClearOne(srt_inven.m_currentItem);
        }
        else
        {
            Debug.Log("max = " + srt_stateView.GetCurrentHP + "를 초과해서 사용할수 없습니다.");
        }
    }
    private void ClearOne(ItemScript _itemScript)
    {
        srt_inven.effect.transform.parent = srt_inven.transform;
        srt_inven.effect.gameObject.SetActive(false);
        srt_inven.use_button.gameObject.SetActive(false);
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
