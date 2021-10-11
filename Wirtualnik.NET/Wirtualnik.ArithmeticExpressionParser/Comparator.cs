using System.Linq;

namespace Wirtualnik.ArithmeticExpressionParser
{
    // [ { cpu.first.TDP } > { 100 } ]
    public class Comparator
    {
        private ValueMember left;
        private ValueMember right;
        private ComparatorType comparatorType;
        private string value;
        private object expressionObject;

        public Comparator(string value, object expressionObject)
        {
            this.value = value;
            this.expressionObject = expressionObject;
        }

        public bool Evaluate()
        {
            InitComparator();
            return comparatorType switch
            {
                ComparatorType.EQUAL => left.Evaluate().Equals(right.Evaluate()),
                ComparatorType.BIGGER => (int)left.Evaluate() > (int)right.Evaluate(),
                ComparatorType.SMALLER => (int)left.Evaluate() < (int)right.Evaluate(),
                ComparatorType.NOTEQUAL => !left.Evaluate().Equals(right.Evaluate()),
                _ => false,
            };
        }

        private void InitComparator()
        {
            if (value.StartsAndEndWith("[", "]"))
            {
                value = value.RemoveFirstAndLast();
                var sides = value.SplitComparatorExpression(out comparatorType);
                left = new ValueMember(sides[0], expressionObject);
                right = new ValueMember(sides[1], expressionObject);
            }
        }
    }

    public enum ComparatorType
    {
        EQUAL,
        NOTEQUAL,
        BIGGER,
        SMALLER,
        ERROR
    }
}
