using UnityEngine;
using System.Collections;

public class Set_Gear : MonoBehaviour 
{
    public  UILabel                 text;
    private CharacterInformation    player;
    public  UILabel status;

    //status 라벨은 계속 플레이어의 정보를 체크.
	private void Start () 
    {
        player = DataManager.Instance.character_list[3];
	}
	private void Update () 
    {
        //mvc 패턴 활용하면 좋을듯?
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Ended)
            {
                if (this.gameObject.transform.childCount > 0) //자식이 생긴다면
                {
                     ItemScript child = gameObject.transform.GetChild(0).GetComponent<ItemScript>();
                    //함수로 묶기
                    if (this.gameObject.name == "gear1")
                    {
                        player.Power += child.GetInfo().POWER;
                    }
                    else if (this.gameObject.name == "gear2")
                    {
                        player.Defence += child.GetInfo().POWER;
                    }
                    //플레이어 정보와 장비 정보 계산해서 더해주기
                   
                    Debug.Log(player.Power);
                    Debug.Log("min = " + child.GetInfo().MIN);
                }
                else if (this.gameObject.transform.childCount <= 0)
                {
                    ItemScript child = gameObject.transform.GetChild(0).GetComponent<ItemScript>();
                    if (this.gameObject.name == "gear1")
                    {
                        player.Power -= child.GetInfo().POWER;
                    }
                    else if (this.gameObject.name == "gear2")
                    {
                        player.Defence -= child.GetInfo().POWER;
                    }
                }
            }
        }
	}
}
