// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EgeCreator.Model.Common;
using EgeCreator.View.Winforms.Controls.Exercise;
using NetExtender;
using NetExtender.Interfaces;
using NetExtender.Utils.GUI.WinForms.Controls;

namespace EgeCreator.View.Winforms.Controls
{
    public class TestTab : TabControl, IStartable
    {
        public event EventHandler TimerTick;
        public event TypeHandler<Int32> Completed; 
        
        public Boolean IsStarted
        {
            get
            {
                return _timer is not null;
            }
        }

        private Timer _timer;
        private IDictionary<Int32, Int32> Grade { get; } = new Dictionary<Int32, Int32>();
        public Int32 FullGrade { get; private set; }

        public TestTab()
        {
            DrawMode = TabDrawMode.OwnerDrawFixed;
            DrawItem += OnDrawItem;
        }

        public void AddPage(Template template)
        {
            TabPage page = new TabPage(template.Info.Number.ToString());
            ExerciseControl control = ExerciseControl.Create(template);
            control.Completed += ControlOnCompleted;
            page.Controls.Add(control);
            page.SetSize(ClientSize.Width, Size.Height - 30);
            control.SetSize(page);
            TabPages.Add(page);
        }
        
        public void Start()
        {
            if (IsStarted)
            {
                return;
            }

            _timer = new Timer
            {
                Interval = 50
            };
            _timer.Tick += TimerOnTick;
            _timer.Start();
        }

        public void Stop()
        {
            if (!IsStarted)
            {
                return;
            }
            
            _timer?.Dispose();
            _timer = null;
            
            foreach (TabPage page in TabPages)
            {
                foreach (Control control in page.Controls)
                {
                    control.Enabled = false;
                }
            }
            
            Completed?.Invoke(FullGrade);
            TimerTick = null;
        }
        
        private void TimerOnTick(Object sender, EventArgs e)
        {
            TimerTick?.Invoke(this, e);
        }

        private void ControlOnCompleted(Int32 grade, TemplateInfo info)
        {
            Grade.Add(info.Number, grade);
            FullGrade = Tasks.GetTasksBySubject(info.Subject).Grade[Grade.Sum(pair => pair.Value)];

            Invalidate();
        }
        
        public void Reset()
        {
            foreach (TabPage page in TabPages)
            {
                foreach (Control control in page.Controls)
                {
                    control.Dispose();
                }
            }
            
            TabPages.Clear();
            Grade.Clear();
            FullGrade = 0;
        }
        
        private void OnDrawItem(Object sender, DrawItemEventArgs e)
        {
            if (TabPages.Count <= e.Index)
            {
                return;
            }
            
            TabPage page = TabPages[e.Index];
            
            if (page.Controls.Count <= 0)
            {
                return;
            }
            
            Template template = (page.Controls[0] as dynamic)?.Template;
            
            if (template is not null && Grade.TryGetValue(template.Info.Number, out Int32 grade))
            {
                e.Graphics.FillRectangle(grade > 0 ? Brushes.Chartreuse : Brushes.Red, e.Bounds);
            }

            Rectangle bounds = e.Bounds;
            Int32 offset = e.State == DrawItemState.Selected ? -2 : 1;
            bounds.Offset(1, offset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, bounds, page.ForeColor);
        }
    }
}