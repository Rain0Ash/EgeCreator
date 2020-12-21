// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using EgeCreator.Localizations;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;
using NetExtender.Utils.Numerics;

namespace EgeCreator.Model.Generators.Math
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public partial class BasicMathTasks
    {
        public class Math16 : TaskSingleton<Math16>
        {
            protected static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 16, 1);

            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String template =
                    "Даны два цилиндра. Радиус основания и высота первого равны соответственно {0} и {1}, а второго — {2} и {3}. Во сколько раз объём второго цилиндра больше объёма первого?";

                Int32 r1 = RandomUtils.NextInt32(2, 15);
                Int32 h1 = RandomUtils.NextInt32(2, 100);
                Int32 r2 = RandomUtils.NextInt32(r1, System.Math.Max(r1 + 10, 100));
                Int32 h2 = RandomUtils.NextInt32(h1 + 5, System.Math.Max(h1 + 10, 100));

                Int32 v1 = r1 * r1 * h1;
                Int32 v2 = r2 * r2 * h2;

                Decimal answer = ((Decimal) v2 / v1).Round(2);

                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(CultureInfo.CurrentCulture), answer.GetString()).Distinct().ToImmutableArray();
                return new CultureStrings(String.Format(template, r1, h1, r2, h2));
            }

            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String ru =
                    "Основанием прямой треугольной призмы служит прямоугольный треугольник с катетами {0} и {1}, боковое ребро равно {2}. Найдите объем призмы. (Окгрулять до сотых)";

                Random random = new Random();

                Decimal s1 = random.Next(1, 15);
                Decimal s2 = random.Next(1, 15);
                Decimal s3 = random.Next(1, 15);


                Decimal answer = s1 * s2 * s3 / 2;
                List<String> list = new List<String>
                {
                    answer.GetString(CultureInfo.CurrentCulture),
                    answer.GetString(CultureInfo.InvariantCulture)
                };

                result = list.Distinct().ToImmutableArray();
                return new CultureStrings(String.Format(ru, s1, s2, s3));
            }
            
            public static Template GetSubTemplate3()
            {
                return new TextTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result3)
            {
                const String ru =
                    "Два ребра прямоугольного параллелепипеда равны {0} и {1}, а объём параллелепипеда равен {2}. Найдите площадь поверхности этого параллелепипеда.(Окгрулять до сотых)";

                Random random = new Random();

                Decimal s1 = random.Next(1, 15);
                Decimal s2 = random.Next(1, 15);
                Decimal s3 = random.Next(100, 450);

                Decimal s4 = System.Math.Round(s3 / (s1 * s2), 2, MidpointRounding.ToEven);
                Decimal answer = System.Math.Round(2 * (s1 * s2 + s2 * s4 + s1 * s4), 2, MidpointRounding.ToEven);

                List<String> list = new List<String>
                {
                    answer.GetString(CultureInfo.CurrentCulture),
                    answer.GetString(CultureInfo.InvariantCulture)
                };

                result3 = list.Distinct().ToImmutableArray();
                return new CultureStrings(String.Format(ru, s1, s2, s3));
            }
        }
    }
}