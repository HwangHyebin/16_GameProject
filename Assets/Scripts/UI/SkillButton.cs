using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillButton : MonoBehaviour 
{
    public  bool    pressed         = false;
    public  Image   bg_img;
    public  Image   img;

    public  Button  button;
  
    private float   timer;
    public float    delay;
    private SkillManager srt_skillManager;

    private void Start()
    {
        timer   = 0.0f;
        delay   = 0.0f;
        img     = GetComponent<Image>();
        button  = GetComponent<Button>();
        srt_skillManager = GameObject.FindObjectOfType<SkillManager>();
    }
    public void PressButton() //버튼이벤트
    {
        Debug.Log("호출");
        if (timer >= delay && pressed == false)
        {
            Debug.Log("pressed");
            name    = this.gameObject.name;
            pressed = true;
            timer   = 0.0f;
        }
    }
    public bool GetPressButton() //이게 true면 생성
    {
        bool temp   = pressed;
        pressed     = false;
        return temp;
    }
    private void Update()
    {
       timer += Time.deltaTime;
       float ratio = 0.0f + (timer / delay);
       if (timer <= delay && pressed == false)
       {
           if (img.sprite != srt_skillManager.image_array[4])
           {
               img.fillAmount = ratio;
           }
       }
    }
    public void Set_ButtonCoolTime(float _delay)
    {
        delay = _delay;
    }
}
