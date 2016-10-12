using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    private Camera worldCamera;
    private Camera uiCamera;
    private Camera          currentCamera;
    private Press_Button    srt_button;
    public bool open;

    public Camera CurrentCamera
    {
        set { currentCamera = value; }
        get { return currentCamera; }
    }
	private void Start () 
    {
        worldCamera     = GameObject.Find("Main Camera").GetComponent<Camera>();
        uiCamera        = GameObject.Find("Camera").GetComponentInChildren<Camera>();
        currentCamera   = worldCamera;
        srt_button      = GameObject.FindObjectOfType<Press_Button>();
	}
	private void Update () 
    {
        if (srt_button.Result(open) == true)
        {
            currentCamera = uiCamera;
            Debug.Log("okok");
        }
        else if (srt_button.Result(open) == false)
        {
            currentCamera = worldCamera;
            Debug.Log("nono");
        }
	}
}
