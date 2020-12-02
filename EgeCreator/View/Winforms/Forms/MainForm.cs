// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq;
using System.Windows.Forms;
using NetExtender.GUI.WinForms.Forms;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;
using EgeCreator.Model.Generators.Math;
using EgeCreator.Model.Options;
using EgeCreator.View.Winforms.Controls.Exercise;
using NetExtender.Utils.GUI.WinForms.Controls;
using NetExtender.Utils.IO;

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
            _startTestButton.Text = Globals.Localization.CreateTest;

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
            _testTab.TabPages.OfType<TabPage>().ForEach(page => page.Dispose());
            _testTab.TabPages.Clear();

            dynamic task = Tasks.GetTasksBySubject((SubjectType) _subjectComboBox.SelectedIndex + 1);

            if (task.Time is not TimeSpan time)
            {
                throw new ArgumentException(nameof(time));
            }
            
            _timer?.Dispose();
            _timer = new Timer
            {
                Interval = 50
            };
            
            DateTime endtime = DateTime.UtcNow.Add(time);
            
            _timer.Tick += (_, _) =>
            {
                TimeSpan remaining = endtime - DateTime.UtcNow;
                
                if(remaining >= TimeSpan.Zero)
                {
                    _timerLabel.Text = remaining.ToString();
                    return;
                }
                
                _timer.Enabled = false;
                StopTest();
            };
            _timer.Start();

            foreach (Template template in task.CreateTest())
            {
                TabPage page = new TabPage(template.Info.Number.ToString());
                ExerciseControl control = ExerciseControl.Create(template);
                page.Controls.Add(control);
                page.SetSize(_testTab.ClientSize.Width, _testTab.Size.Height - 30);
                control.SetSize(page);
                _testTab.TabPages.Add(page);
            }
        }

        private void StopTest()
        {
            
        }
    }
}