// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
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
        public class Math5 : TaskSingleton<Math5>
        {
            protected static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 5, 1);

            public static Template GetSubTemplate1()
            {
                return new LatexTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                Int32 first = RandomUtils.NextInt32(2, 10);
                Int32 second = RandomUtils.NextInt32(2, 4);
                Int32 third = RandomUtils.NextInt32(2, 6);

                Decimal answer = (Decimal)System.Math.Pow(third, second);
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"{{{first}}}^{{{second}{{log}}_{{{first}}}{third}}}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate2()
            {
                return new LatexTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                Int32 number = RandomUtils.NextInt32(2, 100);
                Int32 n360 = RandomUtils.NextInt32(1, 5);

                Decimal answer = (number * 3 / 2M).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template = @$"{number}\sqrt{{3}}sin{60 * n360}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate3()
            {
                return new LatexTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                Int32 first = RandomUtils.NextInt32(5, 30);
                Int32 second = RandomUtils.NextInt32(5, 30);

                Decimal answer = first - second;
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"(\sqrt{{{first}}} - \sqrt{{{second}}})(\sqrt{{{first}}} + \sqrt{{{second}}})";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate4()
            {
                return new LatexTemplate(GetSubTemplate4, Info);
            }

            public static CultureStrings GetSubTemplate4(out IImmutableList<String> result)
            {
                // log(a) + log(b) = log(ab)
                Int32[] numbers = { 2, 4, 5, 8, 10 };  // цифры, на которые можно нормально делить
                Int32 foundation = RandomUtils.NextInt32(2, 5);
                Int32 number = (Int32)System.Math.Pow(foundation, RandomUtils.NextInt32(2, 4));
                Int32 first = numbers[RandomUtils.NextInt32(0, 4)];
                Decimal second = (Decimal)number / first;   // first * second = number

                Decimal answer = (Decimal)System.Math.Log(number, foundation);
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"log_{{{foundation}}}{first} + log_{{{foundation}}}{second}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate5()
            {
                return new LatexTemplate(GetSubTemplate5, Info);
            }

            public static CultureStrings GetSubTemplate5(out IImmutableList<String> result)
            {
                Int32 first = RandomUtils.NextInt32(3, 40);
                Int32 second = RandomUtils.NextInt32(2, 10);
                second *= second;

                Decimal answer = first * (Decimal)System.Math.Pow(second, 0.5) - first;
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"(\sqrt{{{first * second}}} - \sqrt{{{first}}}) \cdot \sqrt{{{first}}}";

                return new CultureStrings(template);
            }
        }
    }
}