﻿using UnityEngine;
using System.Collections;

public class HPBarBase : MonoBehaviour
{
    [HideInInspector]
    public      float       m_HP;
    protected   float       start_HP;
    protected   S_RGB       rgb;
    protected   Vector3     m_StartScale;
    protected   Transform   target          = null;
    protected CharacterBase _base;

    protected struct S_RGB
    {
        public float r;
        public float g;
        public float b;
    };

	protected void Start () 
    {
        rgb     = new S_RGB();
        rgb.r   = 0.0f;
        rgb.g   = 212.0f;
        rgb.b   = 0.0f;
        _base = GameObject.FindObjectOfType<CharacterBase>();
        m_HP = start_HP = _base.status.hp; 
	}
}
