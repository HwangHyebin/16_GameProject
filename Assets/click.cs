using UnityEngine;
using System.Collections;

public class click : MonoBehaviour
{
    private void OnClick()
    {
        Debug.Log(Data.m_Items.Count);
        Data.characters[3].HP = 80;
        Application.LoadLevel(1);
    }
}
