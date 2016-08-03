using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager
{
    public List<CharacterInformation> character_list = new List<CharacterInformation>();
    private static DataManager instance              = null;

    public static DataManager Instance
    {
        get
        {
            if(instance == null)
                instance = new DataManager();
            return instance;
        }
    }
}
