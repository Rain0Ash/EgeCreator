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
        public class Math20 : TaskSingleton<Math20>
        {
            private static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 20, 1);

            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }
            
            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String ru = "На палке отмечены поперечные линии красного, жёлтого и зелёного цвета. Если распилить палку по красным линиям, получится {0} кусков, если по жёлтым — {1} кусков, а если по зелёным — {2} кусков. Сколько кусков получится, если распилить палку по линиям всех трёх цветов?";

                Int32 red = RandomUtils.NextInt32(3, 30);
                Int32 yellow = RandomUtils.NextInt32(3, 30);
                Int32 green = RandomUtils.NextInt32(3, 30);

                Int32 answer = red + yellow + green - 3;

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, red, yellow, green));
            }
        }
    }
}