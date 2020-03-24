using Xamarin.Forms;
using System.Threading.Tasks;

namespace WorkoutTube.Services
{
    public class DialogService:IDialogService
    {
        public Task Alert(string message)
            => Application.Current.MainPage.DisplayAlert("Alert", message, "OK");
    }
}