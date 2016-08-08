using UnityEngine;
using System.Collections;

public class Inventory_Button : MonoBehaviour 
{
    public GameObject inven;

    public void X()
    {
        inven.gameObject.SetActive(false);
    }
    public void Open()
    {
        inven.gameObject.SetActive(true);
    }
}
