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
        public class Math2 : TaskSingleton<Math2>
        {
            protected static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 2, 1);

            public static Template GetSubTemplate1()
            {
                return new LatexTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                Decimal first = RandomUtils.NextDecimal(-10, 10).Round(0).ToNonZero();
                Decimal second = RandomUtils.NextDecimal(-10, 10).Round(0).ToNonZero();
                Decimal third = RandomUtils.NextDecimal(-10, 10).Round(0).ToNonZero();

                Decimal answer = ((first * first * first - second * second) * third).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"({{{first.GetString(NumberFormatInfo.InvariantInfo)}}}^{{{3}}} - {{{second.GetString(NumberFormatInfo.InvariantInfo)}}}^{{{2}}}) \cdot {third.GetString(NumberFormatInfo.InvariantInfo)}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate2()
            {
                return new LatexTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                Decimal first = RandomUtils.NextDecimal(-20, 30).Round(1).ToNonZero();
                Decimal second = RandomUtils.NextDecimal(-20, 30).Round(1).ToNonZero();
                Int32 third = RandomUtils.NextInt32(-2, 4);
                Int32 fourth = RandomUtils.NextInt32(-2, 4);

                Decimal answer = (first * (Decimal)System.Math.Pow(10,third) + second * (Decimal)System.Math.Pow(10, fourth)).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"{first.GetString(NumberFormatInfo.InvariantInfo)} \cdot {{{10}}}^{{{third}}} + {second.GetString(NumberFormatInfo.InvariantInfo)} \cdot {{{10}}}^{{{fourth}}}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate3()
            {
                return new LatexTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                Int32 first = RandomUtils.NextInt32(2, 10);
                Int32 second = RandomUtils.NextInt32(2, 10);
                Int32 third = RandomUtils.NextInt32(2, 10);
                Int32 fourth = second + third - RandomUtils.NextInt32(2, 5);

                Decimal answer = ((Decimal)System.Math.Pow(first, second+third-fourth)).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"\frac{{{{{first}}}^{{{second}}} \cdot {{{first}}}^{{{third}}}}}{{{{{first}}}^{{{fourth}}}}}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate4()
            {
                return new LatexTemplate(GetSubTemplate4, Info);
            }

            public static CultureStrings GetSubTemplate4(out IImmutableList<String> result)
            {
                Int32 first = RandomUtils.NextInt32(2, 10);
                Int32 second = RandomUtils.NextInt32(2, 4);
                Int32 third = RandomUtils.NextInt32(2, 4);
                Int32 fourth = second * third - RandomUtils.NextInt32(2, 5);

                Decimal answer = ((Decimal)System.Math.Pow(first, second*third-fourth)).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.GetString(NumberFormatInfo.CurrentInfo), answer.GetString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"\frac{{ {{ {{{first}}}^{{{second}}} }}^{{{third}}} }}{{ {{{first}}}^{{{fourth}}} }}";

                return new CultureStrings(template);
            }
        }
    }
}