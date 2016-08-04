using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
    public UIGrid           m_grid;                                 // 그리드를 reset position 하기위해 선언합니다.
    public GameObject       m_itemObj;                              // 이걸 이용해서 아이템 만들 예정.
    public UIScrollView     m_scrollView;                           // 스크롤뷰를 reposition 하기위해 선언합니다.
                                     
    private List<string>    m_ItemNames     = new List<string>();   // 이름 저장
    private List<Item>      m_Items         = new List<Item>();     // 실질적인 아이템 저장
    
	private void Start () 
    {
        ItemsInit();
    }
	private void Update () 
    {
        // I 키를 누르면 아이템이 추가됩니다.
	    if(Input.GetKeyDown(KeyCode.I))
        {
            //AddItem();
        }
	}
    private void ItemsInit()
    {
        m_ItemNames.Add("test_dummy");
        //m_ItemNames.Add("window");
    }
    private void AddItem()
    {        
        GameObject itemObj = NGUITools.AddChild(m_grid.gameObject, m_itemObj);  //새로 만들어서 그리드의 자식으로 넣음
        itemObj.SetActive(true);                                                //sampleItem으로 만들어진 오브젝트인데 sampleItem가 꺼져있는걸로 셋팅 되어있음.
        Item item = itemObj.GetComponent<Item>();
        item.Set_SpriteName(m_ItemNames[m_ItemNames.Count - 1]);                //이름 셋팅
 
        //m_grid.Reposition(); 
        //m_scrollView.ResetPosition();                                           //스크롤뷰, 그리드 재정렬
        m_Items.Add(item);
    }

    // 이 게임 오브젝트가 파괴될 때 생성했던 아이템도 삭제해줍시다.
    // 메모리 정리라고 생각하세요.
    private void OnDestroy()
    {
        for (int nIndex = 0; nIndex < m_Items.Count; nIndex++)
        {
            // 혹시 모르니까 null이 아닐 때에만 삭제하도록 해요.
            if (m_Items[nIndex] != null && m_Items[nIndex].gameObject != null)
                Destroy(m_Items[nIndex].gameObject);
        }

        m_Items.Clear();
        m_Items = null;

        m_ItemNames.Clear();
        m_ItemNames = null;
    }
}
