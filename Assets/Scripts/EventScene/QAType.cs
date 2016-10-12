using UnityEngine;
using System.Collections;


public class QAType
{
    private class QAData
    {
        public int m_i32NextNumber = 0;
        public string m_strAnswer = string.Empty;

        public QAData(int i32NextNumber, string strAnswer)
        {
            m_i32NextNumber = i32NextNumber;
            m_strAnswer = strAnswer;
        }
    }
    private QAData[] m_AnswerData = new QAData[3];

    private int m_i32Number = 0;
    private string m_strQuestion = string.Empty;

    
    
    public QAType(int i32Number, string strQuestion)
    {
        m_i32Number = i32Number;
        m_strQuestion = strQuestion;
    }

    public void SetAnser(int i32Index, int i32NexNumber, string strAnswer)
    {
        if (0 > i32Index || 3 <= i32Index)
            return;

        m_AnswerData[i32Index] = new QAData(i32NexNumber, strAnswer);
    }
    
    public string GetAnswer(int i32Index)
    {
        if (0 > i32Index || 3 <= i32Index)
            return string.Empty;

        if (null == m_AnswerData[i32Index])
            return string.Empty;

        return m_AnswerData[i32Index].m_strAnswer;
    }

    public int GetNextNumber(int i32Index)
    {
        if (0 > i32Index || 3 <= i32Index)
            return -1;

        if (null == m_AnswerData[i32Index])
            return -1;

        return m_AnswerData[i32Index].m_i32NextNumber;
    }
    public string GetQuestion()
    {
        return m_strQuestion;
    }
}