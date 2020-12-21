// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using EgeCreator.Localizations;
using EgeCreator.Model.Common;

namespace EgeCreator.Model.Generators.Math
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public partial class BasicMathTasks
    {
        public class Math9 : TaskSingleton<Math9>
        {
            protected static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 9, 1);

            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String ru =
                    "ВЕЛИЧИНЫ	 	              ВОЗМОЖНЫЕ ЗНАЧЕНИЯ" +
                    "\nА) скорость движения автомобиля             1) {0} м/мин" +
                    "\nБ) скорость движения пешехода           2) {1} км/час" +
                    "\nВ) скорость движения улитки             3) 330 м/сек" +
                    "\nГ) скорость звука в воздушной среде     4) {2} км/час";

                Random random = new Random();

                Double a = System.Math.Round(random.NextDouble() * random.Next(5, 7), 2, MidpointRounding.ToEven);
                Int32 b = random.Next(40, 80);
                Int32 c = random.Next(2, 5);

                const String answer = "2413";
                List<String> list = new List<String>
                {
                    answer
                };
                
                result = list.ToImmutableArray();
                return new CultureStrings(String.Format(ru, a, b, c));
            }

            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }

            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String ru =
                    "ВЕЛИЧИНЫ	 	              ВОЗМОЖНЫЕ ЗНАЧЕНИЯ" +
                    "\nА) масса куриного яйца                             1) {0} мг" +
                    "\nБ) масса детской коляски                        2) {1} кг" +
                    "\nВ) масса взрослого бегемота                   3) {2} г" +
                    "\nГ) масса активного вещества в таблетке      4) {3} т";

                Random random = new Random();

                Int32 a = random.Next(1, 10);
                Int32 b = random.Next(10, 20);
                Int32 c = random.Next(30, 65);
                Int32 d = random.Next(1, 5);

                const String answer = "3241";
                List<String> list = new List<String>
                {
                    answer
                };
                
                result = list.ToImmutableArray();
                return new CultureStrings(String.Format(ru, a, b, c, d));
            }

            public static Template GetSubTemplate3()
            {
                return new TextTemplate(GetSubTemplate3, Info);
            }

            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                const String ru =
                    "ВЕЛИЧИНЫ	 	                  ВОЗМОЖНЫЕ ЗНАЧЕНИЯ" +
                    "\nА) масса взрослого кита                       1) {0} кв. м" +
                    "\nБ) объём железнодорожного вагона        2) {1} т" +
                    "\nВ) площадь волейбольной площадки        3) {2} м" +
                    "\nГ) ширина футбольного поля                4) {3} м";

                Random random = new Random();

                Int32 a = random.Next(160, 165);
                Int32 b = random.Next(80, 105);
                Int32 c = random.Next(115, 125);
                Int32 d = random.Next(63, 72);

                const String answer = "2314";
                List<String> list = new List<String>
                {
                    answer
                };
                
                result = list.ToImmutableArray();
                return new CultureStrings(String.Format(ru, a, b, c, d));
            }
        }
    }
}