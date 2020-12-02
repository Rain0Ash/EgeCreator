// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using EgeCreator.Localizations;
using NetExtender.Utils.Numerics;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;
using NetExtender.Utils.Core;

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
        }
    }
}