namespace WorkoutTube
{
    public interface IAppConfiguration
    {
        string GoogleApiBaseUrl { get; }
        string YoutubeApiKey { get; }
        string VideosQuery { get; }
    }
}