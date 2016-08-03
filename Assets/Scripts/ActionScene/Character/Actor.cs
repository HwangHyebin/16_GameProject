using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour 
{
    public Animator anim;
    public Rigidbody my_body;

	protected void Start () 
    {
        anim    = this.GetComponent<Animator>();
        my_body = this.GetComponent<Rigidbody>();
	}
	
}
