using UnityEngine;
using System.Collections;

public class Set_PlayerInfo : MonoBehaviour 
{
    public CharacterInformation     player = new CharacterInformation();

    public CharacterInformation Get_Player()
    {
        foreach (CharacterInformation node in DataManager.Instance.character_list)
        {
            if (node.Name == "Player")
            {
                player = node;
            }
        }
        return player;
    }
}
