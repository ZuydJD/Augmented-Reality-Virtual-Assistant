using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyPlay_N_Node : DecoratorNode
{
    public int MaxTimesPlayed = 1;

    int TimesHasPlayed = 0;
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {
        TimesHasPlayed++;
    }

    protected override State OnUpdate()
    {

        if (TimesHasPlayed < MaxTimesPlayed)
        {
            State childState = child.Update();
            return childState;
        }

        return State.Success;
    }
}
