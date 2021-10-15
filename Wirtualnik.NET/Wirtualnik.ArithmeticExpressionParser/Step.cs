using Wirtualnik.ArithmeticExpressionParser.Handlers;

namespace Wirtualnik.ArithmeticExpressionParser
{
    public class Step
    {
        private string value;
        private string args;
        private string name;
        private IHandler handler;

        public Step(string stepName)
        {
            this.value = stepName;

            if (value.Contains("("))
            {
                args = value.GetArgs(out name);
            }
            else
            {
                name = stepName;
            }

            handler = Helpers.FindHandler(name);
        }

        public object Handle(object value)
        {
            return handler.Handle(value, args, name);
        }
    }
}
