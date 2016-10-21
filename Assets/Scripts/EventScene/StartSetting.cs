using UnityEngine;
using System.Collections;

public class StartSetting : MonoBehaviour
{
    private GameObject robbyUI;

    public GameObject RobbyUI
    {
        get { return robbyUI; }
    }
    private void Awake()
    {
        //if (GameObject.Find("RobbyUI").gameObject != null)
        //{
        //    robbyUI = GameObject.Find("RobbyUI").gameObject;
        //    if (robbyUI.activeInHierarchy == true)
        //    {
        //        robbyUI.SetActive(false);
        //    }
        //}
    }
	private void Start ()
    {
        
	}

    private void Update() 
    {
	
	}
}
