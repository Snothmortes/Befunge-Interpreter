using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Befunge_Interpreter
{
    static class Program
    {
        static void Main(string[] args)
        {
            new BefungeInterpreter().Interpret(">987v>.v\nv456<  :\n>321 ^ _@");
        }
    }
}
