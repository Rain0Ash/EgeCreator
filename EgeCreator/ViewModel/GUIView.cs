// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NetExtender.Apps.Domains.GUIViews.Common.Interfaces;
using NetExtender.GUI;
using EgeCreator.ModelView.Winforms;

namespace EgeCreator.ViewModel
{
    public static class GUIView
    {
        public static IGUIView Factory(GUIType type)
        {
            return type switch
            {
                _ => new WinFormsView()
            };
        }
    }
}