using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour 
{
    public  Sprite[]                                    image_array;
    public  Sprite[]                                    bgImage_array;
    public  SkillButton[]                               skillButton_array;      // 스킬 버튼 오브젝트 담는 배열

    [HideInInspector]
    public  SummonsBase[]                               skill_array;            // 스킬을 가르키기 위한 포인터를 담는 배열. 부모로 접근해서 스킬에 접근.
    [HideInInspector]
    public  string[]                                    string_array;           // 인벤토리에서 설정한 스킬을 문자열로 담고있는 배열, 나중에 인벤토리(?)에서 설정한 스킬 xml파일로 읽어올것. 

    public  List<KeyValuePair<DateTime, SummonsBase>>   priority_list; //우선 순위 정렬
    private SummonsFactory                              srt_skillFactory;
    public  GameObject target;
    
    private void Awake()
    {
        srt_skillFactory = GameObject.FindObjectOfType<SummonsFactory>() as SummonsFactory;
        Array_Instance();
    }
    private void Start()
    {
        Init_ButtonIMG();
    }
    private void Update()
    {
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
                    SummonsBase _base = srt_skillFactory.CreateSkillCharacter(string_array[i], ref skill_array[i]);
                    skillButton_array[i].SendMessage("Set_ButtonCoolTime", _base.status.coolTime);
                    Shield shiled = GameObject.FindObjectOfType<Shield>();
                    if (_base != shiled)
                    {
                        priority_list.Add(new KeyValuePair<DateTime, SummonsBase>(DateTime.Now, _base));
                        priority_list.Sort((Lhs, Rhs) => Lhs.Key.Ticks.CompareTo(Rhs.Key.Ticks) 
                            );
                    }
                    target = priority_list[0].Value.gameObject;
                    skill_array[i].Init();
                }
            }
        }
    }
    private void Array_Instance() //skill array 인스턴스.
    {
        skill_array                 = new SummonsBase[3];
        string_array                = new string[] {"Archer","Magician","Shield"};
        priority_list               = new List<KeyValuePair<DateTime, SummonsBase>>();
        for (int i = 0; i < skillButton_array.Length; ++i)
        {
            string ObjectName       = string.Format("SkillButton{0:0}", (i + 1));
            skillButton_array[i]    = GameObject.Find(ObjectName).GetComponent<SkillButton>();
            skill_array[i]          = GetComponent<SummonsBase>();
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
                priority_list[i].Value.anim.SetInteger("animation", 2);
                StartCoroutine("Death");
                Destroy(priority_list[i].Value.gameObject);
                priority_list.RemoveAt(i);
            }
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.8f);
    }
}
