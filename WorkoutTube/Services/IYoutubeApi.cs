using System.Threading.Tasks;
using Refit;
using WorkoutTube.Models;

namespace WorkoutTube.Services
{
    public interface IYoutubeApi
    {
        [Get("/youtube/v3/search?part=snippet&maxResults=15&q={query}&type=video&key={key}")]
        Task<YoutubeDto> GetVideos(string query, string key);
    }
}
