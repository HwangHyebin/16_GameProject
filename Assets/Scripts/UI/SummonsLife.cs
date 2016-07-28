using UnityEngine;
using System.Collections;

public class SummonsLife : HPBarBase 
{
    public      float           m_Hight         = 1.2f;
    public      GameObject      UI_back;
    public      GameObject      UI_HP_back;
    protected   Transform       target          = null;
    private     SpriteRenderer  img;

    private void Start()
    {
        base.Start();
        img             = GetComponent<SpriteRenderer>();
        target          = this.transform.parent;
        m_StartScale    = transform.localScale;
        img.color       = new Color((rgb.r / 255), (rgb.g / 255), (rgb.b / 255));
        start_HP = m_HP = GameObject.FindObjectOfType<Enemy>().status.hp;
    }
    private void Update()
    {
        UI_HP_back.transform.position = UI_back.transform.position = transform.position = target.position + (Vector3.up * m_Hight);
        UI_HP_back.transform.rotation = UI_back.transform.rotation = transform.rotation = Camera.main.transform.rotation;

        Debug.Log(Vector3.up * m_Hight);

        Vector3 hpScale = m_StartScale;
        if (m_HP > 0.0f)
        {
            hpScale.x = m_HP / start_HP;
            transform.localScale = hpScale;
        }
        else
        {
            hpScale.x = 0.0f;
            transform.localScale = hpScale;
        }
        if (m_HP / start_HP <= 0.7f)
        {
            rgb.r += 1.0f;
            if (rgb.r >= 255.0f && m_HP / start_HP <= 0.4f)
            {
                rgb.r = 255.0f;
                rgb.g -= 1.0f;
            }
            img.color = new Color(rgb.r / 255, rgb.g / 255, rgb.b / 255);
        }
    }
}
