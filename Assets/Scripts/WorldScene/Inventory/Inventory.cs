using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
    public UIGrid           m_grid;                                 // 그리드를 reset position 하기위해 선언합니다.
    public UIGrid m_grid2;

    public GameObject       m_itemObj;                              // 이걸 이용해서 아이템 만들 예정.
    //public UIScrollView     m_scrollView;                           // 스크롤뷰를 reposition 하기위해 선언합니다.
                                     
    private List<string>    m_ItemNames     = new List<string>();   // 이름 저장
    private List<Item>      m_Items         = new List<Item>();     // 실질적인 아이템 저장
    private List<GameObject> m_slot = new List<GameObject>();
    private int count = 0;
    private int totalCount = 0;
    private int tern = 1;
    
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
        m_ItemNames.Add("asddas");
        m_ItemNames.Add("controller");
        m_ItemNames.Add("skill_icon_null");
        m_ItemNames.Add("skill_icon_archer");
        //m_ItemNames.Add("window");
    }
    private void AddItem()
    {
        int nRandom = Random.Range(0, m_ItemNames.Count);

        //if (totalCount % 4 == 0 && totalCount != 0)
        //{
            
        //    //tern = tern * 2;
        //    Debug.Log("4");

           

        //    if (totalCount == 13)
        //    {
        //        tern = 1;
        //    }
        //    else if (totalCount > 12)
        //    {
        //        count = (4 * tern) +1;
        //    }
        //    else
        //    {
        //        count = 8 * tern;
        //    }
        //    ++tern;
        //}
        //if (tern == 8)
        //{
        //    count = 4;
        //}
        if (totalCount < 12)
        {
            GameObject itemObj = NGUITools.AddChild(m_grid.transform.GetChild(count).gameObject, m_itemObj);  //새로 만들어서 그리드의 자식으로 넣음
            itemObj.SetActive(true);                                                //sampleItem으로 만들어진 오브젝트인데 sampleItem가 꺼져있는걸로 셋팅 되어있음.
            Item item = itemObj.GetComponent<Item>();
            item.Set_SpriteName(m_ItemNames[nRandom]);                //이름 셋팅
            m_grid.Reposition();
            m_Items.Add(item);

            //m_scrollView.ResetPosition();                                           //스크롤뷰, 그리드 재정렬    
            ++count;
        }
        
        if (totalCount == 12)
        {
            count = 0;
        }
        if (totalCount >= 12)
        {
            GameObject itemObj = NGUITools.AddChild(m_grid2.transform.GetChild(count).gameObject, m_itemObj);  //새로 만들어서 그리드의 자식으로 넣음
            itemObj.SetActive(true);                                                //sampleItem으로 만들어진 오브젝트인데 sampleItem가 꺼져있는걸로 셋팅 되어있음.
            Item item = itemObj.GetComponent<Item>();
            item.Set_SpriteName(m_ItemNames[nRandom]);                //이름 셋팅
            m_grid2.Reposition();
            m_Items.Add(item);

            //m_scrollView.ResetPosition();                                           //스크롤뷰, 그리드 재정렬    
            ++count;
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
