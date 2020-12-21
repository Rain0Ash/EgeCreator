// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EgeCreator.Model.Common;
using NetExtender.GUI.WinForms.Labels;
using NetExtender.Types.Numerics;
using NetExtender.Utils.GUI.WinForms.Controls;

namespace EgeCreator.View.Winforms.Controls.Exercise
{
    public class GraphicExerciseControl : ExerciseControl<GraphicTemplate>
    {
        private readonly FixedLabel _textLabel;
        private readonly Chart _chart;

        public GraphicExerciseControl(GraphicTemplate template)
            : base(template)
        {
            _textLabel = new FixedLabel
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = template.FullTemplate
            };

            _chart = new Chart
            {
                Left = 0
            };

            ChartArea area = new ChartArea(nameof(area))
            {
                AxisX = { Interval = template.Interval.Width },
                AxisY = { Interval = template.Interval.Height }
            };

            _chart.ChartAreas.Add(area);

            Series series = new Series(nameof(series))
            {
                ChartArea = area.Name,
                ChartType = SeriesChartType.Spline,
                Color = Color.Red
            };

            foreach (DataPoint point in Template.Points.Select(point => new DataPoint(point.X, point.Y)))
            {
                series.Points.Add(point);
            }

            _chart.Series.Add(series);

            Controls.Add(_textLabel);
            Controls.Add(_chart);
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
            _textLabel.SetSize(ClientSize.Width, 50);
            _chart.SetPosition(_textLabel, PointOffset.Down);
            _chart.SetSize(ClientSize.Width, ClientSize.Height - AnswerTextBox.Size.Height - 60);
        }
    }
}