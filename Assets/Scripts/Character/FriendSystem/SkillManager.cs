using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour 
{
    public  Sprite[]                image_array;
    public  Sprite[]                bgImage_array;
    public  SkillButton[]           skillButton_array;      // 스킬 버튼 오브젝트 담는 배열

    [HideInInspector]
    public  SkillCharacterBase[]    skill_array;            // 스킬을 가르키기 위한 포인터를 담는 배열. 부모로 접근해서 스킬에 접근.
    [HideInInspector]
    public  string[]                string_array;           // 인벤토리에서 설정한 스킬을 문자열로 담고있는 배열, 나중에 인벤토리(?)에서 설정한 스킬 xml파일로 읽어올것. 

    private SkillCharacterFactory   srt_skillFactory;
    private List<KeyValuePair<DateTime, SkillCharacterBase>> priority_list; //우선 순위 정렬

    private void Awake()
    {
        srt_skillFactory = GameObject.FindObjectOfType<SkillCharacterFactory>() as SkillCharacterFactory;
        Array_Instance();
    }
    private void Start()
    {
        Init_ButtonIMG();
    }
    private void Update()
    {
        for (int i = 0; i < priority_list.Count; ++i)
        {
            //Debug.Log("foo " + i + " = " + priority_list[i]);
        }
        Destroy_check();
    }
    public void Create_Skill()
    {
        for (int i = 0; i < skillButton_array.Length; ++i)
        {
            if (skillButton_array[i].GetPressButton() == true) // 버튼이 눌린다면
            {
                if (skillButton_array[i].img.sprite != image_array[4]) //눌린 버튼의 이미지가 null 이미지가 아니라면
                {
                    SkillCharacterBase _base = srt_skillFactory.CreateSkillCharacter(string_array[i], ref skill_array[i]);
                    skillButton_array[i].SendMessage("Set_ButtonCoolTime", _base.status.coolTime);
                    Shield shiled = GameObject.FindObjectOfType<Shield>();
                    if (_base != shiled) //만약에 스킬이 shiled가 아니라면.
                    {
                       // 시간값과 base를 같이 넣어 리스트를만들고 정렬.
                        priority_list.Add(new KeyValuePair<DateTime, SkillCharacterBase>(DateTime.Now, _base));
                        priority_list.Sort((Lhs, Rhs) => Lhs.Key.Ticks.CompareTo(Rhs.Key.Ticks) 
                            );
                    }
                    skill_array[i].Init();
                }
            }
        }
    }
    private void Array_Instance() //skill array 인스턴스.
    {
        skill_array                 = new SkillCharacterBase[3];
        string_array                = new string[] {"Archer","Magician","Shield"};
        priority_list               = new List<KeyValuePair<DateTime, SkillCharacterBase>>();
        for (int i = 0; i < skillButton_array.Length; ++i)
        {
            string ObjectName       = string.Format("SkillButton{0:0}", (i + 1));
            skillButton_array[i]    = GameObject.Find(ObjectName).GetComponent<SkillButton>();
            skill_array[i]          = GetComponent<SkillCharacterBase>();
        }
    }
    private void Init_ButtonIMG()
    {
        for (int i = 0; i < skillButton_array.Length; ++i)
        {
            switch (string_array[i])
            {
                case "Archer":
                    skillButton_array[i].bg_img.sprite  = bgImage_array[0];
                    skillButton_array[i].img.sprite     = image_array[0];
                    break;
                case "Magician":
                    skillButton_array[i].bg_img.sprite  = bgImage_array[1];
                    skillButton_array[i].img.sprite     = image_array[1];
                    break;
                case "Pirate":
                    skillButton_array[i].bg_img.sprite  = bgImage_array[2];
                    skillButton_array[i].img.sprite     = image_array[2];
                    break;
                case "Shield":
                    skillButton_array[i].bg_img.sprite  = bgImage_array[3];
                    skillButton_array[i].img.sprite     = image_array[3];
                    break;
                default:
                    skillButton_array[i].bg_img.sprite  = bgImage_array[4];
                    skillButton_array[i].img.sprite     = image_array[4];
                    break;
            }
        }
    }
    public void Destroy_check()
    {
        for (int i = 0; i < priority_list.Count; ++i)
        {
            if (priority_list[i].Value.destroy == true)
            {
                Destroy(priority_list[i].Value.gameObject);
                priority_list.RemoveAt(i);
            }
        }
    }
}
