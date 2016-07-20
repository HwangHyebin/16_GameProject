using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillManager : MonoBehaviour 
{
    public  SkillButton[]           skillButton_array;      // 스킬 버튼 오브젝트 담는 배열
    public  Sprite[]                image_array;
    public  Sprite[]                bgImage_array;

    [HideInInspector]
    public  SkillCharacterBase[]    skill_array;            // 스킬을 가르키기 위한 포인터를 담는 배열. 부모로 접근해서 스킬에 접근.
    [HideInInspector]
    public  string[]                string_array;           // 인벤토리에서 설정한 스킬을 문자열로 담고있는 배열, 나중에 인벤토리(?)에서 설정한 스킬 xml파일로 읽어올것. 

    private SkillCharacterFactory   srt_skillFactory;

    private void Awake()
    {
        srt_skillFactory = GameObject.FindObjectOfType<SkillCharacterFactory>() as SkillCharacterFactory;
        Array_Instance();
    }
    private void Start()
    {
        Init_ButtonIMG();
    }
    public void Create_Skill()
    {
        for (int i = 0; i < skillButton_array.Length; ++i)
        {
            if (skillButton_array[i].GetPressButton() == true) // 버튼이 눌린다면
            {
                if (skillButton_array[i].img.sprite != image_array[4])
                {
                    Skill_Create(i);
                }
            }
        }
    }
    private void Array_Instance() //skill array 인스턴스.
    {
        skill_array                 = new SkillCharacterBase[3];
        string_array                = new string[] {"Archer","Magician","Shield"};
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
    public void Skill_Create(int _num)
    {
        srt_skillFactory.CreateSkillCharacter(string_array[_num], ref skill_array[_num]);
        skill_array[_num].Init();
    }
}
