// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NetExtender.Apps.Domains.GUIViews.Winforms;
using NetExtender.Utils.IO;
using EgeCreator.View.Winforms.Forms;

namespace EgeCreator.ModelView.Winforms
{
    public class WinFormsView : AppWinFormsView
    {
        protected override void Initialize()
        {
            ConsoleUtils.IsConsoleVisible = false;
        }

        protected override void Run()
        {
            Run<MainForm>();
        }
    }
}