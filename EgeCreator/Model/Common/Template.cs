// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using EgeCreator.Localizations;
using NetExtender.Types.Numerics;

namespace EgeCreator.Model.Common
{
    public delegate T GeneratorDelegate<out T>(out IImmutableList<String> result);
    public delegate CultureStrings TextGeneratorDelegate(out IImmutableList<String> result);
    public delegate CultureStrings LatexGeneratorDelegate(out IImmutableList<String> result);
    public delegate Image ImageGeneratorDelegate(out IImmutableList<String> result);
    public delegate IEnumerable<DoublePoint> GraphicGeneratorDelegate(out IImmutableList<String> result);
    
    public delegate Template TemplateGeneratorDelegate();

    public enum TemplateType
    {
        Text,
        Latex,
        Image,
        Graphic
    }
    
    public readonly struct TemplateInfo
    {
        public SubjectType Subject { get; }
        public Byte Number { get; }
        
        public Byte Grade { get; }
        
        public TemplateInfo(SubjectType subject, Byte number, Byte grade)
        {
            Subject = subject;
            Number = number;
            Grade = grade;
        }
    }

    public abstract record Template
    {
        public IImmutableList<String> Result { get; protected init; }
        public TemplateInfo Info { get; protected init; }
        public TemplateType Type { get; protected init; }
    }
    
    public abstract record Template<T> : Template
    {
        public T FullTemplate { get; }

        protected Template(GeneratorDelegate<T> generator, TemplateInfo info, TemplateType type)
        {
            FullTemplate = generator.Invoke(out IImmutableList<String> result);
            Result = result;
            Info = info;
            Type = type;
        }
    }

    public record TextTemplate : Template<CultureStrings>
    {
        public TextTemplate(TextGeneratorDelegate generator, TemplateInfo info)
            : base(generator.Invoke, info, TemplateType.Text)
        {
        }
    }
    
    public record LatexTemplate : Template<CultureStrings>
    {
        public LatexTemplate(LatexGeneratorDelegate generator, TemplateInfo info)
            : base(generator.Invoke, info, TemplateType.Latex)
        {
        }
    }
    
    public record ImageTemplate : Template<Image>
    {
        public ImageTemplate(ImageGeneratorDelegate generator, TemplateInfo info)
            : base(generator.Invoke, info, TemplateType.Image)
        {
        }
    }
    
    public record GraphicTemplate : Template<IEnumerable<DoublePoint>>
    {
        public GraphicTemplate(GraphicGeneratorDelegate generator, TemplateInfo info)
            : base(generator.Invoke, info, TemplateType.Graphic)
        {
        }
    }
}