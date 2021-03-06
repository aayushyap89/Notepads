using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace QuickPad.Mvvm.Models
{
    public interface IDocumentModel
    {
        bool CanCopy { get; }

        bool CanPaste { get; }

        bool CanRedo { get; }

        bool CanUndo { get; }

        /// <summary>Gets the text in the active story (document).</summary>
        /// <param name="options">The text retrieval options.</param>
        /// <param name="value">The text in the active story.</param>
        Task<string> GetTextAsync([In] QuickPadTextGetOptions options);

        string GetText([In] QuickPadTextGetOptions options);

        /// <summary>Reverses the most recent undo operation.</summary>
        void Redo();

        /// <summary>Sets the text of the document.</summary>
        /// <param name="options">Options controlling how the text is inserted into the document.</param>
        /// <param name="value">The new text.</param>
        void SetText([In] QuickPadTextSetOptions options, [In] string value);

        /// <summary>Undoes the most recent undo group.</summary>
        void Undo();
    }
}