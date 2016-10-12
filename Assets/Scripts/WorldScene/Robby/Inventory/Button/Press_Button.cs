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
        if (window.name == "Inventory")
        {
            window.GetComponent<Inventory>().effect.gameObject.SetActive(false);
        }
        Result(false);
        window.SetActive(false);
    }
    public void Open()
    {
        Result(true);
        window.SetActive(true);
    }
    public bool Result(bool check)
    {
        return srt_camera.open;
    }
}
