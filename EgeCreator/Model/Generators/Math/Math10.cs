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
        public class Math10 : TaskSingleton<Math10>
        {
            protected static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 10, 1);

            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String ru =
                    " В фирме такси в данный момент свободно {3} : {0} зеленых, {1} красных, {2} жёлтых. По вызову выехала одна из машин, случайно оказавшаяся ближе всего к заказчице. Найдите вероятность того, что к ней приедет {4} такси. (Ответ округлять до сотых!)";

                Random random = new Random();

                Decimal red = random.Next(1, 10);
                Decimal green = random.Next(1, 10);
                Decimal yellow = random.Next(1, 10);
                Int32 r = random.Next(1, 3);

                Decimal all = red + green + yellow;
                Decimal answer = System.Math.Round(red / all, 2, MidpointRounding.ToEven);

                String b = String.Empty;

                switch (r)
                {
                    case 1:
                        b = "красное";
                        answer = System.Math.Round(red / all, 2, MidpointRounding.ToEven);
                        break;
                    case 2:
                        b = "зеленое";
                        answer = System.Math.Round(green / all, 2, MidpointRounding.ToEven);
                        break;
                    case 3:
                        b = "жёлтое";
                        answer = System.Math.Round(yellow / all, 2, MidpointRounding.ToEven);
                        break;
                }

                List<String> list = new List<String>
                {
                    answer.GetString(CultureInfo.CurrentCulture),
                    answer.GetString()
                };

                result = list.Distinct().ToImmutableArray();
                return new CultureStrings(String.Format(ru, red, green, yellow, all, b));
            }

            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String ru =
                    "На экзамен вынесено {0} вопросов, Андрей не выучил {1} из них. Найдите вероятность того, что ему попадется выученный вопрос. (Ответ округлять до сотых!)";

                Random random = new Random();

                Decimal all = random.Next(30, 100);
                Decimal know = random.Next(1, 25);

                Decimal answer = System.Math.Round(know / all, 2, MidpointRounding.ToEven);

                List<String> list = new List<String>
                {
                    answer.GetString(CultureInfo.CurrentCulture),
                    answer.GetString()
                };

                result = list.Distinct().ToImmutableArray();
                return new CultureStrings(String.Format(ru, all, know));
            }

            public static String GetSubTemplate3(out IImmutableList<String> result)
            {
                const String ru =
                    "На тарелке {3} пирожков: {0} с рыбой, {1} с вареньем и {2} с вишней. Юля наугад выбирает один пирожок. Найдите вероятность того, что он окажется с {4}. (Ответ округлять до сотых!)";

                Random random = new Random();

                Decimal fish = random.Next(1, 13);
                Decimal jam = random.Next(1, 13);
                Decimal cherry = random.Next(1, 13);
                Decimal all = fish + jam + cherry;
                Decimal r = random.Next(1, 3);

                Decimal answer = 0;
                String b = String.Empty;

                switch (r)
                {
                    case 1:
                        b = "рыбой";
                        answer = System.Math.Round(fish / all, 2, MidpointRounding.ToEven);
                        break;
                    case 2:
                        b = "вареньем";
                        answer = System.Math.Round(jam / all, 2, MidpointRounding.ToEven);
                        break;
                    case 3:
                        b = "вишней";
                        answer = System.Math.Round(cherry / all, 2, MidpointRounding.ToEven);
                        break;
                }
                
                List<String> list = new List<String>
                {
                    answer.ToString(CultureInfo.CurrentCulture),
                    answer.ToString(CultureInfo.InvariantCulture)
                };

                result = list.Distinct().ToImmutableArray();
                return String.Format(ru, fish, jam, cherry, all, b);
            }
        }
    }
}