using UnityEngine;
using System.Collections;
using System;

public class SelectButton : MonoBehaviour 
{
    private EventSceneManager srt_SceneManager;
	private void Start () 
    {
        srt_SceneManager = GameObject.FindObjectOfType<EventSceneManager>();
	}
	private void Update () 
    {
	}
    private void OnClick()
    {
        int selectNum = Convert.ToInt32(this.gameObject.name);
        --selectNum;        
        srt_SceneManager.ChangeQAType(selectNum);
    }
}
