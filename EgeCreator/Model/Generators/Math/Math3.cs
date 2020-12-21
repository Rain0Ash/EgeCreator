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
        public class Math3 : TaskSingleton<Math3>
        {
            private static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 3, 1);

            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }
            
            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String ru = "Призёрами городской олимпиады по математике стали {0} учащихся, что составило {1}% от числа участников. Сколько человек участвовало в олимпиаде?";

                Int32 percent = RandomUtils.NextInt32(1, 100);
                Int32 members = RandomUtils.NextInt32(1, 10) * percent;

                Decimal answer = members * 100M / percent;

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, members, percent));
            }

            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String ru = "Только {0} % из {1} выпускников города правильно решили задачу № 8. Сколько выпускников из этого города правильно решили задачу № 8?";

                Int32 percent = RandomUtils.NextInt32(1, 100);
                Int32 members = RandomUtils.NextInt32(10, 90) * 100;

                Decimal answer = members / 100 * percent;

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, percent, members));
            }

            public static Template GetSubTemplate3()
            {
                return new TextTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                const String ru = "В школе девочки составляют {0} % числа всех учащихся. Сколько в этой школе всего учащихся, если девочек в ней на {1} человек больше, чем мальчиков?";

                Int32 girls_percent = RandomUtils.NextInt32(1, 6) + 50;
                Int32 diff = RandomUtils.NextInt32(1, 20) * 6;

                Decimal answer = diff / (girls_percent / 100M - (100 - girls_percent) / 100M);

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, girls_percent, diff));
            }

            public static Template GetSubTemplate4()
            {
                return new TextTemplate(GetSubTemplate4, Info);
            }

            public static CultureStrings GetSubTemplate4(out IImmutableList<String> result)
            {
                const String ru = "Ежемесячная плата за телефон составляет {0} рублей. В следующем году она увеличится на {1}%. Сколько рублей будет составлять ежемесячная плата за телефон в следующем году?";

                Int32 current_price = RandomUtils.NextInt32(20, 50) * 10;
                Int32 percent = RandomUtils.NextInt32(1, 10) * 10;

                Decimal answer = current_price * (1 + percent / 100M);

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, current_price, percent));
            }

            public static Template GetSubTemplate5()
            {
                return new TextTemplate(GetSubTemplate5, Info);
            }

            public static CultureStrings GetSubTemplate5(out IImmutableList<String> result)
            {
                const String ru = "Футболка стоила {0} рублей. После снижения цены она стала стоить {1} рублей. На сколько процентов была снижена цена на футболку?";

                Int32 old_price = RandomUtils.NextInt32(40, 90) * 10;
                Int32 new_price = old_price - RandomUtils.NextInt32(10, old_price / 2) * 10;

                Decimal answer = (100 * (1 - (Decimal)new_price / old_price)).Round(4);

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, old_price, new_price));
            }
        }
    }
}