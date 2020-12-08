// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using EgeCreator.Model.Common;
using NetExtender.GUI.WinForms.Labels;
using NetExtender.Utils.GUI.WinForms.Controls;

namespace EgeCreator.View.Winforms.Controls.Exercise
{
    public class TextExerciseControl : ExerciseControl<TextTemplate>
    {
        private readonly FixedLabel _textLabel;

        public TextExerciseControl(TextTemplate template)
            : base(template)
        {
            _textLabel = new FixedLabel()
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = template.FullTemplate
            };

            Controls.Add(_textLabel);
        }

        public override void UpdateText()
        {
            base.UpdateText();
            _textLabel.Text = Template.FullTemplate;
        }

        protected override void UpdateControls(Object sender, EventArgs e)
        {
            base.UpdateControls(sender, e);
            _textLabel.SetPosition(0, 0);
            _textLabel.SetSize(ClientSize.Width, ClientSize.Height - AnswerTextBox.Size.Height);
        }
    }
}