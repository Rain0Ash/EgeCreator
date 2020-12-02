// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using EgeCreator.Model.Common;
using NetExtender.GUI.WinForms.Labels;
using NetExtender.Utils.GUI.WinForms.Controls;
using NetExtender.Utils.Types;
using WpfMath;

namespace EgeCreator.View.Winforms.Controls.Exercise
{
    public class LatexExerciseControl : ExerciseControl<LatexTemplate>
    {
        private readonly FixedLabel _textLabel;
        
        public LatexExerciseControl(LatexTemplate template)
            : base(template)
        {
            _textLabel = new FixedLabel
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                ImageAlign = ContentAlignment.MiddleCenter
            };
            
            TexFormulaParser parser = new TexFormulaParser();
            TexFormula formula = parser.Parse(template.FullTemplate);
            Byte[] png = formula.RenderToPng(15.0, 0.0, 0.0, "Times New Roman");
            _textLabel.Image = ImageUtils.FromBytes(png);
            Controls.Add(_textLabel);
        }
        
        protected override void UpdateControls(Object sender, EventArgs e)
        {
            base.UpdateControls(sender, e);
            _textLabel.SetPosition(0, 0);
            _textLabel.SetSize(ClientSize.Width, ClientSize.Height - AnswerTextBox.Size.Height);
        }
    }
}