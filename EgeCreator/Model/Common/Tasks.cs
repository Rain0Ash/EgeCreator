// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using EgeCreator.Model.Generators.Math;
using NetExtender.Types;
using NetExtender.Utils.Types;

namespace EgeCreator.Model.Common
{
    public abstract class Tasks<T> : Singleton<T> where T : Tasks<T>
    {
        public SubjectType Subject { get; }

        public abstract TimeSpan Time { get; }
        
        public abstract IImmutableDictionary<Int32, Int32> Grade { get; }
        
        public IImmutableList<IImmutableList<TemplateGeneratorDelegate>> Generators { get; }

        protected Tasks(SubjectType subject)
        {
            Subject = subject;
            Generators = Utils.GetSubjectGenerators<TemplateGeneratorDelegate>(GetType());
        }
        
        public Template GetRandomTemplate()
        {
            return Generators?.GetRandom()?.GetRandom()?.Invoke();
        }
        
        public IEnumerable<Template> GetRandomTemplate(Int32 count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            for (Int32 i = 0; i < count; i++)
            {
                yield return GetRandomTemplate();
            }
        }

        public IEnumerable<Template> CreateTest()
        {
            return Generators.Select(list => list.GetRandom()?.Invoke()).OrderBy(task => task?.Info.Number);
        }
    }

    public static class Tasks
    {
        public static Object Instance { get; }
        public static Object Generators { get; }

        internal static IDictionary<SubjectType, dynamic> Tests { get; } = new List<dynamic>
        {
            BasicMathTasks.Instance
        }.ToImmutableDictionary(item => (SubjectType) item.Subject, item => item);

        public static dynamic GetTasksBySubject(SubjectType subject)
        {
            return Tests.TryGetValue(subject, out dynamic value) ? value : null;
        }

        public static Tasks<T> GetTasksBySubject<T>(SubjectType subject) where T : Tasks<T>
        {
            return Tests.GetOrAdd(subject, () => Tasks<T>.Instance) as Tasks<T>;
        }
    }
}