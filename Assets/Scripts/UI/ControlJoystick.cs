using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ControlJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public  bool    drag        = false;
    private Image   backImg;
    private Image   joystickImg;
    private Vector3 inputVector;
    
	void Start () 
    {
        backImg     = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
	}
    public virtual void OnDrag(PointerEventData pad)
    {
        drag = true;
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backImg.rectTransform, pad.position, pad.pressEventCamera, out pos))
        {
            pos.x = (pos.x / backImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / backImg.rectTransform.sizeDelta.y);
            inputVector = new Vector3(pos.x*2 - 1, 0, pos.y*2 -1);
            inputVector = (inputVector.magnitude > 1.0f)? inputVector.normalized:inputVector;

            joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (backImg.rectTransform.sizeDelta.x / 3),
                                                                     inputVector.z * (backImg.rectTransform.sizeDelta.y / 3));
        }
    }
    public virtual void OnPointerDown(PointerEventData pad)
    {
        OnDrag(pad);
    }
    public virtual void OnPointerUp(PointerEventData pad)
    {
        drag = false;
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }
    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }
    public float Vertical() 
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");
    }
}
