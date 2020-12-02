// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NetExtender.Localizations;

namespace EgeCreator.Localizations
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "NotAccessedField.Local")]
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
    public sealed class CultureStrings : LocaleStrings
    {
        public override ImmutableArray<Int32> AvailableLocalization { get; } = new[] {"EN", "RU"}
            .Select(code => GetLCID(code.ToLower()))
            .ToImmutableArray();

        private static readonly Int32 EN = GetLCID("en");
        
        public String en
        {
            get
            {
                return ToString(EN);
            }
            private set
            {
                Languages[EN] = value;
            }
        }
        
        private static readonly Int32 RU = GetLCID("ru");

        public String ru
        {
            get
            {
                return ToString(RU);
            }
            private set
            {
                Languages[RU] = value;
            }
        }

        private static readonly Int32 DE = GetLCID("de");

        public String de
        {
            get
            {
                return ToString(DE);
            }
            private set
            {
                Languages[DE] = value;
            }
        }

        public CultureStrings()
            : this(null)
        {
        }

        public CultureStrings(String english, String russian = null, String deutch = null)
            : base(english)
        {
            ru = russian;
            de = deutch;
        }
    }
}