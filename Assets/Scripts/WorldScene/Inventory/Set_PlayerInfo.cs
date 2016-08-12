using UnityEngine;
using System.Collections;

public class Set_PlayerInfo : MonoBehaviour 
{
    public  CharacterInformation        player = new CharacterInformation();
    private int                         player_startHP;
    private int                         player_currentHP;

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
    public int Get_PlayerStartHP()
    {
        player_startHP = player.HP;
        return player_startHP;
    }
    public int PlayerCurrentHP
    {
        set { player_currentHP = value; }
        get { return player_currentHP; }
    }
    //private void Update()
    //{
    //    Debug.Log("player current = "+player_currentHP);
    //}
}
