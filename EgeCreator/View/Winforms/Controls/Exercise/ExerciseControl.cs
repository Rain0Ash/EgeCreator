// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using EgeCreator.Model.Common;
using NetExtender.GUI.WinForms.Buttons;
using NetExtender.GUI.WinForms.TextBoxes;
using NetExtender.Interfaces;
using NetExtender.Types.Numerics;
using NetExtender.Utils.GUI.WinForms.Controls;
using NetExtender.Utils.IO;

namespace EgeCreator.View.Winforms.Controls.Exercise
{
    public abstract class ExerciseControl<T> : ExerciseControl where T : Template
    {
        public T Template { get; }

        protected readonly TextBox AnswerTextBox;
        private readonly FixedButton _submitButton;

        public ExerciseControl(T template)
        {
            Template = template;

            BackColor = Color.Aqua;
            
            AnswerTextBox = new TextBox();
            _submitButton = new FixedButton();
            Controls.Add(AnswerTextBox);
            Controls.Add(_submitButton);
            HandleCreated += UpdateControls;
            SizeChanged += UpdateControls;
            LocationChanged += UpdateControls;
        }

        protected virtual void UpdateControls(Object sender, EventArgs e)
        {
            AnswerTextBox.SetSize((Int32) (ClientSize.Width * 0.8), AnswerTextBox.Size.Height);
            AnswerTextBox.SetPositionInner(this, PointOffset.DownLeft, 0);
            _submitButton.SetSize((Int32) (ClientSize.Width * 0.2), AnswerTextBox.Size.Height);
            _submitButton.SetPosition(AnswerTextBox, PointOffset.Right, 0);
        }
    }

    public abstract class ExerciseControl : Control
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
    }
}