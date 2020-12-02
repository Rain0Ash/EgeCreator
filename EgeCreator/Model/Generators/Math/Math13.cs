// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using EgeCreator.Localizations;
using NetExtender.Utils.Numerics;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;
using NetExtender.Utils.Core;

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
                const String ru = "Ящик, имеющий форму куба с ребром {0} см без одной грани, нужно покрасить со всех сторон снаружи. Найдите площадь поверхности, которую необходимо покрасить. Ответ дайте в квадратных сантиметрах.";
                
                Decimal edge = RandomUtils.NextDecimal(1, 500).Round(2);

                Decimal answer = 5 * edge * edge;

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, edge));
            }
            
            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }
            
            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String ru = "Аквариум имеет форму куба со стороной {0} см. Сколько литров составляет объём аквариума?";
                
                Decimal edge = RandomUtils.NextDecimal(1, 500).Round(1);

                Decimal answer = edge * edge * edge;

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, edge));
            }
        }
    }
}