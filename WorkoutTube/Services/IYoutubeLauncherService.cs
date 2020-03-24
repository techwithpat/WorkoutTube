using System.Threading.Tasks;

namespace WorkoutTube.Services
{
    public interface IYoutubeLauncherService
    {
        Task OpenAsync(string videoId);
    }
}