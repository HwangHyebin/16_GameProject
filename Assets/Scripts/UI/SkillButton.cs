using UnityEngine;
using System.Collections;

public class SkillButton : MonoBehaviour 
{
    private string name;
    private bool pressed = false;
   
    public void PressButton()
    {
        name = this.gameObject.name;
        pressed = true;
    }
    public bool GetPressButton()
    {
        bool temp = pressed;
        pressed = false;
        return temp;
    }
    public string GetButtonName()
    {
        return name;
    }
}
