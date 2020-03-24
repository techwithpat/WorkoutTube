using Autofac;
using WorkoutTube.Services;
using WorkoutTube.ViewModels;
using WorkoutTube.Views;
using Xamarin.Forms;

namespace WorkoutTube
{
    public partial class App : Application
    {
        public static IContainer Container { get; set; }

        public App()
        {
            InitializeComponent();
            RegisterDependencies();
            SetMainPage();
        }

        private void SetMainPage() => MainPage = new HomePage();

        public void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<VideoService>().As<IVideoService>().SingleInstance();
            builder.RegisterType<AppConfiguration>().As<IAppConfiguration>().SingleInstance();
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<YoutubeLauncherService>().As<IYoutubeLauncherService>().SingleInstance();
            builder.RegisterType<HomePageViewModel>();

            Container = builder.Build();
        }
    }
}
