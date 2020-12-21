// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using EgeCreator.Localizations;
using NetExtender.Utils.Numerics;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;

namespace EgeCreator.Model.Generators.Math
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public partial class BasicMathTasks
    {
        public class Math14 : TaskSingleton<Math14>
        {
            private static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 14, 1);

            private static Size DefaultSize { get; } = new Size(1, 10);
            
            public static Template GetSubTemplate1()
            {
                return new GraphicTemplate(GetSubTemplate1, Info);
            }

            public static GraphicTemplateData GetSubTemplate1(out IImmutableList<String> result)
            {
                const String ru = "На оси абсцисс откладывается время в минутах, на оси ординат — температура двигателя в градусах Цельсия. Сколько минут двигатель нагревался от {0} °C до {1} °C.";

                Int32 min = RandomUtils.NextInt32(50, 100).RoundToMultiplier(10);
                Int32 max = RandomUtils.NextInt32(min + 20, min + 100).RoundToMultiplier(10);

                List<System.Windows.Point> points = new List<System.Windows.Point>();

                Int32 current = RandomUtils.NextInt32(5, 25);

                Int32 answer = 0;

                Int32 counter = 0;
                
                Boolean completed = false;
                while (current <= max)
                {
                    switch (completed)
                    {
                        case false when current < min:
                            current += RandomUtils.NextInt32(5, 15);
                            MathUtils.ToRange(ref current, 0, min);
                            break;
                        case false when current < max:
                            current += RandomUtils.NextInt32(5, 15);
                            MathUtils.ToRange(ref current, 0, max);
                            break;
                        default:
                            current += RandomUtils.NextInt32(1, 20);
                            completed = true;
                            break;
                    }
                    
                    if (!completed && current.InRange(min, max, MathPositionType.Right))
                    {
                        answer++;
                    }
                    
                    points.Add(new System.Windows.Point(++counter, current));
                }

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString()).ToImmutableArray();

                return new GraphicTemplateData(new CultureStrings(String.Format(ru, min, max)), points, DefaultSize);
            }
        }
    }
}