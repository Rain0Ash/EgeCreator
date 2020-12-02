// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq;
using NetExtender.Apps.Domains;
using NetExtender.GUI;
using EgeCreator.Model.Options;
using EgeCreator.ViewModel;

namespace EgeCreator.Model
{
    public static class Initializer
    {
        public static void Initialize(String[] args)
        {
            StartGUI(args);
        }

        private static void StartGUI(String[] args)
        {
            GUIType gui = args.Any(str => str.ToLowerInvariant() == "-console") ? GUIType.Console : GUIType.WinForms;

            Globals.Initialize(gui);
            
            GUIView.Factory(gui).Start(args);
        }

        public static void Shutdown(Int32 code = 0)
        {
            Domain.Current.Shutdown(code);
        }
    }
}