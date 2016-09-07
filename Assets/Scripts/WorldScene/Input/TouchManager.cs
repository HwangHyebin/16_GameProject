using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour 
{
    private Touch   touch;
    private float   touchDelay;
    private bool    doubleTouch = false;
    private bool    singleTouch = false;

    public Touch CurrentTouch
    {
        get { return touch; }
    }
    public bool SingleTouch
    {
        get { return singleTouch; }
    }
    public bool DoubleTouch
    {
        get { return doubleTouch; }
    }
	void Start () 
    {
	}
	void Update () 
    {
        if (Input.touchCount > 0)
        {
            touchDelay += Time.deltaTime;
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended && touchDelay < 0.2f)
            {
                singleTouch = false;
                doubleTouch = false;
                StartCoroutine("TouchCheck");
            }
        }
        else
        {
            touchDelay = 0.0f;
        }
	}
    IEnumerator TouchCheck()
    {
        singleTouch = false;
        yield return new WaitForSeconds(0.2f);
        if (touch.tapCount == 1)
        {
            singleTouch = true;
            Debug.Log("single");
        }
        else if (touch.tapCount == 2)
        {
            doubleTouch = true;
            Debug.Log("double");
        }
        StopCoroutine("TouchCheck");
    }
}
