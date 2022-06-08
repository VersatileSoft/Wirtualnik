using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.ArithmeticExpressionParser.Handlers
{
    [Handler("where")]
    public class WhereHandler : IHandler
    {
        public object Handle(object value, string args, string stepName)
        {
            return value.AsList().Where(v => Comparator.Evaluate(args, v));
        }
    }
}