﻿// <auto-generated />

namespace Befunge_Interpreter.Tests
{
    using NUnit.Framework;
    using Befunge_Interpreter;
    using System;
    using System.Linq;
    [TestFixture()]
    public class BefungeInterpreterTests
    {
        [TestCase(">42+3..@", "36")]
        [TestCase(">24+3..@", "36")]
        [TestCase(">21-3..@", "31")]
        [TestCase(">12-3..@", "3-1")]
        [TestCase(">24*3..@", "38")]
        [TestCase(">42*3..@", "38")]
        [TestCase(">42/3..@", "32")]
        [TestCase(">40/3..@", "30")]
        [TestCase(">42%3..@", "30")]
        public void Interpret_ShouldInterpretArithmetics(string input, string expected)
        {
            var actual = new BefungeInterpreter().Interpret(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(">21`.@", "1")]
        [TestCase(">12`.@", "0")]
        public void Interpret_ShouldInterpretGreaterThan(string input, string expected)
        {
            var actual = new BefungeInterpreter().Interpret(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(">0!.@", "1")]
        [TestCase(">1!.@", "0")]
        public void Interpret_ShouldInterpretLogicalNot(string input, string expected)
        {
            var actual = new BefungeInterpreter().Interpret(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(">123...@", "321")]
        public void Interpret_ShouldInterpretDigits(string input, string expected)
        {
            var actual = new BefungeInterpreter().Interpret(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(">\"!dlroW olleH\",,,,,,,,,,,,@", "Hello World!")]
        public void Interpret_ShouldInterpretStrings(string input, string expected)
        {
            var actual = new BefungeInterpreter().Interpret(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(">987v>.v\n" +
                  "v456<  :\n" +
                  ">321 ^ _@", "123456789")]
        public void Interpret_ShouldInterpretLoops(string input, string expected)
        {
            var actual = new BefungeInterpreter().Interpret(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(" >987v>.v\n" +
                  "v4#56<  :\n" +
                  ">321  ^ _@", "12356789")]
        public void Interpret_ShouldInterpretSkips(string input, string expected)
        {
            var actual = new BefungeInterpreter().Interpret(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(" >987v>.v\n" +
                  "v4\\56<  :\n" +
                  ">321  ^ _@", "123465789")]
        public void Interpret_ShouldInterpretSwaps(string input, string expected)
        {
            var actual = new BefungeInterpreter().Interpret(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(" >987v>.v\n" +
                  "v4$56<  :\n" +
                  ">321  ^ _@", "12346789")]
        public void Interpret_ShouldInterpretDiscards(string input, string expected)
        {
            var actual = new BefungeInterpreter().Interpret(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("v>>>>>v\n" +
                  " 12345 \n" +
                  " ^?^   \n" +
                  "> ? ?^ \n" +
                  " v?v   \n" +
                  " 6789  \n" +
                  " >>>> v\n" +
                  "     v<\n" +
                  "    > |\n" +
                  "    : @\n" +
                  "^    .<\n" +
                  "    ^<")]
        public void Interpret_ShouldInterpretPipeAndRandom(string input)
        {
            var actual = (new BefungeInterpreter()).Interpret(input);
            Assert.That(actual, Is.TypeOf(typeof(string)));
             actual = (new BefungeInterpreter()).Interpret(input);
            Assert.That(actual, Is.TypeOf(typeof(string)));
        }

        [TestCase(">532p32g.   @\n" +
                  "             \n" +
                  "   b         ", "5")]
        public void Interpret_ShouldInterpretPutAndGet(string input, string expected)
        {
            var actual = new BefungeInterpreter().Interpret(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Interpret_ShouldPassSimpleCodewarsTest()
        {
            Assert.AreEqual(
                    "123456789",
                    new BefungeInterpreter().Interpret(">987v>.v\nv456<  :\n>321 ^ _@"));
        }

        [Test]
        public void Interpret_ShouldPassQuineCodewarsTest()
        {
            Assert.AreEqual(
                    "01->1# +# :# 0# g# ,# :# 5# 8# *# 4# +# -# _@",
                    new BefungeInterpreter().Interpret("01->1# +# :# 0# g# ,# :# 5# 8# *# 4# +# -# _@"));
        }
    }
}