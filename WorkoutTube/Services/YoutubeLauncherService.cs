using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WorkoutTube.Services
{
    public class YoutubeLauncherService : IYoutubeLauncherService
    {
        public Task OpenAsync(string videoId)
            => Launcher.OpenAsync($"https://www.youtube.com/watch?v={videoId}");
    }
}
