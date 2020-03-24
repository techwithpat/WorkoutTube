using System.Threading.Tasks;

namespace WorkoutTube.Services
{
    public interface IDialogService
    {
        Task Alert(string message);
    }
}
