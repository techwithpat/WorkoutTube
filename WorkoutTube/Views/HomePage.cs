using Autofac;
using FFImageLoading.Forms;
using WorkoutTube.ViewModels;
using Xamarin.Forms;

namespace WorkoutTube.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            InitializeViewModel();
        }

        private void InitializeComponent()
        {
            var listVideos = new ListView
            {
                HasUnevenRows = true,
                IsPullToRefreshEnabled = true,
                SeparatorVisibility = SeparatorVisibility.None,
                Margin = new Thickness(20),
                SelectionMode = ListViewSelectionMode.Single,
                ItemTemplate = new DataTemplate(() =>
                {
                    var stackLayout = new StackLayout
                    {
                        HeightRequest = 250,
                        Margin = new Thickness(10),
                        BackgroundColor = Color.Red,
                        Orientation = StackOrientation.Vertical
                    };

                    var image = new CachedImage
                    {
                        Aspect = Aspect.AspectFill
                    };
                    image.SetBinding(CachedImage.SourceProperty, "Snippet.Thumbnails.High.Url.AbsoluteUri");
                    stackLayout.Children.Add(image);

                    var label = new Label
                    {
                        Margin = new Thickness(10, 5, 0, 5),
                        TextColor = Color.White
                    };
                    label.SetBinding(Label.TextProperty, "Snippet.Title");                   
                    stackLayout.Children.Add(label);

                    return new ViewCell {View = stackLayout };
                })
            };

            listVideos.SetBinding(ListView.SelectedItemProperty, "SelectedVideo", BindingMode.TwoWay);
            listVideos.SetBinding(ListView.ItemsSourceProperty, "Videos");

            Content = listVideos;
        }

        private async void InitializeViewModel()
        {
            using (var scope = App.Container.BeginLifetimeScope())
            {
                var viewModel = scope.Resolve<HomePageViewModel>();
                BindingContext = viewModel;
                await viewModel.Initialize();
            }
        }
    }
}

