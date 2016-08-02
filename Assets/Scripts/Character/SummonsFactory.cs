using UnityEngine;
using System.Collections;

public class SummonsFactory :MonoBehaviour
{
    public  GameObject[]    skill_prefabs;
    private Player          srt_player;
    private Transform       behind_spwanPoint;
    private Transform       center_spwanPoint;

    public SummonsBase CreateSkillCharacter(string _type, ref SummonsBase _base)
    {
        if (behind_spwanPoint == null || center_spwanPoint == null)
        {
            srt_player = GameObject.FindObjectOfType<Player>();
            behind_spwanPoint = srt_player.transform.FindChild("SpwanPoint_Behind");
            center_spwanPoint = srt_player.transform.FindChild("SpwanPoint_Center");
        }
        switch (_type)
        {
                //대상 , 레벨, hp, 공격력, 방어력, 없어지는시간 , 쿨타임
            case "Archer":
                GameObject archer = Instantiate(skill_prefabs[0], behind_spwanPoint.transform.position, Quaternion.LookRotation(srt_player.transform.forward)) as GameObject;
                _base = archer.GetComponent<Archer>();
                 _base.Set_Status(ref _base, 1, 50.0f ,80.0f ,1.0f ,5.0f ,5.0f);//status 받아와서 변경해주기
                return _base;
            case "Magician":
                GameObject magician = Instantiate(skill_prefabs[1], behind_spwanPoint.transform.position, Quaternion.LookRotation(srt_player.transform.forward)) as GameObject;
                _base = magician.GetComponent<Magician>();
                _base.Set_Status(ref _base, 1, 100.0f ,10.0f ,1.0f ,5.0f ,10.0f);//status 받아와서 변경해주기
                return _base;
            case "Pirate":
                GameObject pirate = Instantiate(skill_prefabs[2], behind_spwanPoint.transform.position, Quaternion.LookRotation(srt_player.transform.forward)) as GameObject;
                _base = pirate.GetComponent<Pirate>();
                 _base.Set_Status(ref _base, 1, 150.0f ,20.0f ,1.0f ,3.0f ,6.0f);//status 받아와서 변경해주기
                return _base;
            case "Shield":
                GameObject shield = Instantiate(skill_prefabs[3], center_spwanPoint.transform.position, Quaternion.identity) as GameObject;
                _base = shield.GetComponent<Shield>();
                 _base.Set_Status(ref _base, 1, 0.0f ,0.0f ,0.0f ,3.0f ,10.0f);//status 받아와서 변경해주기
                return _base;
        }
        return null;
    }
}
