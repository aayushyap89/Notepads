using QuickPad.Mvvm.ViewModels;
using System.Threading.Tasks;

namespace QuickPad.Mvvm.Commands.Editing
{
    public class ZoomInCommand<TStorageFile, TStream> : SimpleCommand<DocumentViewModel<TStorageFile, TStream>>
        where TStream : class
    {
        public ZoomInCommand()
        {
            Executioner = viewModel =>
            {
                if (viewModel.ScaleValue <= 4)
                {
                    viewModel.ScaleValue += 0.1f;
                }

                return Task.CompletedTask;
            };
        }
    }
}