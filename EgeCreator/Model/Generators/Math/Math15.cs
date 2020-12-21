// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using EgeCreator.Localizations;
using NetExtender.Utils.Numerics;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;

namespace EgeCreator.Model.Generators.Math
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public partial class BasicMathTasks
    {
        public class Math15 : TaskSingleton<Math15>
        {
            private static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 15, 1);

            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }
            
            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String ru = "В треугольнике ABC. Внешний угол при вершине B равен {0}°. Найдите угол C. Ответ дайте в градусах.";

                Decimal extangle = RandomUtils.NextDecimal(100, 140).RoundToMultiplier(2).Round(2);
                Decimal intangle = 180 - extangle;

                Decimal answer = 180 - 2 * intangle;

                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(CultureInfo.CurrentCulture), answer.GetString()).ToImmutableArray();
                
                return new CultureStrings(String.Format(ru, extangle.GetString()));
            }
        }
    }
}