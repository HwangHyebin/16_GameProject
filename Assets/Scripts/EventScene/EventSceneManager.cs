using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventSceneManager : MonoBehaviour 
{
    public UILabel      question_text;
    public UILabel      select1_text;
    public UILabel      select2_text;
    public UILabel      select3_text;

    public UISprite     item_back;
    public UISprite     item_sp;
    public UILabel      item_label;

    private int         current_QANumber;
    private Inventory   srt_inven;
    private GameObject  robbyUI;

    private int[]       select_nums;
    private string[]    select_itemName;
    private int         question_rend;

    private bool        check = false;
    private float       timer;

    private byte[]      item_per;
    private int[]       percent;

    private STATE m_state;
    
    
    private Dictionary<int, QAType> m_DicQAType = new Dictionary<int, QAType>();

    public enum STATE
    {
        shop,
        attack,
        not
    };

	private void Start () 
    {
        robbyUI         = GameObject.Find("RobbyUI");
        robbyUI.transform.FindChild("Anchor").gameObject.SetActive(false);
        srt_inven       = GameObject.Find("RobbyUI").GetComponentInChildren<Inventory>();
        
        select_nums     = new int[3];
        select_itemName = new string[3];
        percent         = new int[] {5,10,20,25,40};//new int[5];
        item_per        = new byte[100];

        //확률계산 할 것
        //for (int i = 0; i < percent.Length; ++i)
        //{
        //    for (int j = 0; j < percent[i]; ++j)
        //    {

        //    }
        //}

        for (int i = 0; i < select_nums.Length; ++i)
        {
            select_nums[0] = Random.Range(1, 11);// ItemManager.Instance.GetItemsCount() + 1
            select_nums[1] = 14;
            select_itemName[i] = "";
        }
        question_rend = Random.Range(0, 2);//0
        //StartCoroutine("Go_Stage");
        Init_Question();
        timer = 0.0f;
	}
	
	private void Update () 
    {
        //if (check == true)
        //{
        //    timer += Time.deltaTime;
        //    if (timer >= 3.0f)
        //    {
        //        check = false;
                
        //    }
        //}
	}
    public void ChangeQAType(int selectAnswerNum)
    {
        int nextQANum = m_DicQAType[current_QANumber].GetNextNumber(selectAnswerNum); // 다음 Q넘버 가져옴 
        if (current_QANumber == 0)
        {
            m_state = STATE.shop;
            if (selectAnswerNum == 2)
            {
                m_state = STATE.not;
            }
        }
        else
        {
            m_state = STATE.attack;
        }
        if (true == m_DicQAType.ContainsKey(nextQANum))
        {
            current_QANumber = nextQANum;
            question_text.text = m_DicQAType[current_QANumber].GetQuestion(); //질문 셋팅
            if (nextQANum <= 30 && nextQANum >= 0)
            {
                select1_text.text = m_DicQAType[current_QANumber].GetAnswer(0); // 답변 셋팅
                select2_text.text = m_DicQAType[current_QANumber].GetAnswer(1); // 답변 셋팅
                select3_text.text = m_DicQAType[current_QANumber].GetAnswer(2); // 답변 셋팅
            }
            else if (nextQANum > 30)
            {
                select1_text.parent.gameObject.SetActive(false);
                select2_text.parent.gameObject.SetActive(false);
                select3_text.parent.gameObject.SetActive(false);
                if (m_state == STATE.shop)
                {    
                    item_back.gameObject.SetActive(true);
                    item_sp.gameObject.SetActive(true);
                    item_sp.spriteName = select_itemName[selectAnswerNum];
                    item_label.text = ItemManager.Instance.GetItem(select_nums[selectAnswerNum]).INFO;
                    srt_inven.AddItem(select_nums[selectAnswerNum]);
                    StartCoroutine("Go_Stage");
                }
                else if (m_state == STATE.attack)
                {
                    item_back.gameObject.SetActive(false);
                    item_sp.gameObject.SetActive(false);
                    StartCoroutine("Go_Attack");
                }
                else if (m_state == STATE.not)
                {
                    item_back.gameObject.SetActive(false);
                    item_sp.gameObject.SetActive(false);
                    StartCoroutine("Go_Stage");
                }
                for (int i = 0; i < select_nums.Length; ++i)
                {
                    Debug.Log("select_num = "+select_nums[i]);
                    select_nums[i] = 0;
                }

            }
        }
        else if (0 > nextQANum)
        {
            //-값이 들어가면 씬이 변경되는 부분 추가.
        }
    }
    IEnumerator Go_Stage()
    {
        yield return new WaitForSeconds(3.0f);
        robbyUI.transform.FindChild("Anchor").gameObject.SetActive(true);
        Application.LoadLevel(1);
    }
    IEnumerator Go_Attack()
    {
        yield return new WaitForSeconds(3.0f);
        //robbyUI.transform.FindChild("Anchor").gameObject.SetActive(true);
        Application.LoadLevel(3);
    }
    private void Init_Question()
    {
        //씬 넘어 갈때는 넥스트 번호를 0보다 작은 값으로 설정해 놓는다.
        // -1 : 전투, -2 : 협상, -3 : 이벤트?

        QAType a = new QAType(0, "아~아~ 어서오슈! 오늘 좋은 상품이 많아요~"); // 질문의고유값 및 질문
        a.SetAnser(0, 31, "저렴한 RandomBox (1000G) "); //답변 번호, 다음 질문 고유값, 답변내용
        a.SetAnser(1, 32, "다이아몬드가 박힌 비싼 RandomBox (5000G) ");
        a.SetAnser(2, 33, "오늘은 살 게 별로 없네요.");
        m_DicQAType.Add(0, a); //0번째에 등록.

        QAType a1 = new QAType(31, ItemManager.Instance.GetItem(select_nums[0]).ITEMNAME + " 을/를 구매했습니다");
        select_itemName[0] = ItemManager.Instance.GetItem(select_nums[0]).NAME;
        m_DicQAType.Add(31, a1);
      
        QAType a2 = new QAType(32, ItemManager.Instance.GetItem(select_nums[1]).ITEMNAME + " 을/를 구매했습니다");
        select_itemName[1] = ItemManager.Instance.GetItem(select_nums[1]).NAME;
        m_DicQAType.Add(32, a2);

        QAType a3 = new QAType(33, "상점을 나왔습니다");
        item_back.gameObject.SetActive(false);
        item_sp.gameObject.SetActive(false);
        m_DicQAType.Add(33, a3);

        //====================================================================================================================

        QAType b = new QAType(1, "젊은이.. 자네의 좋은 동료를 나에게 주지 않겠는가");
        b.SetAnser(0, 34, "노인이 불쌍하다...나에게 있는것보다야 좋겠지");
        b.SetAnser(1, 35, "내 소중한 동료를 줄 수는 없다!");
        b.SetAnser(2, 36, "왜 나한테 달라는거냐며 비아냥 댄다");
        m_DicQAType.Add(1, b);

        QAType b1 = new QAType(34, "필요없어! 싸움이다!");
        m_DicQAType.Add(34, b1);

        QAType b2 = new QAType(35, "너의 동료를 빼앗아라도 가겠다!");
        m_DicQAType.Add(35, b2);

        QAType b3 = new QAType(36, "예끼, 버르장머리 없는 녀석! 혼쭐을 내주마! ");
        m_DicQAType.Add(36, b3);

        //==================================================================================================


        QAType c = new QAType(2, "(질문1)싸움이다!");
        c.SetAnser(0, -1, "(답변1)싸운다");
        c.SetAnser(2, -1, "(답변3)다시 싸운다");
        c.SetAnser(1, -1, "(답변2)또 싸운다");
        m_DicQAType.Add(2, c);

        QAType d = new QAType(3, "(질문1)동료를 데려간다고 한다");
        d.SetAnser(1, 3, "(답변2)그랭");
        d.SetAnser(0, 2, "(답변1)꺼져");
        d.SetAnser(2, 4, "(답변3)죽엇");
        m_DicQAType.Add(3, d);


        //====================들고오기
        if(true == m_DicQAType.ContainsKey(0))
        {
            question_text.text = m_DicQAType[question_rend].GetQuestion(); //질문 셋팅
            select1_text.text = m_DicQAType[question_rend].GetAnswer(0); // 답변 셋팅
            select2_text.text = m_DicQAType[question_rend].GetAnswer(1); // 답변 셋팅
            select3_text.text = m_DicQAType[question_rend].GetAnswer(2); // 답변 셋팅

            current_QANumber = question_rend;
        }
    }
    
}
