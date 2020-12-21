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

namespace EgeCreator.Model.Generators.Math
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public partial class BasicMathTasks
    {
        public class Math8 : TaskSingleton<Math8>
        {
            protected static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 8, 1);

            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String ru =
                    "Детская горка укреплена вертикальным столбом, расположенным посередине спуска. Найдите высоту l этого столба, если высота {0} горки равна 3 метрам. Ответ дайте в метрах. (Конструкция представляет собой треугольник, в котором столб является средней линией. Округлять до сотых!)";

                Random random = new Random();

                Decimal h = random.Next(1, 20);

                Decimal answer = System.Math.Round(h / 2, 1, MidpointRounding.ToEven);

                List<String> list = new List<String>
                {
                    answer.GetString(CultureInfo.CurrentCulture),
                    answer.GetString(CultureInfo.InvariantCulture)
                };

                result = list.Distinct().ToImmutableArray();
                return new CultureStrings(String.Format(ru, h));
            }
            
            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String ru =
                    "Участок земли для строительства санатория имеет форму прямоугольника, стороны которого равны {0} м и {1} м. Одна из бóльших сторон участка идёт вдоль моря, а три остальные стороны нужно отгородить забором. Найдите длину этого забора. Ответ дайте в метрах.";

                Random random = new Random();

                Decimal b = random.Next(500, 1000);
                Decimal a = random.Next(100, 500);

                Decimal answer = 2 * a + b;

                List<String> list = new List<String>
                {
                    answer.GetString(CultureInfo.CurrentCulture),
                    answer.GetString(CultureInfo.InvariantCulture)
                };

                result = list.Distinct().ToImmutableArray();
                return new CultureStrings(String.Format(ru, b, a));
            }
            
            public static Template GetSubTemplate3()
            {
                return new TextTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                const String ru =
                    "Дачный участок имеет форму прямоугольника с длиной {0} метров и шириной {1} метров. Хозяин планирует обнести его забором и разделить таким же забором на две части, одна из которых имеет форму квадрата. Найдите общую длину забора в метрах.";

                Random random = new Random();

                Decimal s1 = random.Next(10, 60);
                Decimal s2 = random.Next(10, 60);

                Decimal answer = 3 * s1 + 2 * s2;

                List<String> list = new List<String>
                {
                    answer.GetString(CultureInfo.CurrentCulture),
                    answer.GetString(CultureInfo.InvariantCulture)
                };

                result = list.Distinct().ToImmutableArray();
                return new CultureStrings(String.Format(ru, s1, s2));
            }
        }
    }
}