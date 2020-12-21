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
        public class Math4 : TaskSingleton<Math4>
        {
            protected static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 4, 1);

            public static Template GetSubTemplate1()
            {
                return new LatexTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                Int32 i = RandomUtils.NextInt32(2, 15);
                Int32 r = RandomUtils.NextInt32(2, 15);

                Decimal answer = i * i * r;
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"\text{{Мощность постоянного тока (в ваттах) вычисляется по формуле }}P = {{I}}^{{2}} \cdot R\\\text{{где I — сила тока (в амперах), R — сопротивление (в омах).}}\\\text{{Пользуясь этой формулой, найдите P (в ваттах), если R = {r} Ом и I = {i} А.}}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate2()
            {
                return new LatexTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                Int32 pow = RandomUtils.NextInt32(-5, 5);
                Int32 u = RandomUtils.NextInt32(10, 30);

                Decimal answer = ((Decimal) System.Math.Pow(10, pow) * u * u / 2M).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    @$"\text{{Энергия заряженного конденсатора W (в Дж) вычисляется по формуле }}W = \frac{{C \cdot {{U}}^{{2}}}}{{2}}\\\text{{где C — ёмкость конденсатора (в Ф),}}\\\text{{а U — разность потенциалов на обкладках конденсатора (в В).}}\\\text{{Найдите W (в Дж), если C = 10^{{{pow}}} Ф и U = {u} В.}}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate3()
            {
                return new LatexTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                Int32 first = RandomUtils.NextInt32(5, 30);

                Decimal answer = first + 2;
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template = @$"\text{{Сумма углов правильного выпуклого многоугольника вычисляется по формуле }}\\\sum = (n - 2)\pi\\\text{{где n — количество его углов.}}\\\text{{Пользуясь этой формулой, найдите n, если }}\sum = 18\pi.";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate4()
            {
                return new LatexTemplate(GetSubTemplate4, Info);
            }

            public static CultureStrings GetSubTemplate4(out IImmutableList<String> result)
            {
                Int32[] prime_numbers = {2, 3, 5, 7, 11, 13};
                Int32 first = prime_numbers[RandomUtils.NextInt32(0, 5)];
                Int32 second = prime_numbers[RandomUtils.NextInt32(0, 5)];
                Int32 third = prime_numbers[RandomUtils.NextInt32(0, 5)];
                Int32 number = first * second * third;

                Decimal answer = (first + 1) * (second + 1) * (third + 1);
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"\text{{Если }}p_{{1}}, p_{{2}}, p_{{3}}\text{{ — простые числа, то сумма всех делителей числа }}p_{{1}}p_{{2}}p_{{3}}\\\text{{равна }}(p_{{1}} + 1)(p_{{2}} + 1)(p_{{3}} + 1)\\\text{{Найдите сумму делителей числа {number}.}}";

                return new CultureStrings(template);
            }

            public static Template GetSubTemplate5()
            {
                return new LatexTemplate(GetSubTemplate5, Info);
            }

            public static CultureStrings GetSubTemplate5(out IImmutableList<String> result)
            {
                Int32 d1 = RandomUtils.NextInt32(2, 15);
                Int32 d2 = RandomUtils.NextInt32(2, 15);

                Decimal answer = (d1 * d2 * 0.25M).Round(4);
                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(NumberFormatInfo.CurrentInfo), answer.ToString(NumberFormatInfo.InvariantInfo)).Distinct().ToImmutableArray();

                String template =
                    $@"\text{{Площадь четырёхугольника можно вычислить по формуле }}\\S = \frac{{{{d}}_{{1}}{{d}}_{{2}}sin\alpha}}{{2}}\\\text{{где }}{{d}}_{{1}}\text{{ и }}{{d}}_{{2}}\text{{ - длины диагоналей четырёхугольника, }}\\\alpha\text{{ - угол между диагоналями.}}\\\text{{Пользуясь этой формулой,}}\\\text{{найдите площадь S четырёхугольника}}\\\text{{если }}{{d}}_{{1}} = {d1}, {{d}}_{{2}} = {d2}\text{{, а }}sin\alpha = \frac{{1}}{{2}}.";

                return new CultureStrings(template);
            }
        }
    }
}