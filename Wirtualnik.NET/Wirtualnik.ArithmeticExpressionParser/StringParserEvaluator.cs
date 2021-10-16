using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.ArithmeticExpressionParser
{
    // Some text { Products.where( [ { Category.Name } = { \"cpu\" } ] ).first.Name } some other text { Products.where( [ { Category.Name } = { \"motherboard\" } ] ).first.Name }
    public class StringParserEvaluator
    {
        private string Value;
        private object Obj;
        public StringParserEvaluator(string value, object obj)
        {
            Obj = obj;
            Value = value;
        }


        public string Convert()
        {
            return ConvertInter(Value);
        }

        private string ConvertInter(string value)
        {
            var res = FindStartAndLen(value);
            if(res == (0, 0))
            {
                return value;
            }
            var toRepleace = value.Substring(res.Item1, res.Item2);
            var newValue = (string)(new ValueMember(toRepleace.Replace(" ", ""), Obj)).Evaluate();

            return ConvertInter(value.Replace(toRepleace, newValue));
        }

        public static string Evaluate(string value, object o)
        {
            return (new StringParserEvaluator(value, o)).Convert();
        }

        private static (int, int) FindStartAndLen(string value)
        {
            int depth = 0;
            int index = 0;
            int startIndex = 0;
            foreach (var n in value)
            {
                if (n == '{')
                {
                    if(depth == 0)
                        startIndex = index;
                    depth++;
                }

                if (n == '}')
                {
                    depth--;
                    if(depth == 0)
                    {
                        return (startIndex, index - startIndex + 1);
                    }
                }

                index++;
            }

            return (0, 0);
        }
    }
}
