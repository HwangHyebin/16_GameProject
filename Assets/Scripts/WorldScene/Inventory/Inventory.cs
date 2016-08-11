using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
    public UIGrid               m_grid;                                     // 그리드를 reset position 하기위해 선언
    public UIGrid               m_grid2;
    public GameObject           m_itemObj;                                  // 이걸 이용해서 아이템 만들 예정.

   
    private List<string>        m_ItemNames     = new List<string>();       // 이름 저장
    [HideInInspector]
    public List<ItemScript>     m_Items         = new List<ItemScript>();   // 실질적인 아이템 저장
    private static int          count           = 0;
    public int                 totalCount      = 0;                        // 아이템 총 합계
    [HideInInspector]
    public ItemScript m_currentItem = null;

    public UISprite effect;
    public GameObject button;
    private void Start()
    {
        effect.gameObject.SetActive(false);
        button.SetActive(false);
    }
    

	private void Update () 
    {
        // I 키를 누르면 아이템이 추가됩니다.
	    if(Input.GetKeyDown(KeyCode.I))
        {
            AddItem();
        }
	}
    private void AddItem()
    {
        int nRandom = Random.Range(1, ItemManager.Instance.GetItemsCount() + 1 );
        //만약 리스트가 중간에 비게 된다면, 그 리스트 번호를 저장해서 
        // 새로만들때 그곳으로 저장할수 있게 해야함.
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
    }
    private void SetItem(UIGrid _grid, int _num)
    {
        GameObject itemObj = NGUITools.AddChild(_grid.transform.GetChild(count).gameObject, m_itemObj);  //새로 만들어서 그리드의 자식으로 넣음
        itemObj.SetActive(true);                                                                         //sampleItem으로 만들어진 오브젝트인데 sampleItem가 꺼져있는걸로 셋팅 되어있음.
        
        ItemScript itemScript = itemObj.GetComponent<ItemScript>();
        
        itemScript.SetInfo(ItemManager.Instance.GetItem(14));
        float rand = UnityEngine.Random.Range(itemScript.GetInfo().MIN, itemScript.GetInfo().MAX);
        itemScript.GetInfo().STATUS_RAND = rand;
        itemScript.gameObject.tag = itemScript.GetInfo().TAG;
        
        _grid.Reposition();                                                                             //그리드 재정렬                                                         
        m_Items.Add(itemScript);
       
        ++count;
    }
    public void SelectItem(ItemScript itemScript)
    {
        m_currentItem = itemScript;
        effect.gameObject.transform.parent = itemScript.gameObject.transform;
        effect.depth = itemScript.gameObject.GetComponent<UIPanel>().depth - 1;
        effect.transform.position = new Vector3(effect.transform.parent.position.x, effect.transform.parent.position.y, effect.transform.parent.position.z);
        effect.gameObject.SetActive(true);
        Debug.Log(m_currentItem.GetInfo().INFO);
        if (m_currentItem.tag == "Food")
        {
            button.SetActive(true);
        }
    }

    // 판매하는 함수 입니다.
    // 판매 누르면 해당 아이템이 삭제되는것 까지만? 할께요.
    //public void Sell()
    //{
    //    // 현재 선택된 데이터가 없으면 안되겠죠?
    //    if (m_cCurScript == null) return;
    //    // 판매를 누르면 판매한 금액을 합산할께요.
    //    m_nMoney += m_cCurScript.m_Item.SELL_COST;
    //    // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)
    //    ClearOne(m_cCurScript);
    //    // 그리고 현재 선택된 아이템 정보를 초기화 합니다.
    //    m_cCurScript = null;
    //    // 버튼도 숨기고 정보 레이블도 초기화합니다.
    //    m_lblInfo.text = string.Empty;
    //    m_gObjSellButton.SetActive(false);
    //    // 다시 정렬을 해줍시다.
    //    m_grid.Reposition();
    //    m_scrollView.ResetPosition();
    //    // 확인 위해 로그찍어보아요
    //    Debug.Log("현재 금액 : " + m_nMoney.ToString());
    //}
}
