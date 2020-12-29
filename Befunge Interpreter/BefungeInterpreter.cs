﻿// <auto-generated />
// Refactor branch

namespace Befunge_Interpreter
{
    using System;
    using System.Collections.Generic;

    public class BefungeInterpreter
    {
        private char _currentDirection = '>';
        private Instruction _theInstruction;
        private Stack<int> _theStack;
        private string _theOutput;
        private bool _stringMode;

        public string Interpret(string code)
        {
            Initialize(code);

            while (true)
            {
                char currentChar = _theInstruction.CurrentChar;

                if (_stringMode)
                {
                    _theStack.Push(currentChar);
                    _theInstruction.Move(_currentDirection);
                    return _theStack.Peek().ToString();
                }
                else if (Char.IsDigit(currentChar))
                    _theStack.Push(currentChar - 48);
                else if (currentChar == '@')
                    break;

                switch (currentChar)
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '%':
                        var a = _theStack.Pop();
                        var b = _theStack.Pop();
                        using (var dt = new System.Data.DataTable())
                        {
                            var eval = currentChar == '/' && a == 0 ? 0 : (int)Math.Floor(Convert.ToDouble(dt.Compute($"{b}{currentChar}{a}", "")));
                            _theStack.Push(eval);
                        }
                        break;
                    case '`':
                        a = _theStack.Pop();
                        b = _theStack.Pop();
                        _theStack.Push(b > a ? 1 : 0);
                        break;
                    case '<':
                    case '^':
                    case '>':
                    case 'v':
                        _currentDirection = currentChar;
                        break;
                    case '?':
                        _currentDirection = new char[] { '<', '^', '>', 'v', }[new Random().Next(0, 3)];
                        break;
                    case '!':
                        a = _theStack.Pop();
                        _theStack.Push(a == 0 ? 1 : 0);
                        break;
                    case '_':
                        if (_theStack.Pop() == 0)
                            _currentDirection = '>';
                        else
                            _currentDirection = '<';
                        break;
                    case '|':
                        if (_theStack.Pop() == 0)
                            _currentDirection = 'v';
                        else
                            _currentDirection = '^';
                        break;
                    case '"':
                        _stringMode = true;
                        _theInstruction.Move(_currentDirection);
                        do
                        {
                            Interpret(code);
                        } while (_theInstruction.CurrentChar != '"');
                        _stringMode = false;
                        break;
                    case ':':
                        if (_theStack.Count == 0)
                            _theStack.Push(0);
                        else
                            _theStack.Push(_theStack.Peek());
                        break;
                    case '$':
                        _theStack.Pop();
                        break;
                    case '\\':
                        b = _theStack.Pop();
                        a = _theStack.Pop();
                        _theStack.Push(b);
                        _theStack.Push(a);
                        break;
                    case '.':
                        _theOutput += _theStack.Pop().ToString();
                        break;
                    case ',':
                        _theOutput += ((char)_theStack.Pop()).ToString();
                        break;
                    case '#':
                        _theInstruction.Move(_currentDirection);
                        break;
                    case 'p':
                        var y = _theStack.Pop();
                        var x = _theStack.Pop();
                        var v = _theStack.Pop();
                        _theInstruction.SetCharAtPoint(y, x, (char)v);
                        break;
                    case 'g':
                        y = _theStack.Pop();
                        x = _theStack.Pop();
                        _theStack.Push((char)_theInstruction.GetCharAtPoint(y, x));
                        break;
                    default:
                        break;
                }
                _theInstruction.Move(_currentDirection);
            }
            return _theOutput;
        }
        private void Initialize(string code)
        {
            _theInstruction = _theInstruction ?? new Instruction(code);
            _theStack = _theStack ?? new Stack<int>();
        }
    }

    public class Instruction
    {
        private string[] _array;
        private int _currentRow;
        private int _currentColumn;
        public Instruction(string code)
        {
            _array = code.Split('\n');
            _currentRow = 0;
            _currentColumn = 0;
        }
        public char CurrentChar => _array[_currentRow][_currentColumn];
        public char GetCharAtPoint(int row, int column) => _array[row][column];
        public void SetCharAtPoint(int row, int column, char value)
        {
            var sb = new System.Text.StringBuilder(_array[row]);
            sb.Remove(column, 1);
            sb.Insert(column, value);
            _array[row] = sb.ToString();
        }
        public void Move(char currentDirection)
        {
            if (currentDirection == '<')
                _currentColumn--;
            else if (currentDirection == '^')
                _currentRow--;
            else if (currentDirection == '>')
                _currentColumn++;
            else if (currentDirection == 'v')
                _currentRow++;
        }
    }
}