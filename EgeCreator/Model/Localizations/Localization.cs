// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using EgeCreator.Model.Common;
using NetExtender.Apps.Domains;
using NetExtender.Localizations;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable NotAccessedField.Global

namespace EgeCreator.Localizations
{
    public class ProgramLocalization : Localization
    {
        public const String Https = "https://";
        public const String Developer = "Rain0Ash";
        public const String DeveloperGitHubPage = Https + "github.com/" + Developer;
        public const String ProjectGitHubPage = DeveloperGitHubPage + "/" + "EgeCreator";
        public const String Licence = "Mozilla Public License 2.0";
        public const String LicenceLink = Https + "mozilla.org/en-US/MPL/2.0";

        public CultureStrings ProjectName { get; private set; }
        public CultureStrings CriticalExceptionOccurred { get; private set; }
        public CultureStrings CriticalExceptionOccurredText { get; private set; }
        public CultureStrings CriticalExceptionOccurredRestartButton { get; private set; }
        public CultureStrings CriticalExceptionOccurredExitButton { get; private set; }
        public CultureStrings InitializeStageException { get; private set; }
        public CultureStrings InitializeExceptionOccured { get; private set; }
        public CultureStrings MainForm { get; private set; }
        public CultureStrings AboutProgramTitle { get; private set; }
        public CultureStrings AboutProgramText { get; private set; }
        public CultureStrings ProgramSuccessfullyStarted { get; private set; }
        public CultureStrings SelectFile { get; private set; }
        public CultureStrings FileSaved { get; private set; }
        public CultureStrings DefaultDownloadPathLabel { get; private set; }
        public CultureStrings DefaultDownloadNameLabel { get; private set; }
        public CultureStrings SelectFolder { get; private set; }
        public CultureStrings Settings { get; private set; }
        public CultureStrings YouSureQuestion { get; private set; }
        public CultureStrings Wait { get; private set; }
        public CultureStrings OpenGitHubPageToolTip { get; private set; }
        public CultureStrings FileDialogButtonToolTip { get; private set; }
        public CultureStrings FolderDialogButtonToolTip { get; private set; }
        public CultureStrings PathTypeChangeButtonToRelativeToolTip { get; private set; }
        public CultureStrings PathTypeChangeButtonToAbsoluteToolTip { get; private set; }
        public CultureStrings FormatHelpButtonToolTip { get; private set; }
        public CultureStrings CloseProgramQuestionTitle { get; private set; }
        public CultureStrings CloseProgramQuestionText { get; private set; }
        public CultureStrings CompletedPathTitle { get; private set; }
        public CultureStrings CompletedPathText { get; private set; }
        public CultureStrings SetValue { get; private set; }
        public CultureStrings Explorer { get; private set; }
        public CultureStrings SelectAction { get; private set; }
        public CultureStrings ViewAction { get; private set; }
        public CultureStrings CopyAction { get; private set; }
        public CultureStrings PasteAction { get; private set; }
        public CultureStrings CutAction { get; private set; }
        public CultureStrings AddAction { get; private set; }
        public CultureStrings RemoveAction { get; private set; }
        public CultureStrings ChangeAction { get; private set; }
        public CultureStrings RecursiveAction { get; private set; }
        public CultureStrings Exit { get; private set; }
        public CultureStrings OK { get; private set; }
        public CultureStrings Yes { get; private set; }
        public CultureStrings No { get; private set; }
        public CultureStrings Apply { get; private set; }
        public CultureStrings Cancel { get; private set; }
        public CultureStrings Retry { get; private set; }
        public CultureStrings Ignore { get; private set; }
        public CultureStrings Accept { get; private set; }
        public CultureStrings Close { get; private set; }
        public CultureStrings Select { get; private set; }
        public CultureStrings Perform { get; private set; }
        public CultureStrings Resume { get; private set; }
        public CultureStrings Pause { get; private set; }
        public CultureStrings Debug { get; private set; }
        public CultureStrings Action { get; private set; }
        public CultureStrings Good { get; private set; }
        public CultureStrings Warning { get; private set; }
        public CultureStrings CriticalWarning { get; private set; }
        public CultureStrings Error { get; private set; }
        public CultureStrings CriticalError { get; private set; }
        public CultureStrings FatalError { get; private set; }
        public CultureStrings UnknownError { get; private set; }
        public CultureStrings InvalidMap { get; private set; }
        public CultureStrings WriteAccessDeniedError { get; private set; }
        public CultureStrings InitializedInvalidTaskError { get; private set; }
        public CultureStrings StartedInvalidTaskError { get; private set; }
        public CultureStrings StartTest { get; private set; }
        public CultureStrings StopTest { get; private set; }
        public CultureStrings GradeMessageBox { get; private set; }
        public CultureStrings GradeLabel { get; private set; }
        public IImmutableDictionary<SubjectType, CultureStrings> Subjects { get; private set; }
        
