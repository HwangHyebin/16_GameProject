using UnityEngine;
using System.Collections;

public class NotUse : MonoBehaviour
{
    public UISprite leave_window;

    public void LeaveGo_Items()
    {
        leave_window.gameObject.SetActive(true);
    }
}
