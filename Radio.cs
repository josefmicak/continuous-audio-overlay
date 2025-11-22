namespace ContinuousAudioOverlay
{
    public class Radio
    {
        public string RadioName { get; set; }
        public string RadioURL { get; set; }

        public Radio(string radioName, string radioUrl)
        {
            RadioName = radioName;
            RadioURL = radioUrl;
        }
    }
}
