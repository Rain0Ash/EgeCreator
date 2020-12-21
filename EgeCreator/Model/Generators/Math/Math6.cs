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
        public class Math6 : TaskSingleton<Math6>
        {
            private static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 6, 1);

            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }
            
            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String ru = "Килограмм орехов стоит {0} рублей. Маша купила {1} г. орехов. Какую сумму она должна получить с {2} рублей в качестве сдачи?";
                
                Int32 price = RandomUtils.NextInt32(50, 150);
                Int32 weight = RandomUtils.NextInt32(8, 80) * 50;

                Decimal fullprice = price * weight / 1000M;

                Int32 money = (Int32) RandomUtils.NextDecimal(fullprice + 100, fullprice + 500).RoundToMultiplier(100, RoundType.Ceil);

                Decimal answer = money - fullprice;

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, price, weight, money));
            }
            
            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String ru = "Одного рулона обоев хватает для оклейки полосы от пола до потолка шириной {0} м. Сколько рулонов обоев нужно купить для оклейки прямоугольной комнаты размерами {1} м на {2} м?";

                Int32 roll = RandomUtils.NextInt32(2, 4);
                Int32 length = RandomUtils.NextInt32(8, 15);
                Int32 width = RandomUtils.NextInt32(8, 15);

                Decimal answer = System.Math.Ceiling(((length + width) * 2) / (decimal)roll);

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, roll, length, width));
            }

            public static Template GetSubTemplate3()
            {
                return new TextTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                const String ru = "В летнем лагере {0} детей и {1} воспитателей. В автобус помещается не более {2} пассажиров. Сколько автобусов требуется, чтобы перевезти всех из лагеря в город?";

                Int32 childs = RandomUtils.NextInt32(100, 400);
                Int32 adults = RandomUtils.NextInt32(20, 70);
                Int32 places = RandomUtils.NextInt32(30, 90);

                Decimal answer = System.Math.Ceiling((childs + adults) / (decimal)places);

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, childs, adults, places));
            }

            public static Template GetSubTemplate4()
            {
                return new TextTemplate(GetSubTemplate4, Info);
            }

            public static CultureStrings GetSubTemplate4(out IImmutableList<String> result)
            {
                const String ru = "В пачке {0} листов бумаги формата А4. За неделю в офисе расходуется {1} листов. Какого наименьшего количества пачек бумаги хватит на {2} недель?";

                Int32 pack = RandomUtils.NextInt32(1, 6) * 100;
                Int32 consum = RandomUtils.NextInt32(4, 8) * 100;
                Int32 weeks = RandomUtils.NextInt32(3, 10);

                Decimal answer = System.Math.Ceiling((consum * weeks) / (decimal)pack);

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, pack, consum, weeks));
            }

            public static Template GetSubTemplate5()
            {
                return new TextTemplate(GetSubTemplate5, Info);
            }

            public static CultureStrings GetSubTemplate5(out IImmutableList<String> result)
            {
                const String ru =
                    "1 киловатт-час электроэнергии стоит {0} рублей. Счетчик электроэнергии 1 июня показывал {1} киловатт-часов, а 1 июля показывал {2} киловатт-часов. Сколько рублей нужно заплатить за электроэнергию за июнь?";

                Decimal price = RandomUtils.NextDecimal(1, 3).Round(2);
                Int32 count0 = RandomUtils.NextInt32(10000, 15000);
                Int32 count = RandomUtils.NextInt32(100, 400) + count0;

                Decimal answer = System.Math.Ceiling((count - count0) * (decimal) price);

                result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                return new CultureStrings(String.Format(ru, price, count0, count));
            }
        }
    }
}