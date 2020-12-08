// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using EgeCreator.Localizations;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;

namespace EgeCreator.Model.Generators.Math
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public partial class BasicMathTasks
    {
        public class Math17 : TaskSingleton<Math17>
        {
            protected static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 17, 1);
            
            public static Template GetSubTemplate1()
            {
                return new LatexTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String template = @"\text{Установите соответствие между неравенствами и их решениями.}" +
                                        @"\\A) log_{2}x > 1 \text{             } 1) 0 < x < \frac{1}{2}" +
                                        @"\\B) log_{2}x > -1 \text{            } 2) x > 2" +
                                        @"\\C) log_{2}x < 1 \text{             } 3) x > \frac{1}{2}" +
                                        @"\\D) log_{2}x < -1 \text{            } 4) 0 < x < 2";

                result = EnumerableUtils.GetEnumerableFrom("2341").ToImmutableArray();
                return new CultureStrings(template);
            }
        }
    }
}