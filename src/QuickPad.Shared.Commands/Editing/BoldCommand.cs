using QuickPad.Mvvm.ViewModels;
using System.Threading.Tasks;

namespace QuickPad.Mvvm.Commands.Editing
{
    public class BoldCommand<TStorageFile, TStream> : SimpleCommand<DocumentViewModel<TStorageFile, TStream>>
        where TStream : class
    {
        public BoldCommand()
        {
            Executioner = viewModel =>
            {
                viewModel.Document.BeginUndoGroup();
                viewModel.Document.SelBold = !viewModel.Document.SelBold;
                viewModel.Document.EndUndoGroup();

                viewModel.OnPropertyChanged(nameof(viewModel.Text));

                return Task.CompletedTask;
            };
        }
    }
}