using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System;

public class SkillParse : MonoBehaviour
{
    string m_strName = "Skills.xml"; // 파싱 할 xml 파일명

    private void Awake()
    {
        StartCoroutine(Process());
    }
    IEnumerator Process()
    {
        string strPath = string.Empty;
        // 플랫폼 별로 다르게!!
#if ( UNITY_EDITOR || UNITY_STANDALONE_WIN )
        strPath += ("file:///");
        strPath += (Application.streamingAssetsPath + "/" + m_strName);
#elif UNITY_ANDROID
        strPath =  "jar:file://" + Application.dataPath + "!/assets/" + m_strName;
#endif

        WWW www = new WWW(strPath);
        yield return www;
        //Debug.Log("Read Content : " + www.text);
        Interpret(www.text);
    }
    private void Interpret(string _strSource)
    {
        StringReader stringReader   = new StringReader(_strSource);
        XmlNodeList xmlNodeList     = null;
        XmlDocument xmlDoc          = new XmlDocument();

        xmlDoc.LoadXml(stringReader.ReadToEnd());   // XML 로드하고.
        xmlNodeList = xmlDoc.SelectNodes("Skill");  // 최 상위 노드 선택.

        foreach (XmlNode node in xmlNodeList)
        {
            if (node.Name.Equals("Skill") && node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes) //skill의 child
                {
                    if(child.Name == "Magic")
                    {
                        CharacterInformation magician   = new CharacterInformation();
                        Set_Status(child,magician);
                        DataManager.Instance.character_list.Add(magician);
                    }
                    else if (child.Name == "Pracy")
                    {
                        CharacterInformation pracy      = new CharacterInformation();
                        Set_Status(child, pracy);
                        DataManager.Instance.character_list.Add(pracy);
                    }
                    else if (child.Name == "Archer")
                    {
                        CharacterInformation archer     = new CharacterInformation();
                        Set_Status(child, archer);
                        DataManager.Instance.character_list.Add(archer);
                    }
                    else if (child.Name == "Player")
                    {
                        CharacterInformation player     = new CharacterInformation();
                        Set_Status(child, player);
                        //player.Gold = int.Parse(child.Attributes.GetNamedItem("gold").Value);
                        DataManager.Instance.character_list.Add(player);
                    }
                }
            }
        }
    }
    private void Set_Status(XmlNode _child, CharacterInformation _info)
    {
        _info.Level         = int.Parse(_child.Attributes.GetNamedItem("level").Value);
        _info.HP            = float.Parse(_child.Attributes.GetNamedItem("hp").Value);
        _info.Power         = float.Parse(_child.Attributes.GetNamedItem("attack").Value);
        _info.Defence       = float.Parse(_child.Attributes.GetNamedItem("defcens").Value);
        _info.RemoveTime    = float.Parse(_child.Attributes.GetNamedItem("delete_time").Value);
        _info.CoolTime      = float.Parse(_child.Attributes.GetNamedItem("waitingtime").Value);
    }
}