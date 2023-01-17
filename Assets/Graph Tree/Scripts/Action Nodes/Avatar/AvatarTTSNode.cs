using Microsoft.CognitiveServices.Speech;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AvatarTTSNode : ActionNode
{
    public string avatarName = "";
    public string tekst = "";
    public bool waitToFinish = true;

    Avatar avatar;
    private AudioClip audioClip;
    private bool isTalking = true;

    protected override void OnStart()
    {
        
        
        AvatarManager.Instance.currentSpawnedAvatars.TryGetValue(avatarName, out avatar);
        isTalking = true;
        if (avatar)
        {
            //avatar.onTalkComplete.RemoveListener(FinishedTalking);
            //avatar.onTalkComplete.AddListener(FinishedTalking);
            //avatar.Talk(audioClip);

            Debug.Log("Start synth audio");

            SynthesizeAudioAsync(tekst);

            Debug.Log("Finished synth audio");

        }

       
    }

    protected override void OnStop()
    {
        //avatar.onTalkComplete.RemoveListener(FinishedTalking);
    }

    public void FinishedTalking()
    {
        isTalking = false;
    }

    protected override State OnUpdate()
    {
        if (avatar)
        {

            if (isTalking)
            {
                return State.Running;
            }
            else
            {
                return State.Success;
            }
        }
        else
        {
            return State.Failure;
        }
    }

     async void SynthesizeAudioAsync(string inputText)
    {
        
        Debug.Log("Start Speaking audio");

        await TTSManager.Instance.synthesizeAudioAsync(inputText);

        Debug.Log("Stop Speaking audio");

        isTalking = false;

    }
}

