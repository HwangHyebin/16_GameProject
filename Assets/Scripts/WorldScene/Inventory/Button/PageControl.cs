using UnityEngine;
using System.Collections;

public class PageControl : MonoBehaviour 
{
    public  GameObject  firstPage;
    public  GameObject  secondPage;
    public  UILabel     label;
    private Vector3     vec;

	private void Start () 
    {
        vec = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        secondPage.SetActive(false);
	}
    public void NextPage() 
    {
        firstPage.SetActive(false);
        secondPage.SetActive(true);
        label.text = "2";
    }
    public void PrevPage()
    {
        firstPage.SetActive(true);
        secondPage.SetActive(false);
        label.text = "1";
    }
}
