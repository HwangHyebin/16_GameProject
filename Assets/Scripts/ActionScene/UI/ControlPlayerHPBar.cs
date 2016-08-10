﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlPlayerHPBar : HPBarBase 
{
    private UISprite        img;
    private ObjectManager   srt_objectManager;

    //***전투가 끝나고나면 hpScale값과 rgb값을 함께 보내줌으로써 월드씬에서 적용시켜야 함***

    private void Start()
    {
        base.Start();

        img                 = GetComponent<UISprite>(); 
        m_StartScale        = transform.localScale;
        img.color           = new Color((rgb.r / 255), (rgb.g / 255), (rgb.b / 255));
        srt_objectManager   = GameObject.FindObjectOfType<ObjectManager>();
        m_HP                = GameObject.FindObjectOfType<Player>().status.hp;
    }
    private void Update()
    {
        Vector3 hpScale = m_StartScale;
        if (m_HP  >= 0.0f)
        {
            hpScale.x = m_HP * 0.01f;
            this.transform.localScale = hpScale;
        }
        else
        {
            hpScale.x = 0.0f;
            this.transform.localScale = hpScale;
            //죽음.
        }
        if (m_HP < 60.0f) 
        {
            rgb.r += 1.0f;
            if (rgb.r >= 255.0f && m_HP <= 30.0f)
            {
                rgb.r = 255.0f;
                rgb.g -= 1.0f;
            }
            img.color = new Color(rgb.r / 255, rgb.g / 255, rgb.b / 255);
        }
    }
}