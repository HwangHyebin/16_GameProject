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
        Data.characters[3].HP = 100;
        Data.characters[3].Power = 10;
        Data.characters[3].Defence = 2;
        Data.characters[3].Gold = 0;
        Application.LoadLevel(1);
    }
}
