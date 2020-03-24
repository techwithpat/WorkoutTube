using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using WorkoutTube.Models;
using WorkoutTube.Services;
using Xamarin.Forms;

namespace WorkoutTube.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly IVideoService _videoService;
        private readonly IDialogService _dialogService;
        private readonly IYoutubeLauncherService _youtubeLauncherService;
        private VideoItem selectedVideo;

        public HomePageViewModel(
            IVideoService videoService,
            IDialogService dialogService,
            IYoutubeLauncherService youtubeLauncherService)
        {
            _videoService = videoService;
            _dialogService = dialogService;
            _youtubeLauncherService = youtubeLauncherService;

            Videos = new ObservableRangeCollection<VideoItem>();
            OpenVideoCommand = new Command<VideoItem>(async v => await OnOpenVideo(v));
        }

        public async Task Initialize()
        {
            try
            {
                Videos.ReplaceRange(await _videoService.GetVideoItems());
            }
            catch (Exception ex)
            {
                await _dialogService.Alert(ex.Message);
            }
        }

        private async Task OnOpenVideo(VideoItem video)
        {
            try
            {
                await _youtubeLauncherService.OpenAsync(video.Id.VideoId);
            }
            catch (Exception ex)
            {
                await _dialogService.Alert(ex.Message);
            }            
        }

        public ObservableRangeCollection<VideoItem> Videos { get; set; }

        public VideoItem SelectedVideo
        {
            get => selectedVideo;
            set
            {
                if (SetProperty(ref selectedVideo, value))
                {
                    OpenVideoCommand.Execute(selectedVideo);
                }
            }
        }

        public ICommand OpenVideoCommand { get; set; }
    }
}
