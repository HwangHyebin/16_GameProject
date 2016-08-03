using UnityEngine;
using System.Collections;

public class ZoomEffect : MonoBehaviour 
{
    public Camera target;
    private bool check = false;
    private int min = 15;
    private int max = 60;
    private int smooth = 5;

	private void Start () 
    { 
	}

	private void Update () 
    {
        if (check == true)
            target.fieldOfView = Mathf.Lerp(target.fieldOfView, min, Time.deltaTime * smooth);
        else
            target.fieldOfView = Mathf.Lerp(target.fieldOfView, max, Time.deltaTime * smooth);
	}
    public void Toggle_Button()
    {
        if (check == true)
            check = false;
        else
            check = true;
    }
}
