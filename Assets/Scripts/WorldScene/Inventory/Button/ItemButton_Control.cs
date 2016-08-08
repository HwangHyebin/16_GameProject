using UnityEngine;
using System.Collections;

public class ItemButton_Control : MonoBehaviour 
{
    public UISprite leave_window;
    public void Use()
    { 
    }
    public void LeaveGo_Items()
    {
        leave_window.gameObject.SetActive(true);
    }
}
