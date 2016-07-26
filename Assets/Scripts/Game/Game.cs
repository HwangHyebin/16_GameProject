using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    private void Awake()
    {
        ObjectManager.Instance.Enter();
    }
	private void Start () 
    { 
	}
	private void Update () 
    {
        ObjectManager.Instance.Execute();
	}
}
