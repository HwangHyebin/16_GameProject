using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour
{
    private Vector3         startPosition;
    private Transform       startParent;
    private Transform       currentParent;
    private Set_PlayerInfo  srt_gear;

    private int             power_start;
    private int             defence_start;
    private int             plus_value;
    private int             result_value;
    
    private void Start()
    {
        srt_gear        = GameObject.FindObjectOfType<Set_PlayerInfo>();
        power_start     = (int)srt_gear.player.Power;
        defence_start   = (int)srt_gear.player.Defence;
    }
    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began )
            {
                startParent = transform.parent;
            }
            else if (touch.phase == TouchPhase.Ended )
            {
                if (transform.parent.childCount == 2)
                {
                    transform.parent = startParent;
                }
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
                currentParent = transform.parent;
                if (startParent != currentParent)
                {
                    Set_Weapon(currentParent);
                }
            }
        }
    }
    //public CharacterInformation Get_Player()
    //{
    //    foreach (CharacterInformation node in DataManager.Instance.character_list)
    //    {
    //        if (node.Name == "Player")
    //        {
    //            srt_gear.player = node;
    //        }
    //    }
    //    return srt_gear.player;
    //}
    public void Set_Weapon(Transform _obj)
    {
        ItemScript child    = this.gameObject.GetComponent<ItemScript>();
        plus_value          = (int)child.GetInfo().STATUS_RAND;
        //Get_Player();

        if (_obj.name == "gear1")
        {
            result_value                = power_start + plus_value;
            srt_gear.player.Power       = result_value;

            if (startParent.name == "gear2")
                srt_gear.player.Defence = defence_start; 
        }
        else if (_obj.name == "gear2")
        {
            result_value                = defence_start + plus_value;
            srt_gear.player.Defence     = result_value;

            if (startParent.name == "gear1")
                srt_gear.player.Power   = power_start;
        }
        else if (_obj.tag == "slot")
        {
            if (startParent.name == "gear1")
                srt_gear.player.Power   = power_start;

            else if (startParent.name == "gear2")
                srt_gear.player.Defence = defence_start;
        }
    }
}
