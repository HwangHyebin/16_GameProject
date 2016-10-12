﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Inventory : MonoBehaviour 
{
    public UIGrid               m_grid;                                     // 그리드를 reset position 하기위해 선언
    public UIGrid               m_grid2;
    public UISprite             effect;
    public UISprite             use_button;
    public GameObject           m_itemObj;                                  // 이걸 이용해서 아이템 만들 예정.
    [HideInInspector]
    public ItemScript           m_currentItem   = null;
    public int                  totalCount;                        // 아이템 총 합계
    public GameObject[]         slot_array1;
    public GameObject[]         slot_array2;
    [HideInInspector]
    public int                  page1_total;
    [HideInInspector]
    public int                  page2_total;
    private StatusView          srt_status;
    private TouchManager        srt_touchManager;
    private CameraControl       srt_camera;

    private void Start()
    {
        effect.gameObject.SetActive(false);
        use_button.gameObject.SetActive(false);
        srt_status = GameObject.FindObjectOfType<StatusView>();
        srt_touchManager = GameObject.FindObjectOfType<TouchManager>();
        srt_camera = GameObject.FindObjectOfType<CameraControl>();
        //effect = GameObject.Find("effect").GetComponent<UISprite>();
    }
	private void Update () 
    {
        //후에 스테이지가끝나면 아이템이 추가되게 변경.
	    if(Input.GetKeyDown(KeyCode.I))
        {
            AddItem();
        }
	}
    private void AddItem()
    {
        int nRandom = Random.Range(1, ItemManager.Instance.GetItemsCount() + 1 ); //랜덤으로 아이템 생성되게 함

        for (int i = 0; i < 12; ++i)
        {
            if (slot_array1[i].transform.childCount == 0 && page1_total < 12)
            {
                ++page1_total;
                SetItem(m_grid, nRandom, i);
                break;
            }
            else if (slot_array2[i].transform.childCount == 0 && page1_total >= 12)
            {
                ++page2_total;
                SetItem(m_grid2, nRandom, i);
                break;
            }
        }
        totalCount = page1_total + page2_total;
        Debug.Log(totalCount);
    }
    private void SetItem(UIGrid _grid, int _num, int slot_number) //리스트의 랜덤번째 있는걸 그리드에 생성하고 있음.
    {
        GameObject itemObj = NGUITools.AddChild(_grid.transform.GetChild(slot_number).gameObject, m_itemObj);  //새로 만들어서 그리드의 자식으로 넣음
        itemObj.SetActive(true);                                                                         //sampleItem으로 만들어진 오브젝트인데 sampleItem가 꺼져있는걸로 셋팅 되어있음.
        
        ItemScript itemScript = itemObj.GetComponent<ItemScript>();

        itemScript.SetInfo(ItemManager.Instance.GetItem(_num));
       
        float rand = UnityEngine.Random.Range(itemScript.GetInfo().MIN, itemScript.GetInfo().MAX);
        itemScript.GetInfo().STATUS_RAND = rand;
        itemScript.tag = itemScript.GetInfo().TAG;
        
        _grid.Reposition();          //그리드 재정렬
        Data.m_Items.Add(itemScript);   
    }
    public void SelectItem(ItemScript itemScript)
    {
        m_currentItem = itemScript;
        Debug.Log(m_currentItem.gameObject.transform.parent.name);
        Debug.Log("tag = " + m_currentItem.tag);

        //Vector2 pos = srt_touchManager.CurrentTouch.position;
        //Vector3 touchPos = new Vector3(pos.x, pos.y, 0.0f);
        //Ray ray = srt_camera.CurrentCamera.ScreenPointToRay(touchPos);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //{
        effect.gameObject.transform.parent = m_currentItem.gameObject.transform; //hit.collider.gameObject.transform;//
        //}
        
        effect.depth = itemScript.gameObject.GetComponent<UIPanel>().depth - 1;
        effect.transform.position = new Vector3(effect.transform.parent.position.x, effect.transform.parent.position.y, effect.transform.parent.position.z);
        effect.gameObject.SetActive(true);
        if (m_currentItem.tag == "Food")
        {
            use_button.gameObject.SetActive(true);
            ItemUse srt_itemUse = GameObject.FindObjectOfType<ItemUse>();
            if (srt_status.GetCurrentHP < srt_status.GetStartHP)
            {
                use_button.spriteName = "button_use";
            }
            else
            {
                use_button.spriteName = "button_unuse";
            }
        }
    }
}