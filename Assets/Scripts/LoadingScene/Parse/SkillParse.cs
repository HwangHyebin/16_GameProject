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
        stringReader.Read();
        XmlNodeList xmlNodeList     = null;
        XmlDocument xmlDoc          = new XmlDocument();


        xmlDoc.LoadXml(stringReader.ReadToEnd());
      
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
                        magician.Name = "Magician";
                        magician.TAG = "Summons";
                        magician.Info = "마법사";
                        Data.characters.Add(magician);
                    }
                    else if (child.Name == "Pracy")
                    {
                        CharacterInformation pracy      = new CharacterInformation();
                        Set_Status(child, pracy);
                        pracy.Name = "Pracy";
                        pracy.TAG = "Summons";
                        pracy.Info = "해적";
                        Data.characters.Add(pracy);
                    }
                    else if (child.Name == "Archer")
                    {
                        CharacterInformation archer     = new CharacterInformation();
                        Set_Status(child, archer);
                        archer.Name = "Archer";
                        archer.TAG = "Summons";
                        archer.Info = "궁수";
                        Data.characters.Add(archer);
                    }
                    else if (child.Name == "Player")
                    {
                        CharacterInformation player = new CharacterInformation();
                        Set_Status(child, player);
                        player.Name = "Player";
                        player.Gold = int.Parse(child.Attributes.GetNamedItem("gold").Value);
                        player.StartHP = int.Parse(child.Attributes.GetNamedItem("hp").Value);
                        Data.characters.Add(player);
                    }
                    else // item도 함께 parse.
                    {
                        Item_Info item = new Item_Info();
                        switch (child.Name)
                        {
                            case "Weapon":
                                item.TAG = "Weapon";
                                break;
                            case "Armor":
                                item.TAG = "Armor";
                                break;
                            case "Gold" :
                                item.TAG = "Gold";
                                break;
                            //case "serve":
                            //    item.TAG = "Serve";
                            //    break;
                            case "Food":
                                item.TAG = "Food";
                                break;
                        }
                        Set_ItemStatus(child, item);
                        {
                            if (Data.m_dicData.ContainsKey(item.ID))
                            {
                                return;
                            }
                            Data.m_dicData.Add(item.ID, item);
                        }
                        Data.parseCount = 1;
                    }
                }
            }
        }
    }
    
    private void Set_Status(XmlNode _child, CharacterInformation _info)
    {
        _info.Level         = int.Parse(_child.Attributes.GetNamedItem("level").Value);
        _info.HP            = int.Parse(_child.Attributes.GetNamedItem("hp").Value);
        _info.Power         = int.Parse(_child.Attributes.GetNamedItem("attack").Value);
        _info.Defence       = int.Parse(_child.Attributes.GetNamedItem("defcens").Value);
        _info.RemoveTime    = float.Parse(_child.Attributes.GetNamedItem("delete_time").Value);
        _info.CoolTime      = float.Parse(_child.Attributes.GetNamedItem("waitingtime").Value);
    }
    private void Set_ItemStatus(XmlNode _child, Item_Info _item)
    {
        _item.ID            = int.Parse(_child.Attributes.GetNamedItem("id").Value);
        _item.NAME          = _child.Attributes.GetNamedItem("name").Value;
        _item.LV            = int.Parse(_child.Attributes.GetNamedItem("level").Value);
        _item.MIN           = float.Parse(_child.Attributes.GetNamedItem("Min").Value);
        _item.MAX           = float.Parse(_child.Attributes.GetNamedItem("Max").Value);
        _item.INFO          = (_child.Attributes.GetNamedItem("info").Value).ToString();
        _item.ITEMNAME      = _child.Attributes.GetNamedItem("itemname").Value;
    }
}