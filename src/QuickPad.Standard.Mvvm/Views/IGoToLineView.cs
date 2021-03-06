using QuickPad.Mvvm.ViewModels;
using System.Threading.Tasks;

namespace QuickPad.Mvvm.Views
{
    public interface IGoToLineView<TStorageFile, TStream> : IDialogView
        where TStream : class
    {
        DocumentViewModel<TStorageFile, TStream> ViewModel { get; set; }

        Task<bool> ShowAsyncByTask();
    }
}