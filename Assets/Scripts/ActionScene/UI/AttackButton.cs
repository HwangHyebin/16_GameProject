using UnityEngine;
using System.Collections;

public class AttackButton : MonoBehaviour 
{
    private bool            press_attack    = false;

    public void Press_Attack()
    {
        press_attack = true;
    }
    public bool GetPressButton()
    {
        bool temp = press_attack;
        press_attack = false;
        return temp;
    }
}
