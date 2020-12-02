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

                Decimal answer = (first * (second + third)).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"{first.ToString(NumberFormatInfo.InvariantInfo)} \cdot ({second.ToString(NumberFormatInfo.InvariantInfo)} {third.ToSign()} {third.Abs().ToString(NumberFormatInfo.InvariantInfo)})";
                
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
                
                Decimal answer = (first / second * (third / fourth + negative * fifth / sixth)).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template = @$"\frac{{{first}}}{{{second}}} \cdot (\frac{{{third}}}{{{fourth}}} {negative.ToSign()} \frac{{{fifth}}}{{{sixth}}})";
                
                return new CultureStrings(template);
            }
        }
    }
}