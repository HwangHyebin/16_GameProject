using UnityEngine;
using System.Collections;

public class Getout_Character : MonoBehaviour
{
    public UISprite pop_up;

    public void Getout_Characters()
    {
        pop_up.gameObject.SetActive(true);
    }
}
