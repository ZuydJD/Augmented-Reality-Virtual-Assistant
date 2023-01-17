using Microsoft.CognitiveServices.Speech;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TTSManager : Singleton<TTSManager>
{
    public SpeechConfig config;
    public SpeechSynthesizer synthesizer;
    public override void Awake()
    {
        base.Awake();
        config = SpeechConfig.FromSubscription("8156745855a94d0294fe9da21bf5ba9d", "westeurope");

        config.SpeechSynthesisVoiceName = "nl-NL-MaartenNeural";
        synthesizer = new SpeechSynthesizer(config);
    }

    public async Task synthesizeAudioAsync(string text)
    {
        await synthesizer.SpeakTextAsync(text);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
