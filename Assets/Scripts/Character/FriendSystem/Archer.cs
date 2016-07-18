using UnityEngine;
using System.Collections;

public class Archer : CharacterBase
{
    public float startTime;
    public float nextTime;
    public float delay;

    public sealed override void init()
    {
        startTime = Time.time;
    }
    public sealed override void update()
    {
        nextTime = startTime + delay;
        
    }
    public sealed override void clean()
    {
    }
}
