using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System;

public class ItemParse : MonoBehaviour 
{
    string m_strName = "equipment.xml"; // 파싱 할 xml 파일명

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
        StringReader stringReader = new StringReader(_strSource);
        stringReader.Read();    // BOM 제거 한 데이터로 파싱해요.
        XmlNodeList xmlNodeList = null;
        XmlDocument xmlDoc = new XmlDocument();
        try
        {
            // XML 로드하고.
            xmlDoc.LoadXml(stringReader.ReadToEnd());
        }
        catch (Exception e)
        {
            xmlDoc.LoadXml(_strSource);
        }
        //xmlDoc.LoadXml(stringReader.ReadToEnd());   // XML 로드하고.
        xmlNodeList = xmlDoc.SelectNodes("Weapons");  // 최 상위 노드 선택.

        foreach (XmlNode node in xmlNodeList)
        {
            if (node.Name.Equals("Weapons") && node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes) //skill의 child
                {
                    Item_Info item  = new Item_Info();
                    item.ID         = int.Parse(child.Attributes.GetNamedItem("id").Value);
                    item.NAME       = child.Attributes.GetNamedItem("name").Value;
                    item.LV         = int.Parse(child.Attributes.GetNamedItem("level").Value);
                    item.MIN        = float.Parse(child.Attributes.GetNamedItem("Min").Value);
                    item.MIN        = float.Parse(child.Attributes.GetNamedItem("Max").Value);
                    item.INFO       = child.Attributes.GetNamedItem("info").Value;

                    // 다 만들어 졌다면 이제 매니저에 넣어줍시다.
                    ItemManager.Instance.AddItem(item);
                }
            }
        }
    }
}
