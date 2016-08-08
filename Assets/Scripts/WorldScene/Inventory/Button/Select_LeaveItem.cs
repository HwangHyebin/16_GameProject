using UnityEngine;
using System.Collections;

public class Select_LeaveItem : MonoBehaviour 
{
    public void YES()
    {
        //아이템 삭제
    }
    public void NO()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
