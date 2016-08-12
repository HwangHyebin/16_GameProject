using UnityEngine;
using System.Collections;

public class CharacterDrag : MonoBehaviour 
{
    private Transform startParent;
    private Transform currentParent;

	private void Start () 
    {
	
	}
	private void Update () 
        //여기 작업하고 있었음.
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                startParent = transform.parent;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (transform.parent.childCount == 2 )
                {
                    transform.parent = startParent;
                }
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
                currentParent = transform.parent;
                if (startParent != currentParent)
                {
                    Debug.Log("장착");
                }
            }
        }
	
	}
}
