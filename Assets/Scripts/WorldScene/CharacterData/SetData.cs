using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetData : MonoBehaviour 
{
    public CharacterInformation player      = new CharacterInformation();
    public CharacterInformation magician    = new CharacterInformation();
    public CharacterInformation pirate      = new CharacterInformation();
    public CharacterInformation archer      = new CharacterInformation();

    private void Awake()
    {
        SetInfomation();
    }
    private void SetInfomation()
    {
        magician    = Data.characters[0];
        pirate      = Data.characters[1];
        archer      = Data.characters[2];
        player      = Data.characters[3];
    }
}
