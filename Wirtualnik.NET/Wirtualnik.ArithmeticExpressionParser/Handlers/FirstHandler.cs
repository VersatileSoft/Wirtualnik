using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.ArithmeticExpressionParser.Handlers
{
    [Handler("first")]
    public class FirstHandler : IHandler
    {
        public object Handle(object value, string args, string stepName)
        {
            return value.AsList().FirstOrDefault();
        }
    }
}
