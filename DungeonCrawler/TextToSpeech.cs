using System.Speech.Synthesis;
using System;

namespace DungeonCrawler;

public static class TextToSpeech
{
    private static SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
    
    public static void Speak(string str)
    {
        _synthesizer.Volume = 100;
        _synthesizer.Rate = 2;
        
        _synthesizer.SpeakAsync(str);
    }
}