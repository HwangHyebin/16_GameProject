using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public  Camera          worldCamera;
    public  Camera          uiCamera;
    private Camera          currentCamera;
    private Press_Button    srt_button;

    public Camera CurrentCamera
    {
        set { currentCamera = value; }
        get { return currentCamera; }
    }
	private void Start () 
    {
        currentCamera = worldCamera;
        srt_button = GameObject.FindObjectOfType<Press_Button>();
	}
	private void Update () 
    {
        if (srt_button.open == true)
        {
            currentCamera = uiCamera;
            Debug.Log("okok");
        }
        else
        {
            currentCamera = worldCamera;
            Debug.Log("nono");
        }
	}
}
