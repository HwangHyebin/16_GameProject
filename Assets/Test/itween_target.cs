using UnityEngine;
using System.Collections;

public class itween_target : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("box"), "time", 5));
	
	}
	
	// Update is called once per frame
	void Update () {
        
	
	}
}
