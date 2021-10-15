using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.ArithmeticExpressionParser.Handlers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HandlerAttribute : Attribute
    {
        public string Name { get; set; }
        public HandlerAttribute(string name)
        {
            Name = name;
        }
    }
}
