using QuickPad.Mvvm.ViewModels;
using System.Threading.Tasks;

namespace QuickPad.Mvvm.Commands.Editing
{
    public class ZoomOutCommand<TStorageFile, TStream> : SimpleCommand<DocumentViewModel<TStorageFile, TStream>>
        where TStream : class
    {
        public ZoomOutCommand()
        {
            Executioner = viewModel =>
            {
                if (viewModel.ScaleValue >= 0.5)
                {
                    viewModel.ScaleValue -= 0.1f;
                }

                return Task.CompletedTask;
            };
        }
    }
}