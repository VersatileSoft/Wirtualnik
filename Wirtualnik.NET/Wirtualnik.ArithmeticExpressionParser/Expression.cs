namespace Wirtualnik.ArithmeticExpressionParser
{
    public class Expression
    {
        private Expression leftSide;
        private Expression rightSide;
        private bool value;
        private BoolComparatorType type;
        private string stringValue;
        private object expressionObject;

        public Expression(string value, object expressionObject)
        {
            stringValue = value;
            this.expressionObject = expressionObject;
        }

        public bool Evaluate()
        {
            InitExpression();

            return type switch
            {
                BoolComparatorType.AND => leftSide.Evaluate() && rightSide.Evaluate(),
                BoolComparatorType.OR => leftSide.Evaluate() || rightSide.Evaluate(),
                BoolComparatorType.VALUE => value,
                _ => false
            };
        }

        private void InitExpression()
        {
            if (stringValue.StartsAndEndWith("(", ")"))
            {
                InitExpressionSides();
            }
            else if (stringValue.StartsAndEndWith("[", "]"))
            {
                InitExpressionValue();
            }
        }

        private void InitExpressionSides()
        {
            stringValue = stringValue.RemoveFirstAndLast();
            var index = stringValue.FindBoolComparatorTypeIndex();
            type = stringValue.GetBoolComparatorType(index);
            leftSide = new Expression(stringValue.ExpressionLeftSide(index), expressionObject);
            rightSide = new Expression(stringValue.ExpressionRightSide(index), expressionObject);
        }

        private void InitExpressionValue()
        {
            type = BoolComparatorType.VALUE;
            value = new Comparator(stringValue, expressionObject).Evaluate();
        }

        public static bool Evaluate(string value, object expressionObject)
        {
            return new Expression(value, expressionObject).Evaluate();
        }
    }

    public enum BoolComparatorType
    {
        AND,
        OR,
        VALUE,
        ERROR
    }
}
