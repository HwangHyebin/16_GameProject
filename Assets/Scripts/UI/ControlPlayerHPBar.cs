using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlPlayerHPBar : HPBarBase 
{
    private UISprite        img;
    private ObjectManager   srt_objectManager;

    private void Start()
    {
        base.Start();

        img                 = GetComponent<UISprite>(); 
        m_StartScale        = transform.localScale;
        img.color           = new Color((rgb.r / 255), (rgb.g / 255), (rgb.b / 255));
        srt_objectManager   = GameObject.FindObjectOfType<ObjectManager>();
        start_HP = m_HP     = GameObject.FindObjectOfType<Player>().status.hp;
    }
    private void Update()
    {
        Vector3 hpScale = m_StartScale;
        if (m_HP  >= 0.0f)
        {
            hpScale.x = m_HP/start_HP;
            this.transform.localScale = hpScale;
        }
        else
        {
            hpScale.x = 0.0f;
            this.transform.localScale = hpScale;
            //죽음.
        }
        for (int i = 0; i < srt_objectManager._enemyArray.Length; ++i)
        {
            if (m_HP/start_HP < 0.5f) 
            {
                rgb.r += 1.0f;
                if (rgb.r >= 255.0f && m_HP/start_HP <= 0.3f)
                {
                    rgb.r = 255.0f;
                    rgb.g -= 1.0f;
                }
                img.color = new Color(rgb.r / 255, rgb.g / 255, rgb.b / 255);
            }
        }
    }
}
