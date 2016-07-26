﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHP : HPBarBase 
{
    private UISprite                img;

    private void Start()
    {
        base.Start();
        img             = GetComponent<UISprite>(); 
        m_StartScale    = transform.localScale;
        target          = transform.parent.FindChild("HP");
        img.color       = new Color((rgb.r / 255), (rgb.g / 255), (rgb.b / 255));
        start_HP = m_HP = GameObject.FindObjectOfType<Player>().status.hp;
    }
    private void Update()
    {
        Vector3 hpScale = m_StartScale;
        //Debug.Log("hpbar =" + m_HP);
        if (m_HP  >= 0.0f)
        {
            hpScale.x = m_HP/start_HP;
            //Debug.Log("hpScale = " + hpScale.x);
            target.transform.localScale = hpScale;
            //Debug.Log("hp bar " + target.transform.localScale);
            if (m_HP / start_HP < 0.5f)
            {
                rgb.r += 1.0f;
                if (rgb.r >= 255.0f && m_HP / start_HP <= 0.3f)
                {
                    rgb.r = 255.0f;
                    rgb.g -= 1.0f;
                }
                img.color = new Color(rgb.r / 255, rgb.g / 255, rgb.b / 255);
            }
        }
        else
        {
            hpScale.x = 0.0f;
            target.transform.localScale = hpScale;
            //죽음.
        }
    }
}