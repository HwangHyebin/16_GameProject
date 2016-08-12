using UnityEngine;
using System.Collections;

public class ChoiceButton : MonoBehaviour 
{
    private Getout_Character srt_getout;
    private void Start()
    {
        srt_getout = GameObject.FindObjectOfType<Getout_Character>();
    }
    public void Yes()
    {
        Debug.Log("yes");
    }
    public void No()
    {
        srt_getout.pop_up.gameObject.SetActive(false);
        Debug.Log("no");
    }
}
