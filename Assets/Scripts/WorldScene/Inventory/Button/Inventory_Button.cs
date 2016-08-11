using UnityEngine;
using System.Collections;

public class Inventory_Button : MonoBehaviour 
{
    public  GameObject  inven;
    private Inventory   srt_inven;

    private void Start()
    {
        srt_inven = GameObject.FindObjectOfType<Inventory>();
    }
    public void X()
    {
        inven.gameObject.SetActive(false);
        srt_inven.effect.gameObject.SetActive(false);
    }
    public void Open()
    {
        inven.gameObject.SetActive(true);
    }
}
