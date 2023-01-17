using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyPlayOnceNode : DecoratorNode
{
    bool HasPlayed = false;
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        HasPlayed = true;
    }

    protected override State OnUpdate()
    {
        
        if (HasPlayed == false)
        {
            State childState = child.Update();
            return childState;
        }

        return State.Success;
    }

    
}
