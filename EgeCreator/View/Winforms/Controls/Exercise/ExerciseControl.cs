// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EgeCreator.Model.Common;
using EgeCreator.Model.Options;
using NetExtender;
using NetExtender.GUI.WinForms.Buttons;
using NetExtender.GUI.WinForms.Controls;
using NetExtender.GUI.WinForms.TextBoxes;
using NetExtender.Interfaces;
using NetExtender.Types.Numerics;
using NetExtender.Utils.GUI.WinForms.Controls;
using NetExtender.Utils.IO;

namespace EgeCreator.View.Winforms.Controls.Exercise
{
    public delegate void Completed(Int32 grade, TemplateInfo info);
    
    public abstract class ExerciseControl<T> : ExerciseControl where T : Template
    {
        public T Template { get; }

        protected readonly TextBox AnswerTextBox;
        private readonly FixedButton _submitButton;

        public ExerciseControl(T template)
        {
            Template = template;
            
            AnswerTextBox = new TextBox();
            _submitButton = new FixedButton();
            
            _submitButton.Click += SubmitButtonOnClick;
            
            Controls.Add(AnswerTextBox);
            Controls.Add(_submitButton);
            HandleCreated += UpdateControls;
            SizeChanged += UpdateControls;
            LocationChanged += UpdateControls;
        }

        public override void UpdateText()
        {
            _submitButton.Text = Globals.Localization.Accept;
        }

        private void SubmitButtonOnClick(Object? sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(AnswerTextBox.Text))
            {
                return;
            }
            
            AnswerTextBox.ReadOnly = true;
            _submitButton.Enabled = false;

            Boolean successful = Template.Result.Contains(AnswerTextBox.Text);

            AnswerTextBox.BackColor = successful ? Color.Chartreuse : Color.Red;

            OnCompleted(successful ? Template.Info.Grade : 0, Template.Info);
        }

        protected virtual void UpdateControls(Object sender, EventArgs e)
        {
            AnswerTextBox.SetSize((Int32) (ClientSize.Width * 0.8), AnswerTextBox.Size.Height);
            AnswerTextBox.SetPositionInner(this, PointOffset.DownLeft, 0);
            _submitButton.SetSize((Int32) (ClientSize.Width * 0.2), AnswerTextBox.Size.Height);
            _submitButton.SetPosition(AnswerTextBox, PointOffset.Right, 0);
        }
    }

    public abstract class ExerciseControl : LocalizationControl
    {
        public static ExerciseControl Create(Template template)
        {
            return template.Type switch
            {
                TemplateType.Text => new TextExerciseControl(template as TextTemplate) as ExerciseControl,
                TemplateType.Latex => new LatexExerciseControl(template as LatexTemplate) as ExerciseControl,
                _ => throw new NotSupportedException()
            } ?? throw new NullReferenceException();
        }
        
        public event Completed Completed;

        protected void OnCompleted(Int32 grade, TemplateInfo info)
        {
            Completed?.Invoke(grade, info);
        }

        protected override void Dispose(Boolean disposing)
        {
            base.Dispose(disposing);
            Completed = null;
        }
    }
}