using UnityEngine;
using System.Collections;

public class JoystickControl : MonoBehaviour 
{
    public bool drag = false;
    public Transform stick;
    public Vector3 axis;

    float raudius;
    public Vector3 defaultCenter;
    Touch myTouch;

	// Use this for initialization
	void Start () 
    {
        raudius = GetComponent<RectTransform>().sizeDelta.y / 4;
        defaultCenter = stick.position;
	}
    public void Move()
    {
        drag = true;
        Vector3 touchPos = Input.mousePosition;
            //Input.GetTouch(0).position;
        axis = (touchPos - defaultCenter).normalized;

        float distance = Vector3.Distance(touchPos, defaultCenter);
        if (distance > raudius)
        {
            stick.position = defaultCenter + axis * raudius;
        }         
        else
        {
            stick.position = defaultCenter + axis * distance;
        }   
    }
    public void End()
    {
        drag = false;
        axis = Vector3.zero;
        stick.position = defaultCenter;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
