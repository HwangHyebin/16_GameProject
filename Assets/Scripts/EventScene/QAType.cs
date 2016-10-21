using UnityEngine;
using System.Collections;


public class QAType
{
    private class QAData
    {
        public int m_nextNumber = 0;
        public string m_answer = string.Empty;

        public QAData(int _nextNumber, string _answer)
        {
            m_nextNumber = _nextNumber;
            m_answer = _answer;
        }
    }
    private QAData[] m_AnswerData = new QAData[3];

    private int m_questionNumber = 0;
    private string m_question = string.Empty;

    public QAType(int _QNumber, string _question)
    {
        m_questionNumber = _QNumber;
        m_question = _question;
    }

    public void SetAnser(int _index, int _nextNumber, string _answer)
    {
        if (0 > _index || 3 <= _index)
            return;

        m_AnswerData[_index] = new QAData(_nextNumber, _answer);
    }

    public string GetAnswer(int _index)
    {
        if (0 > _index || 3 <= _index)
            return string.Empty;

        if (null == m_AnswerData[_index])
            return string.Empty;

        return m_AnswerData[_index].m_answer;
    }

    public int GetNextNumber(int _index)
    {
        if (0 > _index || 3 <= _index)
            return -1;

        if (null == m_AnswerData[_index])
            return -1;

        return m_AnswerData[_index].m_nextNumber;
    }
    public string GetQuestion()
    {
        return m_question;
    }
}