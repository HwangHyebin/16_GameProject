using UnityEngine;
using System.Collections;

public class click : MonoBehaviour
{
    private StartSetting     srt_Init;
    private void Start()
    {
        srt_Init = GameObject.FindObjectOfType<StartSetting>();
    }
    private void OnClick()
    {
        Data.characters[3].HP = 80;
        srt_Init.RobbyUI.SetActive(true);
        Application.LoadLevel(1);
    }
}
