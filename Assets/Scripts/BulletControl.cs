using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour 
{
    private Rigidbody my_body;

	private void Start () 
    {
        my_body = GetComponent<Rigidbody>();
	}

	private void Update () 
    {
        //my_body.AddRelativeForce(this.transform.forward * 10.0f * Time.deltaTime);
       this.gameObject.transform.Translate(this.transform.forward * 1.0f * Time.deltaTime);
        //일정 범위이상 멀어지면 사라지게 하기.
        // archer와 자신의 position을 이용해 거리를 체크해서 destroy
	}
}
