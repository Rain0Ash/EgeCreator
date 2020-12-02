// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NetExtender.Apps;
using NetExtender.Apps.Data;
using NetExtender.Apps.Data.Common;
using NetExtender.Apps.Data.Interfaces;
using NetExtender.Apps.Domains;
using NetExtender.GUI;
using NetExtender.Network.IPC.Messaging;
using EgeCreator.Localizations;

namespace EgeCreator.Model.Options
{
    public static class Globals
    {
        public const String ProjectName = "Ege Creator";
        public const String ProjectShortName = "EgeCreator";
        public const Int32 MajorVersion = 1;
        public const Int32 MinorVersion = 0;
        public const Int32 PatchVersion = 0;

        public static ProgramLocalization Localization { get; private set; }

        public static void Initialize(GUIType gui)
        {
            AppVersion version = new AppVersion(MajorVersion);
            IIPCAppData data = new IPCAppData(ProjectName, ProjectShortName, version, AppStatus.NotFunctional, AppBranch.Master, TinyMessageBus.Fake);
            
            Domain.Create(data).Initialize<App>(gui);

            Localization = new ProgramLocalization(Settings.LanguageCode.GetValue());
        }
    }
}