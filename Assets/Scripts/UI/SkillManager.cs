using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour 
{
    public  SkillButton[]           skillButton_array;      // 스킬 버튼 오브젝트 담는 배열

    [HideInInspector]
    public  SkillCharacterBase[]    skill_array;            // 스킬을 가르키기 위한 포인터를 담는 배열. 부모로 접근해서 스킬에 접근.
    [HideInInspector]
    public  string[]                string_array;           // 인벤토리에서 설정한 스킬을 문자열로 담고있는 배열, 나중에 인벤토리(?)에서 설정한 스킬 xml파일로 읽어올것. 
    [HideInInspector]
    public  bool[]                  active_skillButtons;    //버튼 활성화 여부

    private float startTime;
    private float nextTime; // 10은 delay

    private float   coolTime;
    private int     count;

    private SkillCharacterFactory   srt_skillFactory;

    private void Start()
    {
        srt_skillFactory    = GameObject.FindObjectOfType<SkillCharacterFactory>() as SkillCharacterFactory;
        startTime           = 0;
        coolTime            = 10.0f;
        count = 0;
        nextTime            = startTime + 10.0f;
        Array_Instance();
        StartCoroutine("a");
    }
	private void Update () 
    {
        
        //Debug.Log("time = " + startTime);
        //if (skillButton_array[0].GetPressButton() == true)
        //{
        //    Debug.Log("button press");
        //    if (startTime == 0)
        //    {
        //        Debug.Log("create");
        //        Skill_Create(0);
        //        startTime = Time.time;
        //    }
        //}
        //if (Time.time >= nextTime && startTime != 0)
        //{
        //    startTime = 0;
           
        //    //for (int i = 0; i < skillButton_array.Length; ++i)
        //    //{
        //        //if (skillButton_array[0].GetPressButton() == false)
        //        {
        //            Debug.Log("10초 후");
        //            startTime = 0;
        //        }
        //    //}
        //}
	}
    IEnumerator a()
    {
        //yield return new WaitForSeconds(10);
        //if (skillButton_array[0].GetPressButton() == true)
        //{
        //    skillButton_array[0].GetPressButton();
        //    Skill_Create(0);
        //    StartCoroutine("a");
        //}
        while (true)
        {
            if (coolTime > 0)
            {
                coolTime -= 1;
            }
            else
            {
                coolTime = 10;
                if (count > 0)
                {
                    count = 0;
                    Skill_Create(0);
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
    public void Press_SkillButton()
    {
        if ( startTime == 0)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (skillButton_array[i].GetPressButton() == true) // 버튼이 눌린다면
                {
                    active_skillButtons[i] = true;
                    Skill_Create(i);
                }
            }
        }
        if ( nextTime < Time.time && startTime != 0) // 10초후
        {
            Debug.Log("ggggg");
            
        }
    }
    private void Array_Instance() //skill array 인스턴스.
    {
        skill_array = new SkillCharacterBase[3];
        active_skillButtons = new bool[3];
        for (int i = 0; i < 3; ++i)
        {
            string ObjectName       = string.Format("SkillButton{0:0}", (i + 1));
            skillButton_array[i]    = GameObject.Find(ObjectName).GetComponent<SkillButton>();
            string_array[i]         = "Archer";
            skill_array[i]          = GetComponent<SkillCharacterBase>();
            active_skillButtons[i]  = false;
        }
    }
    public void Skill_Create(int _num)
    {
        srt_skillFactory.CreateSkillCharacter(string_array[_num], ref skill_array[_num]);
        skill_array[_num].init();
    }
}
