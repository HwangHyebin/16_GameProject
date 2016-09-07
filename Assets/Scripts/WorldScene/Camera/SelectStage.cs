using UnityEngine;
using System.Collections;

public class SelectStage : MonoBehaviour
{
    private TouchManager    srt_touchManager;
    private CameraControl   srt_camera;
	private void Start () 
    {
        srt_touchManager = GameObject.FindObjectOfType<TouchManager>();
        srt_camera = GameObject.FindObjectOfType<CameraControl>();
	}
	private void Update () 
    {
        Vector2 pos = srt_touchManager.CurrentTouch.position;
        Vector3 touchPos = new Vector3(pos.x, pos.y, 0.0f);
        Ray ray = srt_camera.CurrentCamera.ScreenPointToRay(touchPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (srt_touchManager.SingleTouch)
            {
                //스테이지 선택
                Debug.Log(hit.collider.name);
            }
            if (srt_touchManager.DoubleTouch)
            {
                if (hit.collider.gameObject.tag == "Stage")
                {
                    Debug.Log("stage change");
                    //스테이지 이동 
                    Application.LoadLevel(2);
                }
            }
        } 
	}

}