        public ProgramLocalization(Int32 lcid)
            : base(lcid, new CultureStrings())
        {
        }

        protected override void InitializeLanguage()
        {
            String version = Domain.Current.Data.ToString();

            ProjectName = new CultureStrings(
                "USE Tester",
                "ЕГЭ Тестер");

            CriticalExceptionOccurred = new CultureStrings(
                "Crititical exception occurred!",
                "Произошло критическое исключение!",
                "Kritische Ausnahme aufgetreten!");

            CriticalExceptionOccurredText = new CultureStrings(
                $"Crititical exception occurred!{NewLine}Information about this exception:",
                $"Произошло критическое исключение!{NewLine}Информация об этом исключении:",
                $"Kritische Ausnahme ist aufgetreten!{NewLine}Informationen zu dieser Ausnahme:");

            CriticalExceptionOccurredRestartButton = new CultureStrings(
                "Restart",
                "Перезапустить",
                "Neustart");

            CriticalExceptionOccurredExitButton = new CultureStrings(
                "Exit",
                "Выйти",
                "Ausgang");

            InitializeStageException = new CultureStrings(
                "Exception on initialize stage",
                "Ошибка на стадии инициализации");

            InitializeExceptionOccured = new CultureStrings(
                "Initialize exception occured",
                "Вызвана ошибка при инициализации");

            MainForm = new CultureStrings(
                $"{ProjectName.en} {version}",
                $"{ProjectName.ru} {version}",
                $"{ProjectName.de} {version}");

            AboutProgramTitle = new CultureStrings(
                "About program",
                "О программе",
                "Über das Programm");

            AboutProgramText = new CultureStrings(
                $"<link>{ProjectGitHubPage}|{ProjectName.en}</link>{NewLine}Program version: {version}{NewLine}Developed by <link>{DeveloperGitHubPage}|{Developer}</link>{NewLine}Licence: <link>{LicenceLink}|{Licence}</link>",
                $"<link>{ProjectGitHubPage}|{ProjectName.ru}</link>{NewLine}Версия программы: {version}{NewLine}Разработано <link>{DeveloperGitHubPage}|{Developer}</link>{NewLine}Лицензия: <link>{LicenceLink}|{Licence}</link>",
                $"<link>{ProjectGitHubPage}|{ProjectName.de}</link>{NewLine}Ausführung {version}{NewLine}Entwickelt von <link>{DeveloperGitHubPage}|{Developer}</link>{NewLine}Licence: <link>{LicenceLink}|{Licence}</link>");

            ProgramSuccessfullyStarted = new CultureStrings(
                "Program successfully started",
                "Программа успешно запущена",
                "Programm erfolgreich gestartet");

            SelectFile = new CultureStrings(
                "Select file",
                "Выберите файл",
                "Datei aussuchen");
            
            FileSaved = new CultureStrings(
                "File saved",
                "Файл сохранен");

            SelectFolder = new CultureStrings(
                "Select folder",
                "Выберите папку",
                "Ordner auswählen");

            Settings = new CultureStrings(
                "Settings",
                "Настройки",
                "Einstellungen");
            DefaultDownloadPathLabel = new CultureStrings(
                "Default download folder",
                "Стандартная папка загрузки",
                "Standard download ordner");

            DefaultDownloadNameLabel = new CultureStrings(
                "Default download filename",
                "Стандартное имя файла",
                "Standard download datei name");

            CloseProgramQuestionTitle = new CultureStrings(
                "Close program?",
                "Закрыть программу?");

            CloseProgramQuestionText = new CultureStrings(
                "Do you want to close the program?",
                "Вы действительно хотите закрыть программу?");
            
            CompletedPathTitle = new CultureStrings(
                "Path completed",
                "Путь пройден");
            
            CompletedPathText = new CultureStrings(
                "Path successful completed.\n\nSteps: {0}\nHealth: {1}\n\nExit?",
                "Путь успешно пройден.\n\nШагов: {0}\nЗдоровье: {1}\n\nВыйти?");

            SetValue = new CultureStrings(
                "Set value",
                "Установить значение");

            Explorer = new CultureStrings(
                "Explorer",
                "Проводник");

            SelectAction = new CultureStrings(
                "Select",
                "Выбрать");

            ViewAction = new CultureStrings(
                "View",
                "Просмотреть");

            CopyAction = new CultureStrings(
                "Copy",
                "Копировать");

            PasteAction = new CultureStrings(
                "Paste",
                "Вставить");

            CutAction = new CultureStrings(
                "Cut",
                "Вырезать");

            AddAction = new CultureStrings(
                "Add",
                "Добавить");

            RemoveAction = new CultureStrings(
                "Remove",
                "Удалить");

            ChangeAction = new CultureStrings(
                "Change",
                "Изменить");

            RecursiveAction = new CultureStrings(
                "Recursive",
                "Рекурсивно");
            
            Wait = new CultureStrings(
                "Wait please...",
                "Пожалуйста, ожидайте...");

            YouSureQuestion = new CultureStrings(
                "Are you sure?",
                "Вы уверены?",
                "Bist du sicher?");

            OpenGitHubPageToolTip = new CultureStrings(
                "Open project github page",
                "Открыть GitHub страницу проекта");

            FileDialogButtonToolTip = new CultureStrings(
                "Select file path",
                "Выбрать путь к файлу",
                "Dateipfad auswählen");

            FolderDialogButtonToolTip = new CultureStrings(
                "Select folder path",
                "Выбрать путь к папке",
                "Ordnerpfad auswählen");

            PathTypeChangeButtonToRelativeToolTip = new CultureStrings(
                "Transform to relative path",
                "Преобразовать в относительный путь",
                "In relativen Pfad umwandeln");

            PathTypeChangeButtonToAbsoluteToolTip = new CultureStrings(
                "Transform to absolute path",
                "Преобразовать в абсолютный путь",
                "In absoluten Pfad transformieren");

            FormatHelpButtonToolTip = new CultureStrings(
                "Show available variables for replace",
                "Показать доступные переменные для замены",
                "Verfügbare Variablen zum Ersetzen anzeigen");

            Exit = new CultureStrings(
                "Exit",
                "Выход");

            OK = new CultureStrings(
                "OK",
                "Понятно",
                "Ich verstehe");

            Yes = new CultureStrings(
                "Yes",
                "Да",
                "Ja");

            No = new CultureStrings(
                "No",
                "Нет",
                "Nein");

            Apply = new CultureStrings(
                "Apply",
                "Применить");

            Cancel = new CultureStrings(
                "Cancel",
                "Отменить",
                "Stornieren");

            Retry = new CultureStrings(
                "Retry",
                "Повторить",
                "Wiederholen");

            Ignore = new CultureStrings(
                "Ignore",
                "Игнорировать",
                "Ignorieren");

            Accept = new CultureStrings(
                "Accept",
                "Принять",
                "Akzeptieren");

            Close = new CultureStrings(
                "Close",
                "Закрыть",
                "Schließen");

            Select = new CultureStrings(
                "Select",
                "Выбрать");

            Perform = new CultureStrings(
                "Perform",
                "Выполнить",
                "Ausführen");

            Resume = new CultureStrings(
                "Resume",
                "Возобновить",
                "Fortsetzen");

            Pause = new CultureStrings(
                "Pause",
                "Приостановить",
                "Pause");

            Debug = new CultureStrings(
                "Debug",
                "Отладка",
                "Debuggen");

            Action = new CultureStrings(
                "Action",
                "Действие",
                "Aktion");

            Good = new CultureStrings(
                "Good",
                "Хорошо",
                "Gut");

            Warning = new CultureStrings(
                "Warning",
                "Предупреждение",
                "Warnung");

            CriticalWarning = new CultureStrings(
                "Critical warning",
                "Критическое предупреждение",
                "Kritische warnung");

            Error = new CultureStrings(
                "Error",
                "Ошибка",
                "Fehler");

            CriticalError = new CultureStrings(
                "Critical error",
                "Критическая ошибка",
                "Kritischer fehler");

            FatalError = new CultureStrings(
                "Fatal error",
                "Фатальная ошибка",
                "Fataler fehler");

            UnknownError = new CultureStrings(
                "Unknown error",
                "Неизвестная ошибка",
                "Unbekannter fehler");
            
            InvalidMap = new CultureStrings(
                "Invalid file path, invalid map or map without valid path. Try another map.",
                "Неверный путь к файлу, невалидная карта или карта без возможного пути. Попробуйте другую карту.");

            WriteAccessDeniedError = new CultureStrings(
                "No write access on this path",
                "Отсутствует доступ на запись по данному пути",
                "Kein Schreibzugriff auf diesen Pfad");

            InitializedInvalidTaskError = new CultureStrings(
                "An attempt was made to initialize an invalid task",
                "Была предпринята попытка инициализировать неверную задачу",
                "Es wurde versucht, eine ungültige Aufgabe zu initialisieren");

            StartedInvalidTaskError = new CultureStrings(
                "An attempt was made to start an invalid task",
                "Была предпринята попытка запустить неверную задачу",
                "Es wurde versucht, eine ungültige Aufgabe zu starten");

            StartTest = new CultureStrings(
                "Start test",
                "Начать тест");

            StopTest = new CultureStrings(
                "Stop test",
                "Завершить тест");

            GradeMessageBox = new CultureStrings(
                "Grade",
                "Оценка");

            GradeLabel = new CultureStrings(
                "Last grade:",
                "Последняя оценка:");

            Subjects = new Dictionary<SubjectType, CultureStrings>
            {
                [SubjectType.MathBasic] = new CultureStrings("Basic math", "Базовая математика")
                
            }.ToImmutableDictionary();
        }
    }
}