namespace App1
{
    public interface IToneService
    {
        string[] GetToneTypes();
        void StartTone(string toneType);
        void StartTone(int durationInMs);
        void StopTone();
    }
}