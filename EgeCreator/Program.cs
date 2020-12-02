// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using EgeCreator.Model;

namespace EgeCreator
{
    public static class Program
    {
        [STAThread]
        public static void Main(String[] args)
        {
            Initializer.Initialize(args);
        }
    }
}