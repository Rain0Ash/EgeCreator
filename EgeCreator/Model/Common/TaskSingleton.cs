// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using NetExtender.Types;
using NetExtender.Utils.Types;

namespace EgeCreator.Model.Common
{
    public abstract class TaskSingleton<T> : Singleton<T> where T : TaskSingleton<T>
    {
        public IImmutableList<TemplateGeneratorDelegate> Generators { get; }

        protected TaskSingleton()
        {
            Generators = Utils.GetGenerators<TemplateGeneratorDelegate>(typeof(T));
        }
        
        public Template GetRandomTemplate()
        {
            return Generators.GetRandom().Invoke();
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
    }
}