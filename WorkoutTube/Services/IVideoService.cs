using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutTube.Models;

namespace WorkoutTube.Services
{
    public interface IVideoService
    {
        Task<IEnumerable<VideoItem>> GetVideoItems();
    }
}