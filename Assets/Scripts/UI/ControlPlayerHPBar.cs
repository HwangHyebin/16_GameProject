using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlPlayerHPBar : HPBarBase 
{
    private UISprite                img;
    private Enemy.ENEMY_ANIMATOR    _enemyAnim;
    private GameManager             srt_gameManager;

    private void Start()
    {
        base.Start();

        img             = GetComponent<UISprite>(); 
        m_StartScale    = transform.localScale;
        img.color       = new Color((rgb.r / 255), (rgb.g / 255), (rgb.b / 255));
        target          = transform.parent.FindChild("HP");
        srt_gameManager = GameObject.FindObjectOfType<GameManager>();
        start_HP = m_HP = GameObject.FindObjectOfType<Player>().status.hp;
        
    }
    private void Update()
    {
        Vector3 hpScale = m_StartScale;
        if (m_HP  >= 0.0f)
        {
            hpScale.x = hpScale.x * ((float)m_HP * 0.01f);
            target.transform.localScale = hpScale;
        }
        else
        {
            hpScale.x = 0.0f;
            target.transform.localScale = hpScale;
            //죽음.
        }
        for (int i = 0; i < srt_gameManager._enemyArray.Length; ++i)
        {
            _enemyAnim = srt_gameManager._enemyArray[i].gameObject.GetComponent<Enemy>().enemy_anim;
            if (hpScale.x <= 0.5f) 
            {
                base.StartCoroutine("Change_Color");
            }
        }
    }
    IEnumerator Change_Color()
    {
        if (rgb.b == 0.0f && m_HP > 30.0f)
        {
            rgb.r += 1.0f;
            if (rgb.r >= 255.0f)
            {
                rgb.r = 255.0f;
                rgb.g -= 0.5f;
            }
        }
        img.color = new Color(rgb.r / 255, rgb.g / 255, rgb.b / 255);
        yield return new WaitForSeconds(m_HP / start_HP);
    }
}
