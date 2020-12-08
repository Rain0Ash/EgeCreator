// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using EgeCreator.Localizations;
using NetExtender.Utils.Numerics;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;
using EgeCreator.Model.Options;

namespace EgeCreator.Model.Generators.Math
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public partial class BasicMathTasks
    {
        public class Math19 : TaskSingleton<Math19>
        {
            private static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 19, 1);

            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                while (true)
                {
                    const String ru = "Найдите четырёхзначное число, кратное {0}, произведение цифр которого равно {1}. В ответе укажите какое-нибудь одно такое число.";

                    Int32 multiple = RandomUtils.NextInt32(5, 30);
                    Int32 chars = RandomUtils.NextInt32(10, 30);

                    List<Int32> values = new List<Int32>();

                    for (Int32 i = 1000; i < 10000; i++)
                    {
                        if (i % multiple != 0)
                        {
                            continue;
                        }

                        if (i.ToString().Select(chr => Int32.Parse(chr.ToString())).Multiply() == chars)
                        {
                            values.Add(i);
                        }
                    }

                    if (values.Count <= 0)
                    {
                        continue;
                    }

                    result = values.Select(value => value.ToString()).ToImmutableArray();

                    return new CultureStrings(String.Format(ru, multiple, chars));
                }
            }

            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }
            
            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                Int32 count = 0;
                while (count++ < 30)
                {
                    Boolean ismin = RandomUtils.NextBoolean();
                    Byte numbers = RandomUtils.NextByte(4, 6);
                    
                    String ru = $"Найдите {(ismin ? "наименьшее" : "наибольшее")} {numbers} значное число, кратное {{0}}, произведение цифр которого больше {{1}}, но меньше {{2}}.";

                    Int32 multiple = RandomUtils.NextInt32(5, 200);
                    Int32 downbound = RandomUtils.NextInt32(30, 70);
                    Int32 upbound = RandomUtils.NextInt32(downbound, 100);

                    Boolean Valid(Int32 i)
                    {
                        return i.ToString().Select(chr => Int32.Parse(chr.ToString())).Multiply().InRange(downbound, upbound, MathPositionType.None);
                    }

                    Int32 max = 10.Pow(numbers);
                    Int32 min = 10.Pow((Byte)(numbers - 1));

                    IEnumerable<Int32> range = ismin ? MathUtils.Range(min, max) : MathUtils.Range(max, min, -1);

                    Int32 answer = range.Where(i => i % multiple == 0).FirstOrDefault(Valid);

                    if (answer == 0)
                    {
                        continue;
                    }

                    result = EnumerableUtils.GetEnumerableFrom(answer.ToString(CultureInfo.CurrentCulture), answer.ToString(CultureInfo.InvariantCulture)).Distinct().ToImmutableArray();

                    return new CultureStrings(String.Format(ru, multiple, downbound, upbound));
                }
                
                result = ImmutableArray<String>.Empty;
                return Globals.Localization.Error;
            }
            
            public static Template GetSubTemplate3()
            {
                return new TextTemplate(GetSubTemplate3, Info);
            }
            
            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                Int32 count = 0;
                while (count++ < 30)
                {
                    Byte numbers = RandomUtils.NextByte(4, 6);
                    
                    String ru = $"Найдите {numbers} значное число, которое делится на {{0}} и сумма цифр которого больше {{1}}, но меньше {{2}}. В ответе укажите какое-нибудь одно такое число.";

                    Int32 multiple = RandomUtils.NextInt32(5, 200);
                    Int32 downbound = RandomUtils.NextInt32(30, 70);
                    Int32 upbound = RandomUtils.NextInt32(downbound, 100);

                    Int32 max = 10.Pow(numbers);
                    Int32 min = 10.Pow((Byte)(numbers - 1));
                    
                    Boolean Valid(Int32 i)
                    {
                        return i % multiple == 0 && i.ToString().Select(chr => Int32.Parse(chr.ToString())).Sum().InRange(downbound, upbound);
                    }

                    result = MathUtils.Range(min, max)
                        .Where(Valid)
                        .Select(value => value.ToString()).ToImmutableList();

                    if (result.Count <= 0)
                    {
                        continue;
                    }

                    return new CultureStrings(String.Format(ru, multiple, downbound, upbound));
                }
                
                result = ImmutableArray<String>.Empty;
                return Globals.Localization.Error;
            }
        }
    }
}