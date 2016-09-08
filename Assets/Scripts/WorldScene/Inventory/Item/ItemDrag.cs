using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour
{
    [HideInInspector]
    public int              power_start;
    [HideInInspector]
    public int              defence_start;

    private Set_PlayerInfo  srt_gear;
    private SetData         srt_data;
    private Inventory       srt_inven;
    private TouchManager    srt_touchManager;
    private Transform       startParent;
    private Transform       currentParent;
    private int             plus_value;
    private int             result_value;

    private void Start()
    {
        srt_data            = GameObject.FindObjectOfType<SetData>();
        srt_gear            = GameObject.FindObjectOfType<Set_PlayerInfo>();
        srt_inven           = GameObject.FindObjectOfType<Inventory>();
        srt_touchManager    = GameObject.FindObjectOfType<TouchManager>();
        power_start         = (int)srt_data.player.Power;
        defence_start       = (int)srt_data.player.Defence;
    }
    private void Update()
    {
        //왜 touch manager를 통해 하면 돌아왔을때 드래그가 안되는지???
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)//(srt_touchManager.CurrentTouch.phase == TouchPhase.Began)
            {
                startParent = transform.parent;
            }
            else if (touch.phase == TouchPhase.Ended)//(srt_touchManager.CurrentTouch.phase == TouchPhase.Ended)
            {

                if (transform.parent.childCount == 2 || this.gameObject.tag != transform.parent.tag && transform.parent.tag != "slot")
                {
                    transform.parent = startParent;
                }
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
                currentParent = transform.parent;
                if (startParent != currentParent && startParent != null)
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
