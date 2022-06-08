using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.ArithmeticExpressionParser.Handlers
{
    public interface IHandler
    {
        object Handle(object value, string args, string stepName);
    }
}