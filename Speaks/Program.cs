using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Speaks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize a new instance of the SpeechSynthesizer.
            using (var speechSynthesizer = new SpeechSynthesizer())
            {
                // Configure the audio output.
                var cultures = new PromptBuilder(
                    new CultureInfo("en-US"));
                speechSynthesizer.Rate = 3;
                speechSynthesizer.SetOutputToDefaultAudioDevice();
                speechSynthesizer.Speak(cultures);
                
                // Add a lexicon that changes the pronunciation
                speechSynthesizer.AddLexicon(
                    new Uri(@"D:\Audio\lang.pls"), "application/pls+xml");
                speechSynthesizer.SetOutputToWaveFile(
                    new Uri(@"D:\Audio\audio.mp3").AbsolutePath);
                
                // Speak a string.  
                speechSynthesizer.Speak("Peter Piper picked a peck of pickled peppers.");
                speechSynthesizer.Speak("Did Peter Piper pick a peck of pickled peppers?");
                speechSynthesizer.Speak("If Peter Piper picked a peck of pickled peppers,");
                speechSynthesizer.Speak("Wheres the peck of pickled peppers Peter Piper picked?");
            }
             
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
