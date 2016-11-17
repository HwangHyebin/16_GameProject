using UnityEngine;
using System.Collections;

public class CharacterDrag : MonoBehaviour 
{
    private Transform       startParent;
    private Transform       currentParent;
    private TouchManager    srt_touchManager;

	private void Start () 
    {
        srt_touchManager = GameObject.FindObjectOfType<TouchManager>();
	}
	private void Update ()  //여기 작업하고 있었음.
    {
        if (srt_touchManager.CurrentTouch.phase == TouchPhase.Began)
        {
            startParent = transform.parent;
        }
        else if (srt_touchManager.CurrentTouch.phase == TouchPhase.Ended)
        {
            if (transform.parent.childCount == 2 )
            {
                transform.parent = startParent;
            }
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
            currentParent = transform.parent;
            if (startParent != currentParent)
            {
                //Debug.Log("장착");
            }
        }
	}
}
