using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour
{
    private Transform       startParent;
    private Transform       currentParent;
    private Set_PlayerInfo  srt_gear;
    private SetData srt_data;

    [HideInInspector]
    public int              power_start;
    [HideInInspector]
    public int              defence_start;
    private int             plus_value;
    private int             result_value;

    private Inventory srt_inven;

  
    private void Start()
    {
        srt_data        = GameObject.FindObjectOfType<SetData>();
        srt_gear        = GameObject.FindObjectOfType<Set_PlayerInfo>();
        srt_inven       = GameObject.FindObjectOfType<Inventory>();
        power_start     = (int)srt_data.player.Power;
        defence_start   = (int)srt_data.player.Defence;
    }
    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                startParent = transform.parent;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (transform.parent.childCount == 2 || this.gameObject.tag != transform.parent.tag && transform.parent.tag != "slot")
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
    public void Set_Weapon(Transform _obj)
    {
        ItemScript child    = this.gameObject.GetComponent<ItemScript>();
        plus_value          = (int)child.GetInfo().STATUS_RAND;
        srt_inven.effect.gameObject.SetActive(false);

        if (_obj.tag == "Weapon")
        {
            result_value                = power_start + plus_value;
            srt_data.player.Power = result_value;
        }
        else if (_obj.tag == "Armor")
        {
            result_value                = defence_start + plus_value;
            srt_data.player.Defence = result_value;
        }
        else if (_obj.tag == "Serve")
        {
 
        }
        else if (_obj.tag == "slot")
        {
            if (startParent.name == "gear1")
                srt_data.player.Power = power_start;

            else if (startParent.name == "gear2")
                srt_data.player.Defence = defence_start;
        }
    }
}
