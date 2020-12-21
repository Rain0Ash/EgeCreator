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
        public class Math1 : TaskSingleton<Math1>
        {
            protected static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 1, 1);

            public static Template GetSubTemplate1()
            {
                return new LatexTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                Decimal first = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal second = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal third = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();

                Decimal answer = (first * (second + third)).Round(2);
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString()).Distinct().ToImmutableArray();

                String template =
                    $@"{first.GetString()} \cdot ({second.GetString()} {third.ToSign()} {third.Abs().GetString()})";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate2()
            {
                return new LatexTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                Decimal first = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal second = RandomUtils.NextDecimal(-20, 30).Round(1).ToNonZero();
                Decimal third = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal fourth = RandomUtils.NextDecimal(-20, 30).Round(1).ToNonZero();
                Decimal fifth = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal sixth = RandomUtils.NextDecimal(-20, 30).Round(1).ToNonZero();

                Decimal negative = RandomUtils.NextSignDecimal();

                Decimal answer = (first / second * (third / fourth + negative * fifth / sixth)).Round(2);
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString()).Distinct().ToImmutableArray();

                String template = @$"\frac{{{first}}}{{{second}}} \cdot (\frac{{{third}}}{{{fourth}}} {negative.ToSign()} \frac{{{fifth}}}{{{sixth}}})";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate3()
            {
                return new LatexTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                Decimal first = RandomUtils.NextDecimal(-20, 30).Round().ToNonZero();
                Decimal second = RandomUtils.NextDecimal(-20, 30).Round().ToNonZero();
                Decimal third = RandomUtils.NextDecimal(-20, 30).Round().ToNonZero();
                Decimal fourth = RandomUtils.NextDecimal(-20, 30).Round().ToNonZero();

                Decimal answer = ((first + second) / third).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"(\frac{{{first.GetString(NumberFormatInfo.InvariantInfo)}}}{{{fourth.GetString(NumberFormatInfo.InvariantInfo)}}} + \frac{{{second.GetString(NumberFormatInfo.InvariantInfo)}}}{{{fourth.GetString(NumberFormatInfo.InvariantInfo)}}}) : \frac{{{third.GetString(NumberFormatInfo.InvariantInfo)}}}{{{fourth.GetString(NumberFormatInfo.InvariantInfo)}}}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate4()
            {
                return new LatexTemplate(GetSubTemplate4, Info);
            }

            public static CultureStrings GetSubTemplate4(out IImmutableList<String> result)
            {
                Decimal first = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal second = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal third = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();

                Decimal answer = (first / (second + third)).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"\frac{{{first.GetString(NumberFormatInfo.InvariantInfo)}}}{{{second.GetString(NumberFormatInfo.InvariantInfo)} {third.ToSign()} {third.Abs().GetString(NumberFormatInfo.InvariantInfo)}}}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate5()
            {
                return new LatexTemplate(GetSubTemplate5, Info);
            }

            public static CultureStrings GetSubTemplate5(out IImmutableList<String> result)
            {
                Decimal first = RandomUtils.NextDecimal(-10, 10).Round().ToNonZero();
                Decimal second = RandomUtils.NextDecimal(-10, 10).Round().ToNonZero();

                Decimal negative = RandomUtils.NextSignDecimal();

                Decimal answer = (1 / ((1 / first) + negative * (1 / second))).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"\frac{{{1}}}{{\frac{{{1}}}{{{first}}} {negative.ToSign()} \frac{{{1}}}{{{second}}}}}";

                return new CultureStrings(template);
            }
            
            public static Template GetSubTemplate6()
            {
                return new LatexTemplate(GetSubTemplate6, Info);
            }

            public static CultureStrings GetSubTemplate6(out IImmutableList<String> result)
            {
                Decimal first = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal second = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal third = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();

                Decimal answer = (first * (second + third)).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"{first.GetString(NumberFormatInfo.InvariantInfo)} \cdot ({second.GetString(NumberFormatInfo.InvariantInfo)} {third.ToSign()} {third.Abs().GetString(NumberFormatInfo.InvariantInfo)})";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate7()
            {
                return new LatexTemplate(GetSubTemplate7, Info);
            }

            public static CultureStrings GetSubTemplate7(out IImmutableList<String> result)
            {
                Decimal first = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal second = RandomUtils.NextDecimal(-20, 30).Round(1).ToNonZero();
                Decimal third = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal fourth = RandomUtils.NextDecimal(-20, 30).Round(1).ToNonZero();
                Decimal fifth = RandomUtils.NextDecimal(-20, 30).Round(2).ToNonZero();
                Decimal sixth = RandomUtils.NextDecimal(-20, 30).Round(1).ToNonZero();

                Decimal negative = RandomUtils.NextSignDecimal();

                Decimal answer = (first / second * (third / fourth + negative * fifth / sixth)).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template = @$"\frac{{{first}}}{{{second}}} \cdot (\frac{{{third}}}{{{fourth}}} {negative.ToSign()} \frac{{{fifth}}}{{{sixth}}})";

                return new CultureStrings(template);
            }
        }
    }
}