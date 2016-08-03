using UnityEngine;
using System.Collections;

public abstract class PlayerState 
{
    public virtual void Enter(Player _player)
    { 
    }
    public virtual void Execute(Player _player)
    { 
    }
    public virtual void Exit(Player _player)
    {
    }

}
