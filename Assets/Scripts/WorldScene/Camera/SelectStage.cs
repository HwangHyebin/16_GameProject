using UnityEngine;
using System.Collections;

public class SelectStage : MonoBehaviour
{
    private TouchManager    srt_touchManager;
    private CameraControl   srt_camera;
    private GameObject camera;
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
            if (hit.collider.gameObject.tag == "Stage")
            {
                if (srt_touchManager.SingleTouch)
                {
                    if (camera == null)
                    {
                        camera = srt_camera.CurrentCamera.gameObject;
                    }
                    //**터치된 부분을 카메라의 중심으로 둘것
                    //스테이지 선택
                    Debug.Log(hit.collider.name);
                }
                else if(srt_touchManager.DoubleTouch)
                {
                    Debug.Log("stage change");
                    //스테이지 이동 
                    Application.LoadLevel(2);
                }
            }
        } 
	}
}
