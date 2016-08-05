using UnityEngine;
using System.Collections;

public class PageControl : MonoBehaviour 
{
   // public  GameObject  button;
    public GameObject firstPage;
    public GameObject secondPage;
    private Vector3     vec;

	private void Start () 
    {
        vec = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
	}
    public void NextPage() 
    {
        //button.transform.localPosition = new Vector3(-485.0f, 0.0f, transform.localPosition.z);
        firstPage.SetActive(false);
        secondPage.SetActive(true);
    }
    public void PrevPage()
    {
        //button.transform.localPosition = new Vector3(0.0f, 0.0f, transform.localPosition.z);
        firstPage.SetActive(true);
        secondPage.SetActive(false);
    }
	private void Update ()
    {
	
	}
}
