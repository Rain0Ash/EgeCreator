// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using EgeCreator.Model.Common;
using NetExtender.Utils.Numerics;

namespace EgeCreator.Model.Generators.Math
{
    public partial class BasicMathTasks : Tasks<BasicMathTasks>
    {
        public override TimeSpan Time { get; } = TimeSpan.FromMinutes(2);

        public override IImmutableDictionary<Int32, Int32> Grade { get; } = MathUtils.Range(21)
            .Select(grade => new KeyValuePair<Int32, Int32>(grade, grade * 5))
            .ToImmutableDictionary();
        
        public BasicMathTasks()
            : base(SubjectType.MathBasic)
        {
        }
    }
}