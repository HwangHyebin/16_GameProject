using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour
{
    private Vector3     startPosition;
    private Transform   startParent;

    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began )
            {
                startParent = transform.parent;
            }
            else if (touch.phase == TouchPhase.Ended )
            {
                if (transform.parent.childCount == 2)
                {
                    transform.parent = startParent;
                }
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);  
            }
        }
    }
}
