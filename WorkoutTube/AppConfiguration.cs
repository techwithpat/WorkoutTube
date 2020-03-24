namespace WorkoutTube
{
    public class AppConfiguration : IAppConfiguration
    {
        public string GoogleApiBaseUrl => "https://www.googleapis.com";
        public string YoutubeApiKey => ""; //Add your own API key
        public string  VideosQuery => "FULL BODY WORKOUT";
    }
}
