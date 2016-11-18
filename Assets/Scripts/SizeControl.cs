using UnityEngine;
using System.Collections;

public class SizeControl : MonoBehaviour 
{
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height * 16 / 9, true);
    }
}
