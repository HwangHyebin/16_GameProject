using UnityEngine;
using System.Collections;

public class SummonsScript : MonoBehaviour 
{
    public UISprite img;
    public UILabel info_text;

    private CharacterInformation m_summonsInfo;
    private SummonsSystem srt_summons;

    private void Start()
    {
        srt_summons = GameObject.FindObjectOfType<SummonsSystem>();
    }
    public void SetSummonsInfo(CharacterInformation _info)
    {
        m_summonsInfo = _info;
        img.spriteName = m_summonsInfo.Name;
    }
    public CharacterInformation GetSummonsInfo()
    {
        return m_summonsInfo;
    }
    private void OnClick()
    {
        info_text.text = m_summonsInfo.Info;
        srt_summons.SelectSummons(this.gameObject.GetComponent<SummonsScript>());
    }
}
