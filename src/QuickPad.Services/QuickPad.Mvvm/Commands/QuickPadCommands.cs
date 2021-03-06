using System.Linq;
using System.Reflection;
using QuickPad.Mvvm.Commands.Actions;
using QuickPad.Mvvm.Commands.Clipboard;
using QuickPad.Mvvm.Commands.Editing;
using QuickPad.Mvvm.ViewModels;


namespace QuickPad.Mvvm.Commands
{
    public class QuickPadCommands
    {
        public static void NotifyAll(DocumentViewModel viewModel, SettingsViewModel settings)
        {
            _commands.NotifyChanged(viewModel, settings);
        }

        private static QuickPadCommands _commands = null;

        public QuickPadCommands() { }
        public QuickPadCommands(PasteCommand pasteCommand)
        {
            _commands = this;
            PasteCommand = pasteCommand;
        }

        public SimpleCommand<DocumentViewModel> SaveCommand { get; } = new SimpleCommand<DocumentViewModel>();
        public SimpleCommand<DocumentViewModel> SaveAsCommand { get; } = new SimpleCommand<DocumentViewModel>();
        public SimpleCommand<DocumentViewModel> LoadCommand { get; } = new SimpleCommand<DocumentViewModel>();
        public SimpleCommand<DocumentViewModel> NewDocumentCommand { get; } = new SimpleCommand<DocumentViewModel>();
        public SimpleCommand<DocumentViewModel> ShareCommand { get; } = new ShareCommand();
        public SimpleCommand<DocumentViewModel> ExitCommand { get; } = new SimpleCommand<DocumentViewModel>();

        public SimpleCommand<DocumentViewModel> UndoCommand { get; } = new UndoCommand();
        public SimpleCommand<DocumentViewModel> RedoCommand { get; } = new RedoCommand();

        //clipboard
        public SimpleCommand<DocumentViewModel> CutCommand { get; } = new CutCommand();
        public SimpleCommand<DocumentViewModel> CopyCommand { get; } = new CopyCommand();
        public SimpleCommand<DocumentViewModel> PasteCommand { get; }
        public SimpleCommand<DocumentViewModel> DeleteCommand { get; } = new DeleteCommand();
        public SimpleCommand<DocumentViewModel> ContentChangedCommand { get; } = new ContentChangedCommand();

        public SimpleCommand<DocumentViewModel> BingCommand { get; } = new SearchWithBingCommand();
        public SimpleCommand<DocumentViewModel> GoogleCommand { get; } = new SearchWithGoogleCommand();

        public SimpleCommand<DocumentViewModel> EmojiCommand { get; } = new EmojiCommand();

        public SimpleCommand<DocumentViewModel> BoldCommand { get; } = new BoldCommand();
        public SimpleCommand<DocumentViewModel> ItalicsCommand { get; } = new ItalicCommand();
        public SimpleCommand<DocumentViewModel> UnderlineCommand { get; } = new UnderlineCommand();
        public SimpleCommand<DocumentViewModel> StrikeThroughCommand { get; } = new StrikeThroughCommand();
        public SimpleCommand<DocumentViewModel> BulletsCommand { get; } = new BulletsCommand();
        public SimpleCommand<DocumentViewModel> LeftAlignCommand { get; } = new LeftAlignCommand();
        public SimpleCommand<DocumentViewModel> CenterAlignCommand { get; } = new CenterAlignCommand();
        public SimpleCommand<DocumentViewModel> RightAlignCommand { get; } = new RightAlignCommand();
        public SimpleCommand<DocumentViewModel> JustifyCommand { get; } = new JustifyCommand();
        public SimpleCommand<DocumentViewModel> ColorCommand { get; } = new ColorCommand();

