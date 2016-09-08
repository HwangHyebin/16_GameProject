using UnityEngine;
using System.Collections;

public class Press_Button : MonoBehaviour 
{
    public  GameObject  window;
    private CameraControl srt_camera;

    private void Start()
    {
        srt_camera = GameObject.FindObjectOfType<CameraControl>();
    }
    public void X()
    {
        srt_camera.open = false;
        if (window.name == "Inventory")
        {
            window.GetComponent<Inventory>().effect.gameObject.SetActive(false);
        }
        window.SetActive(false);
    }
    public void Open()
    {
        srt_camera.open = true;
        window.SetActive(true);
    }
    public bool Result()
    {
        return srt_camera.open;
    }
}
