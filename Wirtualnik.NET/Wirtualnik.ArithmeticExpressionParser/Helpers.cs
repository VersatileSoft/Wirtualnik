using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Wirtualnik.ArithmeticExpressionParser.Handlers;

namespace Wirtualnik.ArithmeticExpressionParser
{
    public static class Helpers
    {
        public static int FindBoolComparatorTypeIndex(this string value)
        {
            int depth = 0;
            int index = 0;
            foreach (var n in value)
            {
                if (n == '(' || n == '[')
                    depth++;
                if (n == ')' || n == ']')
                    depth--;

                index++;

                if (depth == 0)
                {
                    return index;
                }
            }

            return 0;
        }

        public static string RemoveFirstAndLast(this string value)
        {
            return value.Remove(0, 1).Remove(value.Length - 2);
        }

        public static BoolComparatorType GetBoolComparatorType(this string value, int index)
        {
            return value[index] switch
            {
                '|' => BoolComparatorType.OR,
                '&' => BoolComparatorType.AND,
                _ => BoolComparatorType.ERROR,
            };
        }

        public static bool StartsAndEndWith(this string value, string starts, string ends)
        {
            return value.StartsWith(starts) && value.EndsWith(ends);
        }

        public static string ExpressionLeftSide(this string value, int index)
        {
            return value.Substring(0, index);
        }
        public static string ExpressionRightSide(this string value, int index)
        {
            return value.Substring(index + 1, value.Length - index - 1);
        }

        public static string[] SplitComparatorExpression(this string value, out ComparatorType comparatorType)
        {
            // [ { ProductProperties.where( [ { CategoryProperty.Name } = { \"interface\" } ] ).first.Value } = { \"sata\" } ]

            int index = 0;
            int depth = 0;

            foreach (var val in value)
            {
                if (val == '(' || val == '[' || val == '{')
                {
                    depth++;
                }

                if (val == ')' || val == ']' || val == '}')
                {
                    depth--;
                }

                if (val == '=' && depth == 0)
                {
                    comparatorType = ComparatorType.EQUAL;
                    return value.Split(index);
                }

                if (val == '!' && depth == 0)
                {
                    comparatorType = ComparatorType.NOTEQUAL;
                    return value.Split(index);
                }

                if (val == '>' && depth == 0)
                {
                    comparatorType = ComparatorType.BIGGER;
                    return value.Split(index);
                }

                if (val == '<' && depth == 0)
                {
                    comparatorType = ComparatorType.SMALLER;
                    return value.Split(index);
                }

                index++;
            }

            comparatorType = ComparatorType.ERROR;
            return null;
        }

        public static string[] SplitSteps(this string value)
        {
            var result = new List<string>();
            if (!value.Contains("."))
            {
                result.Add(value);
                return result.ToArray();
            }
            int index = 0;
            int depth = 0;
            foreach (var val in value)
            {
                if (val == '(' || val == '[' || val == '{')
                {
                    depth++;
                }

                if (val == ')' || val == ']' || val == '}')
                {
                    depth--;
                }

                if (val == '.' && depth == 0)
                {
                    result.Add(String.Concat(value.Take(index)));
                    result.AddRange(SplitSteps(value.Remove(0, index + 1)));
                    return result.ToArray();
                }

                index++;
            }
            return result.ToArray();
        }

        public static Step[] ConvertSteps(this string[] steps)
        {
            return steps.Select(s => new Step(s)).ToArray();
        }

        public static string[] Split(this string value, int index)
        {
            return new string[] { value.Substring(0, index), value.Substring(index + 1, value.Length - index - 1) };
        }

        public static IHandler FindHandler(string name)
        {
            var res = typeof(IHandler).Assembly.GetTypes()
                .FirstOrDefault(p => typeof(IHandler).IsAssignableFrom(p) && !p.IsAbstract && p.GetCustomAttribute<HandlerAttribute>().Name == name);
            return res != null ? (IHandler)Activator.CreateInstance(res) : new ValueHandler();
        }

        public static string GetArgs(this string value, out string name)
        {
            var index = value.IndexOf('(');
            name = value.Remove(index, value.Length - index);
            return value.Substring(index).RemoveFirstAndLast();
        }

        public static List<object> AsList(this object value)
        {
            return ((IEnumerable)value).Cast<object>().ToList();
        }
    }
}