using UnityEngine;
using System.Collections;

public abstract class PlayerState 
{
    public virtual void Enter(Player _player) {}
    public virtual void Execute(Player _player){ }
    public virtual void Exit(Player _player){}

    private string str_entity_name;
    protected void Set_Name(string str) { str_entity_name = str; }
    protected string Get_Name() { return str_entity_name; }
    public virtual void Clear(){}
}
