// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows.Forms;
using NetExtender.GUI.WinForms.Forms;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;
using EgeCreator.Model.Options;
using NetExtender.Utils.GUI;

namespace EgeCreator.View.Winforms.Forms
{
    public partial class MainForm : PrimaryForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public override void UpdateText()
        {
            SetMessage(_githubButton, Globals.Localization.OpenGitHubPageToolTip);
            
            Text = Globals.Localization.ProjectName;
            _startTestButton.Text = Globals.Localization.StartTest;
            _stopTestButton.Text = Globals.Localization.StopTest;
            _lastGradeTextLabel.Text = Globals.Localization.GradeLabel;

            Int32 index = _subjectComboBox.SelectedIndex;
            _subjectComboBox.Items.Clear();
            foreach (SubjectType subject in EnumUtils.GetValuesWithoutDefault<SubjectType>())
            {
                _subjectComboBox.Items.Add(Globals.Localization.Subjects[subject]);
            }

            _subjectComboBox.SelectedIndex = index;
        }
        
        private void StartTestButtonOnClick(Object? sender, EventArgs e)
        {
            if (_testTab.IsStarted)
            {
                if (Globals.Localization.YouSureQuestion.ToMessageBox(Globals.Localization.YouSureQuestion, MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                
                _testTab.Stop();
            }
            
            _testTab.Reset();

            dynamic task = Tasks.GetTasksBySubject((SubjectType) _subjectComboBox.SelectedIndex + 1);

            if (task.Time is not TimeSpan time)
            {
                throw new ArgumentException(nameof(time));
            }
            
            DateTime endtime = DateTime.UtcNow.Add(time);

            void Tick(Object obj, EventArgs args)
            {
                TimeSpan remaining = endtime - DateTime.UtcNow;

                if (remaining >= TimeSpan.Zero)
                {
                    _timerLabel.Text = remaining.ToString();
                    return;
                }

                _timerLabel.Text = TimeSpan.Zero.ToString();
                _testTab.Stop();
            }

            _testTab.TimerTick += Tick;
            
            foreach (Template template in task.CreateTest())
            {
                _testTab.AddPage(template);
            }
            
            _testTab.Start();
            _stopTestButton.Visible = true;
            _stopTestButton.Enabled = true;
            _lastGradeLabel.Visible = true;
            _lastGradeTextLabel.Visible = true;
        }
        
        private void StopTestButtonOnClick(Object? sender, EventArgs e)
        {
            if (Globals.Localization.YouSureQuestion.ToMessageBox(Globals.Localization.YouSureQuestion, MessageBoxButtons.YesNo).ToBoolean())
            {
                _testTab.Stop();
            }
        }        
        
        private void StopTest(Int32 grade)
        {
            _lastGradeLabel.Text = grade.ToString();
            _stopTestButton.Enabled = false;
            
            grade.ToMessageBox(Globals.Localization.GradeMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            _testTab.Stop();
        }
    }
}