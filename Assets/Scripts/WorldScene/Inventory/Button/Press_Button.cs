using UnityEngine;
using System.Collections;

public class Press_Button : MonoBehaviour 
{
    public  GameObject  window;
    public  bool        open = false;

    public void X()
    {
        if (window.name == "Inventory")
        {
            window.GetComponent<Inventory>().effect.gameObject.SetActive(false);
        }
        window.SetActive(false);
        open = false;
    }
    public void Open()
    {
        window.SetActive(true);
        open = true;
    }
}
