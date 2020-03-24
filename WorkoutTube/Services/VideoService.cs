using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using WorkoutTube.Models;

namespace WorkoutTube.Services
{
    public class VideoService : IVideoService
    {
        private readonly IAppConfiguration appConfiguration;

        public VideoService(IAppConfiguration appConfiguration)
            => this.appConfiguration = appConfiguration;

        public async Task<IEnumerable<VideoItem>> GetVideoItems()
        {
            var result = await RestService.For<IYoutubeApi>(appConfiguration.GoogleApiBaseUrl)
                .GetVideos(appConfiguration.VideosQuery, appConfiguration.YoutubeApiKey);

            return result.Items;
        }
    }
}
