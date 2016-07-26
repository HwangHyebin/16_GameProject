using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AttackManager: MonoBehaviour 
{
    public static List<Actor> Object_list = new List<Actor>(); //전체 오브젝트를 알고 있는 리스트
    private SkillManager srt_skillManager;
    
    //public static List<string> attack_list = new List<string>(); //sender와 
    private static AttackManager instance;
    public static AttackManager Instance
    {
        get
        {
            if (instance == null)
                instance = new AttackManager();
            return instance;
        }
    }
    public void AttackHandling(string _sender, string _reicever)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add(_sender, _reicever);

        if (_sender != null)
        {
            srt_skillManager = GameObject.FindObjectOfType<SkillManager>();
            if (_sender == "Enemy")
            {
                if (srt_skillManager.priority_list != null)
                {
                    SummonsBase _base = srt_skillManager.priority_list[0].Value.GetComponentInChildren<SummonsBase>();
                    switch (_reicever)
                    {
                        case "Magician":
                            _base.GetComponentInChildren<Magician>();
                            _base.SendMessage("Magician_Attacked", _sender);
                            break;
                        case "Archer":
                            _base.GetComponentInChildren<Archer>();
                            _base.SendMessage("Archer_Attacked", _sender);
                            break;
                        case "Pirate":
                            _base.GetComponentInChildren<Pirate>();
                            _base.SendMessage("Pirate_Attacked", _sender);
                            break;
                    }
                }
                else
                {
                    CharacterBase _base = gameObject.GetComponentInChildren<Player>();
                    _base.SendMessage("Player_Attacked", _sender);
                }
            }
            else if (_sender == "Player" || _sender == "Magician" ||
                        _sender == "Archer" || _sender == "Pirate")
            {
                CharacterBase _base = GameObject.FindObjectOfType<CharacterBase>();
                _base.GetComponent<Enemy>();
                _base.SendMessage("Enemy_Attacked", _sender);
            }
        }
    }

	private void Start () 
    {
        
	}
	private void Update () 
    {
       
	}
}
