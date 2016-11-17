using UnityEngine;
using System.Collections;

public class SelectStage : MonoBehaviour
{
    private TouchManager    srt_touchManager;
    private CameraControl   srt_camera;
    private GameObject      camera;
    private int touch_count;

    private GameObject current_collider;
    private GameObject prev_collider;
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
                    if (touch_count == 0)
                    {
                        current_collider = hit.collider.gameObject;
                    }
                    else if (touch_count > 0)
                    {
                        prev_collider = current_collider;
                        current_collider = hit.collider.gameObject;
                    }
                    ++touch_count;
                    if (camera == null)
                    {
                        camera = srt_camera.CurrentCamera.gameObject;
                    }
                    if (current_collider != prev_collider)
                    {
                        current_collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                        if (prev_collider != null)
                        {
                            prev_collider.gameObject.GetComponent<Renderer>().material.color = Color.white;
                        }
                    }
                    //**터치된 부분을 카메라의 중심으로 둘것
                    //스테이지 선택
                }
                else if(srt_touchManager.DoubleTouch)
                {
                    //스테이지 이동 
                    Application.LoadLevel(3);
                }
            }
        } 
	}
}
