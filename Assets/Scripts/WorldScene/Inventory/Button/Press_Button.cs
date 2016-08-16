using UnityEngine;
using System.Collections;

public class Press_Button : MonoBehaviour 
{
    public  GameObject  window;
    private void Start()
    {
        //window.SetActive(false);
    }
    public void X()
    {
        if (window.name == "Inventory")
        {
            window.GetComponent<Inventory>().effect.gameObject.SetActive(false);
        }
        window.SetActive(false);
    }
    public void Open()
    {
        window.SetActive(true);
    }
}
