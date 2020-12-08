// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using EgeCreator.Localizations;
using NetExtender.Utils.Types;
using EgeCreator.Model.Common;

namespace EgeCreator.Model.Generators.Math
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public partial class BasicMathTasks
    {
        public class Math18 : TaskSingleton<Math18>
        {
            protected static TemplateInfo Info { get; } = new TemplateInfo(BasicMathTasks.Instance.Subject, 18, 1);
            
            public static Template GetSubTemplate1()
            {
                return new TextTemplate(GetSubTemplate1, Info);
            }

            public static CultureStrings GetSubTemplate1(out IImmutableList<String> result)
            {
                const String template = "Школа приобрела стол, доску, магнитофон и принтер. Известно, что принтер дороже магнитофона, а доска дешевле магнитофона и дешевле стола. Выберите утверждения, которые верны при указанных условиях." +
                                        "\n1) Магнитофон дешевле доски." +
                                        "\n2) Принтер дороже доски." +
                                        "\n3) Доска — самая дешёвая из покупок." +
                                        "\n4) Принтер и доска стоят одинаково." +
                                        "\nВ ответе запишите номера выбранных утверждений без пробелов, запятых и других дополнительных символов.";

                result = EnumerableUtils.GetEnumerableFrom("23").ToImmutableArray();
                return new CultureStrings(template);
            }
            
            public static Template GetSubTemplate2()
            {
                return new TextTemplate(GetSubTemplate2, Info);
            }
            
            public static CultureStrings GetSubTemplate2(out IImmutableList<String> result)
            {
                const String template = "Когда какая-нибудь кошка идёт по забору, пёс Шарик, живущий в будке возле дома, обязательно лает. Выберите утверждения, которые верны при приведённом условии." +
                                        "\n1) Если Шарик не лает, значит, по забору идёт кошка." +
                                        "\n2) Если Шарик молчит, значит, кошка по забору не идёт." +
                                        "\n3) Если по забору идёт чёрная кошка, Шарик не лает." +
                                        "\n4) Если по забору пойдёт белая кошка, Шарик будет лаять." +
                                        "\nВ ответе запишите номера выбранных утверждений без пробелов, запятых и других дополнительных символов.";

                result = EnumerableUtils.GetEnumerableFrom("24").ToImmutableArray();
                return new CultureStrings(template);
            }
            
            public static Template GetSubTemplate3()
            {
                return new TextTemplate(GetSubTemplate3, Info);
            }
            
            public static CultureStrings GetSubTemplate3(out IImmutableList<String> result)
            {
                const String template = "Известно, что Витя выше Коли, Маша выше Ани, а Саша ниже и Коли, и Маши. Выберите утверждения, которые следуют из приведённых данных." +
                                        "\n1) Витя выше Саши." +
                                        "\n2) Саша ниже Ани." +
                                        "\n3) Коля и Маша одного роста." +
                                        "\n4) Витя самый высокий из всех." +
                                        "\nВ ответе запишите номера выбранных утверждений без пробелов, запятых и других дополнительных символов.";

                result = EnumerableUtils.GetEnumerableFrom("1").ToImmutableArray();
                return new CultureStrings(template);
            }
        }
    }
}