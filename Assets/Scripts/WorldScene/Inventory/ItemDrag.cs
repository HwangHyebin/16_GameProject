using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour
{
    private Vector3 startPosition;
    private Transform startParent;

    private void Start()
    {
        startParent = transform.parent;
    }
    private void Update()
    {
        //**터치가 떼졌을때로 수정.**
        if (transform.parent != startParent)
        {
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
        }
    }
}
