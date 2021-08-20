
using Android.Media;

using App1.Droid;

using Java.Lang;

using System;
using System.Linq;

using Xamarin.Forms;

using static Android.Renderscripts.Sampler;

[assembly: Dependency(typeof(ToneService))]
namespace App1.Droid
{
    public class ToneService : IToneService
    {
        private int volume = 0;
        private ToneGenerator toneGenerator;
        public ToneService()
        {
            int percantageVolume = 100;
            if (volume == 0)
            {
                percantageVolume = 100;
            }
            if (volume == 1)
            {
                percantageVolume = 75;
            }
            if (volume == 2)
            {
                percantageVolume = 50;
            }
            if (volume == 3)
            {
                percantageVolume = 0;
            }

            toneGenerator = new ToneGenerator(Stream.Dtmf, percantageVolume);
        }
        public string[] GetToneTypes()
        {
            return System.Enum.GetValues(typeof(Tone)).Cast<Tone>().Select(x => x.ToString()).ToArray();
        }
        public void StartTone(int durationInMs)
        {
            toneGenerator.StartTone(Tone.PropBeep);
        }

        public void StartTone(string toneType)
        {
            Tone toneTypeEnum = (Tone)System.Enum.Parse(typeof(Tone), toneType);
            toneGenerator.StartTone(toneTypeEnum);
        }

        public void StopTone()
        {
            toneGenerator.StopTone();
        }
    }
}