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

                Int32 red = RandomUtils.NextInt32(5, 30);
                Int32 yellow = RandomUtils.NextInt32(5, 30);
                Int32 green = RandomUtils.NextInt32(5, 30);

                Int32 answer = red + yellow + green - 3;

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, red, yellow, green));
            }
            
            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }
            
            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String ru = "На поверхности глобуса фломастером проведены {0} параллелей и {1} меридиана. На сколько частей проведённые линии разделили поверхность глобуса?\n\n*Меридиан — это дуга окружности, соединяющая Северный и Южный полюсы. Параллель — это окружность, лежащая в плоскости, параллельной плоскости экватора.";

                Int32 parallel = RandomUtils.NextInt32(5, 100);
                Int32 meridian = RandomUtils.NextInt32(5, 100);

                Int32 answer = (parallel + 1) * meridian;

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, parallel, meridian));
            }
            
            public static Template GetSubTemplate3()
            {
                return new TextTemplate(GetSubTemplate3, Info);
            }
            
            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                const String ru = "Хозяин договорился с рабочими, что они выкопают ему колодец на следующих условиях: за первый метр он заплатит им {0} рублей, а за каждый следующий метр — на {1} рублей больше, чем за предыдущий. Сколько рублей хозяин должен будет заплатить рабочим, если они выкопают колодец глубиной {2} метров?";

                Int32 first = RandomUtils.NextInt32(3000, 9000).RoundToMultiplier(50, RoundType.Ceil);
                Int32 next = RandomUtils.NextInt32(100, 3000).RoundToMultiplier(50, RoundType.Ceil);
                Int32 depth = RandomUtils.NextInt32(5, 20);

                Decimal answer = (2 * first + next * (depth - 1)) * depth / 2M;

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();
                
                return new CultureStrings(String.Format(ru, first, next, depth));
            }
        }
    }
}