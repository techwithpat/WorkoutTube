using Autofac.Extras.Moq;
using NUnit.Framework;
using WorkoutTube.ViewModels;
using FluentAssertions;
using Xamarin.Forms;
using WorkoutTube.Services;
using AutoFixture;
using WorkoutTube.Models;
using System.Threading.Tasks;
using System.Linq;
using Moq;

namespace WorkoutTube.UnitTests
{
    [TestFixture]
    public class HomePageViewModelTests
    {
        private Fixture _fixture;

        public HomePageViewModelTests() => _fixture = new Fixture();

        [Test]
        public void CreatingHomePageViewModel_WhenSuccessfull_VideosIsEmpty()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<HomePageViewModel>();

                viewModel.Videos.Should().BeEmpty();
            }
        }

        [Test]
        public void CreatingHomePageViewModel_WhenSuccessfull_SelectedVideoIsNull()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<HomePageViewModel>();

                viewModel.SelectedVideo.Should().BeNull();
            }
        }

        [Test]
        public void CreatingHomePageViewModel_WhenSuccessfull_InitializesOpenVideoCommand()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<HomePageViewModel>();

                viewModel.OpenVideoCommand.Should().NotBeNull();
                viewModel.OpenVideoCommand.Should().BeOfType<Command<VideoItem>>();
            }
        }

        [Test]
        public async Task InitializingHomePageViewModel_WhenSuccessfull_UpdatesVideos()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var videos = _fixture.CreateMany<VideoItem>(5);
                mock.Mock<IVideoService>().Setup(v => v.GetVideoItems()).Returns(Task.FromResult(videos));

                var viewModel = mock.Create<HomePageViewModel>();
                await viewModel.Initialize();

                viewModel.Videos.Should().NotBeEmpty();
                viewModel.Videos.Count.Should().Equals(videos.Count());
            }
        }

        [Test]
        public async Task InitializingHomePageViewModel_WhenExceptionIsRaised_CallsDialogServiceAlert()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IVideoService>().Setup(v => v.GetVideoItems()).Throws(new System.Exception("Unexpected error"));

                var viewModel = mock.Create<HomePageViewModel>();
                await viewModel.Initialize();

                mock.Mock<IDialogService>().Verify(d => d.Alert(It.IsAny<string>()));
            }
        }

        [Test]
        public void ExecutingOpenVideoCommand_WhenSuccessfull_CallsYoutubeLauncherServiceOpenAsync()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var video = _fixture.Create<VideoItem>();
                mock.Mock<IYoutubeLauncherService>().Setup(y => y.OpenAsync(video.Id.VideoId));

                var viewModel = mock.Create<HomePageViewModel>();
                viewModel.OpenVideoCommand.Execute(video);

                mock.Mock<IYoutubeLauncherService>().Verify(y => y.OpenAsync(video.Id.VideoId));
            }
        }

        [Test]
        public void ExecutingOpenVideoCommand_WhenExceptionIsRaised_CallsDialogServiceAlert()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var video = _fixture.Create<VideoItem>();
                mock.Mock<IYoutubeLauncherService>().Setup(v => v.OpenAsync(video.Id.VideoId)).Throws(new System.Exception("Unexpected error"));

                var viewModel = mock.Create<HomePageViewModel>();
                viewModel.OpenVideoCommand.Execute(video);

                mock.Mock<IDialogService>().Verify(d => d.Alert(It.IsAny<string>()));
            }
        }

    }
}
