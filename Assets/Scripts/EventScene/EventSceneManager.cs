using UnityEngine;
using System.Collections.Generic;

public class EventSceneManager : MonoBehaviour 
{
    public UILabel question_text;
    public UILabel select1_text;
    public UILabel select2_text;
    public UILabel select3_text;

    private int current_QANumber;
    
    Dictionary<int, QAType> m_DicQAType = new Dictionary<int, QAType>();

	private void Start () 
    {
        Init_Question();
	}
	
	private void Update () 
    {
	
	}
    private void Init_Question()
    {

        //씬 넘어 갈때는 넥스트 번호를 0보다 작은 값으로 설정해 놓는다.
        // -1 : 전투, -2 : 협상, -3 : 이벤트?

        QAType a = new QAType(0, "(질문1)동료를 데려간다고 한다"); // 질문의고유값 및 질문
        a.SetAnser(0, 2, "(답변1)꺼져"); //답변 번호, 다음 질문 고유값, 답변내용
        a.SetAnser(1, 1, "(답변2)그랭");
        a.SetAnser(2, 2, "(답변3)죽엇");
        m_DicQAType.Add(0, a); //0번째에 등록.

        QAType b = new QAType(1, "(질문1)잘가, 즐거웠어라고 말을 건넨다");
        b.SetAnser(0, 2, "(답변1)말을 건네본다");
        b.SetAnser(1, 3, "(답변2)죽은자는 말이 없는것");
        b.SetAnser(2, 3, "(답변3)미안해 팔아먹어서..");
        m_DicQAType.Add(1, b);

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
            question_text.text = m_DicQAType[0].GetQuestion(); //질문 셋팅
            select1_text.text = m_DicQAType[0].GetAnswer(0); // 답변 셋팅
            select2_text.text = m_DicQAType[0].GetAnswer(1); // 답변 셋팅
            select3_text.text = m_DicQAType[0].GetAnswer(2); // 답변 셋팅

            current_QANumber = 0;
        }
    }
    public void ChangeQAType(int selectAnswerNum)
    {
        int nextQANum = m_DicQAType[current_QANumber].GetNextNumber(selectAnswerNum); // 다음 Q넘버 가져옴  
        if (true == m_DicQAType.ContainsKey(nextQANum))
        {
            current_QANumber = nextQANum;
            question_text.text = m_DicQAType[current_QANumber].GetQuestion(); //질문 셋팅
            select1_text.text = m_DicQAType[current_QANumber].GetAnswer(0); // 답변 셋팅
            select2_text.text = m_DicQAType[current_QANumber].GetAnswer(1); // 답변 셋팅
            select3_text.text = m_DicQAType[current_QANumber].GetAnswer(2); // 답변 셋팅
        }
        else if(0 > nextQANum)
        {
            //-값이 들어가면 씬이 변경되는 부분 추가.
        }
        
    }
}
