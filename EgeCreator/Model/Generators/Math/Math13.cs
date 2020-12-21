// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using EgeCreator.Localizations;
using NetExtender.Utils.Numerics;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;

namespace EgeCreator.Model.Generators.Math
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public partial class BasicMathTasks
    {
        public class Math13 : TaskSingleton<Math13>
        {
            private static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 13, 1);

            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String ru =
                    "Ящик, имеющий форму куба с ребром {0} см без одной грани, нужно покрасить со всех сторон снаружи. Найдите площадь поверхности, которую необходимо покрасить. Ответ дайте в квадратных сантиметрах.";

                Int32 edge = RandomUtils.NextInt32(1, 40);

                Int32 answer = 5 * edge * edge;

                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(CultureInfo.CurrentCulture), answer.GetString()).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, edge));
            }

            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String ru = "Аквариум имеет форму куба со стороной {0} см. Сколько литров составляет объём аквариума?";

                Int32 edge = RandomUtils.NextInt32(1, 40);

                Int32 answer = edge * edge * edge;

                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(CultureInfo.CurrentCulture), answer.GetString()).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, edge));
            }
            
            public static Template GetSubTemplate3()
            {
                return new TextTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                const String ru =
                    "Аквариум имеет форму прямоугольного параллелепипеда с размерами {0} см × {1} см × {2} см. Сколько литров составляет объём аквариума? В одном литре 1000 кубических сантиметров.";

                Random random = new Random();

                Decimal s1 = random.Next(30, 60);
                Decimal s2 = random.Next(30, 60);
                Decimal s3 = random.Next(30, 60);

                Decimal answer = System.Math.Round(s1 * s2 * s3 / 1000, 0, MidpointRounding.ToEven);

                List<String> list = new List<String>
                {
                    answer.GetString(CultureInfo.CurrentCulture),
                    answer.GetString(CultureInfo.InvariantCulture)
                };

                result = list.Distinct().ToImmutableArray();
                return new CultureStrings(String.Format(ru, s1, s2, s3));
            }
        }
    }
}