using UnityEngine;
using System.Collections;

public class JoystickControl : MonoBehaviour 
{
    public  bool        drag            = false;
    public  Transform   stick;
    public  Vector3     axis;
    public  Vector3     defaultCenter;

    private float       raudius;
    private Touch       myTouch;

	void Start () 
    {
        raudius         = GetComponent<RectTransform>().sizeDelta.y / 5;
        defaultCenter   = stick.position;
	}
    public void Move()
    {
        drag                = true;
        Vector3 touchPos    = Input.mousePosition; //Input.GetTouch(0).position;
        axis                = (touchPos - defaultCenter).normalized;
        float distance      = Vector3.Distance(touchPos, defaultCenter);
        if (distance > raudius)
        {
            stick.position  = defaultCenter + axis * raudius;
        }         
        else
        {
            stick.position  = defaultCenter + axis * distance;
        }   
    }
    public void End()
    {
        drag            = false;
        axis            = Vector3.zero;
        stick.position  = defaultCenter;
    }
}
