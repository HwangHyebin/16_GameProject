using UnityEngine;
using System.Collections;

public class SceneButtonControl : MonoBehaviour 
{
    public void PressStartButton()
    {
        Application.LoadLevel(1);
    }
    public void PressExitButton()
    {
        Application.Quit();
    }
    public void PressReStartButton()
    {
        Application.LoadLevel(1);
    }
}
