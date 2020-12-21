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
                const String template =
                                        @"\\A) log_{2}x > 1 \text{             } 1) 0 < x < \frac{1}{2}" +
                                        @"\\B) log_{2}x > -1 \text{            } 2) x > 2" +
                                        @"\\C) log_{2}x < 1 \text{             } 3) x > \frac{1}{2}" +
                                        @"\\D) log_{2}x < -1 \text{            } 4) 0 < x < 2";
                
                const String en = @"\text{Establish a correspondence between inequalities and their solutions.}" + template;
                const String ru = @"\text{Установите соответствие между неравенствами и их решениями.}" + template;

                result = EnumerableUtils.GetEnumerableFrom("2341").ToImmutableArray();
                return new CultureStrings(en, ru);
            }
            
            public static Template GetSubTemplate2()
            {
                return new LatexTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String template =
                                        @"\\A) 2^{x} \geq 2 \text{               } 1) x \geq 1" +
                                        @"\\B) 0.5^{x} \geq 2 \text{             } 2) x \leq 1" +
                                        @"\\C) 0.5^{x} \leq 2 \text{             } 3) x \leq -1" +
                                        @"\\D) 2^{x} \leq 2 \text{               } 4) x \geq -1";
                
                const String en = @"\text{Establish a correspondence between inequalities and their solutions.}" + template;
                const String ru = @"\text{Установите соответствие между неравенствами и их решениями.}" + template;

                result = EnumerableUtils.GetEnumerableFrom("1342").ToImmutableArray();
                return new CultureStrings(en, ru);
            }
            
            public static Template GetSubTemplate3()
            {
                return new LatexTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                const String template =
                                        @"\\A) 0.5^{x} \geq 4 \text{             } 1) [-2;+\infty)" +
                                        @"\\B) 2^{x} \geq 4 \text{               } 2) [2;+\infty)" +
                                        @"\\C) 0.5^{x} \leq 4 \text{             } 3) (-\infty;2]" +
                                        @"\\D) 2^{x} \leq 4 \text{               } 4) (-\infty;-2]";

                const String en = @"\text{Establish a correspondence between inequalities and their solutions.}" + template;
                const String ru = @"\text{Установите соответствие между неравенствами и их решениями.}" + template;
                
                result = EnumerableUtils.GetEnumerableFrom("4213").ToImmutableArray();
                return new CultureStrings(en, ru);
            }
        }
    }
}