        public SimpleCommand<DocumentViewModel> ToggleWordWrapCommand { get; } = new ToggleWordWrapCommand(); 
        //actions
        public SimpleCommand<SettingsViewModel> FocusCommand { get; } = new FocusCommand();
        public SimpleCommand<SettingsViewModel> SettingsCommand { get; } = new ShowSettingsCommand();
        public SimpleCommand<SettingsViewModel> CompactOverlayCommand { get; } = new CompactOverlay();
        public SimpleCommand<SettingsViewModel> ShowCommandBarCommand { get; } = new ShowCommandBarCommand();
        public SimpleCommand<SettingsViewModel> ShowFontsCommand { get; } = new ShowFontsCommand();
        public SimpleCommand<SettingsViewModel> ShowMenusCommand { get; } = new ShowMenusCommand();
        public SimpleCommand<SettingsViewModel> ResetSettingsCommand { get; } = new ResetSettingsCommand();
        public SimpleCommand<SettingsViewModel> ImportSettingsCommand { get; } = new ImportSettingsCommand();
        public SimpleCommand<SettingsViewModel> ExportSettingsCommand { get; } = new ExportSettingsCommand();
        public SimpleCommand<SettingsViewModel> RateAndReviewCommand { get; } = new RateAndReviewCommand();
        public SimpleCommand<DocumentViewModel> ShowFindCommand { get; } = new ShowFindCommand();
        public SimpleCommand<DocumentViewModel> HideFindCommand { get; } = new HideFindCommand();
        public SimpleCommand<DocumentViewModel> FindNextCommand { get; } = new FindNextCommand();
        public SimpleCommand<DocumentViewModel> FindPreviousCommand { get; } = new FindPreviousCommand();
        public SimpleCommand<DocumentViewModel> ShowReplaceCommand { get; } = new ShowReplaceCommand();
        public SimpleCommand<DocumentViewModel> ReplaceNextCommand { get; } = new ReplaceNextCommand();
        public SimpleCommand<DocumentViewModel> ReplaceAllCommand { get; } = new ReplaceAllCommand();
        public SimpleCommand<DocumentViewModel> SelectAllCommand { get; } = new SelectAllCommand();
        public SimpleCommand<DocumentViewModel> InsertTimeDateCommand { get; } = new InsertTimeDateCommand();
        public SimpleCommand<DocumentViewModel> UpdateToolbarCommand { get; } = new UpdateToolbarCommand();
        public SimpleCommand<DocumentViewModel> ZoomInCommand { get; } = new ZoomInCommand();
        public SimpleCommand<DocumentViewModel> ZoomOutCommand { get; } = new ZoomOutCommand();
        public SimpleCommand<DocumentViewModel> ResetZoomCommand { get; } = new ResetZoomCommand();
        public SimpleCommand<DocumentViewModel> ShowGoToCommand { get; } = new ShowGoToCommand();
        public SimpleCommand<DocumentViewModel> GoToLineCommand { get; } = new GoToLineCommand();
        public SimpleCommand<DocumentViewModel> SuperscriptCommand { get; } = new SuperscriptCommand();
        public SimpleCommand<DocumentViewModel> SubscriptCommand { get; } = new SubscriptCommand();

        public SimpleCommand<SettingsViewModel> AcknowledgeFontSelectionChangeCommand { get; } =
            new AcknowledgeFontSelectionChangeCommand();

        public void NotifyChanged(DocumentViewModel documentViewModel, SettingsViewModel settingsViewModel)
        {
            GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(pi =>
                    pi.PropertyType == typeof(SimpleCommand<DocumentViewModel>) ||
                    pi.PropertyType == typeof(SimpleCommand<SettingsViewModel>))
                .ToList().ForEach(pi =>
                {
                    var documentCommand = pi.GetValue(this) as SimpleCommand<DocumentViewModel>;
                    documentCommand?.InvokeCanExecuteChanged(documentViewModel);

                    var settingsCommand = pi.GetValue(this) as SimpleCommand<SettingsViewModel>;
                    settingsCommand?.InvokeCanExecuteChanged(settingsViewModel);
                });
        }
    }
}