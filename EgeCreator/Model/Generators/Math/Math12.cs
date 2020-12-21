// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using EgeCreator.Localizations;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;

namespace EgeCreator.Model.Generators.Math
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public partial class BasicMathTasks
    {
        public class Math12 : TaskSingleton<Math12>
        {
            private static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 12, 1);

            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String ru =
                    "Семья из {0} человек едет из Санкт-Петербурга в Вологду. Можно ехать поездом, а можно — на своей машине. Билет на поезд на одного человека стоит {1} рублей. Автомобиль расходует {2} литров бензина на 100 километров пути, расстояние по шоссе равно {3} км, а цена бензина равна {4} рублей за литр. Сколько рублей придется заплатить за наиболее дешевую поездку на {0}?(Ответ округлять до целых!)";

                Random random = new Random();

                Decimal pers = random.Next(1, 4);
                Decimal cost = random.Next(500, 1000);
                Decimal benz = random.Next(5, 15);
                Decimal rast = random.Next(500, 1000);
                Decimal fuel = random.Next(15, 30);


                Decimal p1 = pers * cost;
                Decimal p2 = System.Math.Round(benz * (rast / 100) * fuel, 0, MidpointRounding.ToEven);

                Decimal answer = System.Math.Min(p1, p2);

                List<String> list = new List<String>
                {
                    answer.GetString(CultureInfo.CurrentCulture),
                    answer.GetString(CultureInfo.InvariantCulture)
                };

                result = list.Distinct().ToImmutableArray();
                return new CultureStrings(String.Format(ru, pers, cost, benz, rast, fuel));
            }
            
            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String ru =
                    "При строительстве сельского дома можно использовать один из двух типов фундамента: каменный или бетонный. Для каменного фундамента необходимо {0} тонн природного камня и {1} мешков цемента. Для бетонного фундамента необходимо {2} тонн щебня и {3} мешков цемента. Тонна камня стоит {4} рублей, щебень стоит {5} рублей за тонну, а мешок цемента стоит {6} рублей. Сколько рублей будет стоить материал для фундамента, если выбрать наиболее дешевый вариант?";
                Random random = new Random();

                Decimal pen = random.Next(1, 5);
                Decimal mc1 = random.Next(1, 7);
                Decimal sh = random.Next(1, 5);
                Decimal mc2 = random.Next(15, 30);
                Decimal cost_pen = random.Next(2000, 3000);
                Decimal cost_sh = random.Next(500, 1000);
                Decimal cost_mc = random.Next(100, 500);

                Decimal p1 = pen * cost_pen + mc1 * cost_mc;
                Decimal p2 = sh * cost_sh + mc2 * cost_mc;

                Decimal answer = System.Math.Min(p1, p2);

                List<String> list = new List<String>
                {
                    answer.GetString(CultureInfo.CurrentCulture),
                    answer.GetString(CultureInfo.InvariantCulture)
                };

                result = list.Distinct().ToImmutableArray();
                return new CultureStrings(String.Format(ru, pen, mc1, sh, mc2, cost_pen, cost_sh, cost_mc));
            }
        }
    }
}