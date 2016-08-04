using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour 
{
    public UISprite m_img;
    private string m_name;
    private string m_spriteName;

    public void Set_SpriteName(string _spriteName)
    {
        m_img.spriteName = _spriteName;
        m_name = _spriteName;
    }
    public void NameCheck()
    {
        Debug.Log("my name = " + m_name);
    }
}
