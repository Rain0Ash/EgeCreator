// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using EgeCreator.Localizations;
using EgeCreator.Model.Common;
using NetExtender.Utils.Numerics;
using NetExtender.Utils.Types;

namespace EgeCreator.Model.Generators.Math
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public partial class BasicMathTasks
    {
        public class Math7 : TaskSingleton<Math7>
        {
            protected static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 7, 1);

            public static Template GetSubTemplate1()
            {
                return new LatexTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                Int32[] numbers = {2, 4, 5, 10};
                Int32 D = RandomUtils.NextInt32(2, 15);
                D *= D;
                Int32 a = numbers[RandomUtils.NextInt32(0, 3)];
                Int32 b = RandomUtils.NextInt32(1, 8);

                Int32 sign_a = RandomUtils.NextInt32(0, 1);
                if (sign_a == 0)
                {
                    sign_a = -1;
                }

                Decimal sign_b = RandomUtils.NextInt32(0, 1);
                if (sign_b == 0)
                {
                    sign_b = -1;
                }

                Decimal c = (b * b - D) / (4M * a * sign_a);

                Decimal x1 = (-b * sign_b + (Decimal) D.Sqrt()) / (2 * a * sign_a);
                Decimal x2 = (-b * sign_b - (Decimal) D.Sqrt()) / (2 * a * sign_a);
                if (x2 > x1)
                {
                    x1 = x2;
                }

                Decimal answer = x1;
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"\text{{Решите уравнение }}{sign_a.ToSign()}{a}X^{{2}} {sign_b.ToSign()}{b}X {c.ToSign()}{c} = 0.\\\text{{Если уравнение имеет более одного корня, в ответе укажите больший из них.}}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate2()
            {
                return new LatexTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                Int32 foundation = RandomUtils.NextInt32(2, 8);
                Int32 first = RandomUtils.NextInt32(-10, 10);
                Int32 second = RandomUtils.NextInt32(-4, 4);

                Decimal answer = second - first;
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template;
                if (second < 0)
                {
                    template = $@"\text{{Найдите корень уравнения }}{foundation}^{{x {first.ToSign()} {first.Abs()}}} = \frac{{1}}{{{System.Math.Pow(foundation, second.Abs())}}}";
                }
                else
                {
                    template = $@"\text{{Найдите корень уравнения }}{foundation}^{{x {first.ToSign()} {first.Abs()}}} = {System.Math.Pow(foundation, second)}";
                }

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate3()
            {
                return new LatexTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                Int32 first = RandomUtils.NextInt32(2, 10);
                Int32 second = RandomUtils.NextInt32(-20, 30);

                Decimal answer = 1 - second;
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"\text{{Найдите корень уравнения }}log_{{{first}}}(x {second.ToSign()} {second.Abs()}) = 0";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate4()
            {
                return new LatexTemplate(GetSubTemplate4, Info);
            }

            public static CultureStrings GetSubTemplate4(out IImmutableList<String> result)
            {
                Int32 first = RandomUtils.NextInt32(-20, 30);
                Decimal second = RandomUtils.NextInt32(2, 10);

                Decimal answer = second * second - first;
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"\text{{Найдите корень уравнения }}\sqrt{{x {first.ToSign()} {first.Abs()}}} = {second}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate5()
            {
                return new LatexTemplate(GetSubTemplate5, Info);
            }

            public static CultureStrings GetSubTemplate5(out IImmutableList<String> result)
            {
                Int32 foundation = RandomUtils.NextInt32(2, 6);
                Int32 first = RandomUtils.NextInt32(-20, 30);
                Int32 second = RandomUtils.NextInt32(1, 4);

                Decimal answer = (Decimal) System.Math.Pow(foundation, second) - first;
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"\text{{Найдите корень уравнения }}log_{{{foundation}}}(x {first.ToSign()} {first.Abs()}) = {second}";

                return new CultureStrings(template);
            }
        }
    }
}