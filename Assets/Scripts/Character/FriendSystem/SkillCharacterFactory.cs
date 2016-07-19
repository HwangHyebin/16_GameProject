using UnityEngine;
using System.Collections;

public class SkillCharacterFactory :MonoBehaviour
{
    public  GameObject[]    skill_prefabs;
    private Player          srt_player;
    private Transform       spwanPoint;

    public void Start()
    { 
    }
    public SkillCharacterBase CreateSkillCharacter(string _type, ref SkillCharacterBase _base)
    {
        if (spwanPoint == null)
        {
            srt_player = GameObject.FindObjectOfType<Player>();
            spwanPoint = srt_player.transform.FindChild("SpwanPoint");
        }
        switch (_type)
        {
            case "Archer":
                GameObject archer = Instantiate(skill_prefabs[0], spwanPoint.transform.position, Quaternion.LookRotation(srt_player.transform.forward)) as GameObject;
                _base = archer.GetComponent<Archer>();
                return _base;
            case "Magician":
                GameObject magician = Instantiate(skill_prefabs[1], spwanPoint.transform.position, Quaternion.LookRotation(srt_player.transform.forward)) as GameObject;
                _base = magician.GetComponent<Magician>();
                return _base;
            case "Pirate":
                GameObject pirate = Instantiate(skill_prefabs[2], spwanPoint.transform.position, Quaternion.LookRotation(srt_player.transform.forward)) as GameObject;
                _base = pirate.GetComponent<Pirate>();
                return _base;
            case "Shield":
                GameObject shield = Instantiate(skill_prefabs[3], srt_player.transform.position, Quaternion.identity) as GameObject;
                _base = shield.GetComponent<Shield>();
                return _base;
        }
        return null;
    }
}
