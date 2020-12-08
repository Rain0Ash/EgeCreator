// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using NetExtender.Utils.Core;
using NetExtender.Utils.Types;

namespace EgeCreator.Model.Common
{
    [SuppressMessage("ReSharper", "VariableHidesOuterVariable")]
    public static class Utils
    {
        public static Boolean IsTextGeneratorDelegate(this MethodInfo info)
        {
            const String name = "GetSubTemplate";
            return info.Name.StartsWith(name);
        }

        // Вы ничего не видели
        public static IImmutableList<T> GetGenerators<T>(Type type) where T : Delegate
        {
            return type
                .GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
                .TryParseWhere<MethodInfo, T>(IsTextGeneratorDelegate, ReflectionUtils.TryGetDelegate)
                .ToImmutableList();
        }
        
        // а это - тем более!
        // Загадка от Жака Фреско. Объясните что делает этот код. На размышление дается 30 минут.
        public static IImmutableList<IImmutableList<T>> GetSubjectGenerators<T>(Type type) where T : Delegate
        {
            return type.GetNestedTypes()
                .SelectWhere(type => type.IsClass,
                    type => type.GetProperty(nameof(Tasks.Instance), BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)
                        ?.GetValue(type))
                .Select(type => type?.GetType()?.GetProperty(nameof(Tasks.Generators),
                    BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)?.GetValue(type))
                .Select(gen => gen as IImmutableList<T>)
                .Where(gen => gen is not null)
                .ToImmutableList();
        }
    }
}