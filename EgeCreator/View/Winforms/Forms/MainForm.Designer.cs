using System;
using System.Drawing;
using System.Windows.Forms;
using NetExtender.GUI.WinForms.Buttons;
using NetExtender.GUI.WinForms.ComboBoxes;
using NetExtender.Images;
using EgeCreator.View.Winforms.Layout;
using EgeCreator.Localizations;
using EgeCreator.Model.Common;
using EgeCreator.Model.Options;
using EgeCreator.View.Winforms.Controls;
using NetExtender.GUI.WinForms.Labels;
using NetExtender.Types.Dictionaries;
using NetExtender.Types.Dictionaries.Interfaces;
using NetExtender.Types.Maps;
using NetExtender.Types.Numerics;
using NetExtender.Utils.GUI.WinForms.Controls;
using NetExtender.Utils.Types;

namespace EgeCreator.View.Winforms.Forms
{
    public partial class MainForm
    {
        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(GUILayout.MainFormSizeWidth, GUILayout.MainFormSizeHeight);
            
            _githubButton = new WebBrowserButton
            {
                Size = new Size(25, 25),
                Url = ProgramLocalization.ProjectGitHubPage,
                BackgroundImageLayout = ImageLayout.Stretch,
                BackgroundImage = Images.Flat.GitHub,
            };

            _githubButton.SetPosition(this, PointOffset.UpRight, 0);

            _localizationComboBox = new LocalizationComboBox();

            _localizationComboBox.SetPosition(_githubButton, PointOffset.Left, 0);

            _subjectComboBox = new FixedComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
            };
            
            _subjectComboBox.SetSize(180, ControlSizeType.Width);
            
            foreach (SubjectType subject in EnumUtils.GetValuesWithoutDefault<SubjectType>())
            {
                _subjectComboBox.Items.Add(Globals.Localization.Subjects[subject]);
            }

            _subjectComboBox.SelectedIndex = 0;

            _startTestButton = new FixedButton();
            _startTestButton.SetSize(125, ControlSizeType.Width);
            _startTestButton.SetPosition(_subjectComboBox, PointOffset.Right, 0);
            _startTestButton.Click += StartTestButtonOnClick;

            _testTab = new TestTab
            {
                Appearance = TabAppearance.FlatButtons,
                BackColor = Color.Black
            };
            _testTab.SetPosition(_subjectComboBox, PointOffset.Down, 0);
            _testTab.SetSize(ClientSize.Width, ClientSize.Height - _testTab.Location.Y - 20);

            _timerLabel = new FixedLabel
            {
                AutoSize = false,
                ForeColor = Color.Red
            };
            _timerLabel.SetPosition(0, _testTab.Location.Y + _testTab.Size.Height);
            _timerLabel.SetSize(20, ControlSizeType.Height);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Icon = Resources.Resources.icon;
            Controls.Add(_githubButton);
            Controls.Add(_localizationComboBox);
            Controls.Add(_subjectComboBox);
            Controls.Add(_startTestButton);
            Controls.Add(_testTab);
            Controls.Add(_timerLabel);
            ResumeLayout();
        }

        private WebBrowserButton _githubButton;
        private LocalizationComboBox _localizationComboBox;
        private FixedComboBox _subjectComboBox;
        private FixedButton _startTestButton;
        private TestTab _testTab;
        private FixedLabel _timerLabel;
        private Timer _timer;
    }
}