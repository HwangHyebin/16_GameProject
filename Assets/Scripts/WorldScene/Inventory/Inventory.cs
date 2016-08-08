using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
    public UIGrid               m_grid;                                     // 그리드를 reset position 하기위해 선언
    public UIGrid               m_grid2;
    public GameObject           m_itemObj;                                  // 이걸 이용해서 아이템 만들 예정.
           
    private List<string>        m_ItemNames     = new List<string>();       // 이름 저장
    private List<ItemScript> m_Items = new List<ItemScript>();    // 실질적인 아이템 저장
    //private List<GameObject>    m_slot          = new List<GameObject>();
    private static int          count           = 0;
    private int                 totalCount      = 0;                        // 아이템 총 합계
  
	private void Start () 
    {
        ItemsInit();
    }
	private void Update () 
    {
        // I 키를 누르면 아이템이 추가됩니다.
	    if(Input.GetKeyDown(KeyCode.I))
        {
            AddItem();
        }
	}
    private void ItemsInit()
    {
        //m_ItemNames.Add("asddas");
        //m_ItemNames.Add("controller");
        //m_ItemNames.Add("skill_icon_null");
        //m_ItemNames.Add("skill_icon_archer");
    }
    private void AddItem()
    {
        int nRandom = Random.Range(1, ItemManager.Instance.GetItemsCount() + 1 );

        if (totalCount == 12)
        {
            count = 0;
        }
        if (totalCount < 12)
        {
            SetItem(m_grid, nRandom);
        }
        else if (totalCount >= 12)
        {
            SetItem(m_grid2, nRandom);
        }
       
        ++totalCount;
        Debug.Log(totalCount);
    }

    // 이 게임 오브젝트가 파괴될 때 생성했던 아이템도 삭제해줍시다.
    // 메모리 정리라고 생각하세요.
    private void OnDestroy()
    {
        for (int nIndex = 0; nIndex < m_Items.Count; nIndex++)
        {
            // null이 아닐 때에만 삭제
            //if (m_Items[nIndex] != null && m_Items[nIndex].gameObject != null)
            //    Destroy(m_Items[nIndex].gameObject);
        }

        m_Items.Clear();
        m_Items = null;

        m_ItemNames.Clear();
        m_ItemNames = null;
    }
    private void SetItem(UIGrid _grid, int _num)
    {
        GameObject itemObj = NGUITools.AddChild(_grid.transform.GetChild(count).gameObject, m_itemObj);  //새로 만들어서 그리드의 자식으로 넣음
        itemObj.SetActive(true);                                                                         //sampleItem으로 만들어진 오브젝트인데 sampleItem가 꺼져있는걸로 셋팅 되어있음.
        ItemScript itemScript = m_itemObj.GetComponent<ItemScript>();
        itemScript.SetInfo(ItemManager.Instance.GetItem(_num));
        
        //Item_Info item = itemObj.GetComponent<Item_Info>();
        //item.Set_SpriteName(m_ItemNames[_num]);                                                          //이름 셋팅
        m_grid2.Reposition();                                                                            //그리드 재정렬
        //m_Items.Add(item);
        m_Items.Add(itemScript);
        ++count;
    }
}
