using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Wirtualnik.ArithmeticExpressionParser
{
    // { products.where( category.name = "cpu" ).first.TDP }
    // { products.where( category.name = "m.2").where(properties.where(categoryProperties.name = "interface").first.value = "sata").count }
    // { 100 }
    public class ValueMember
    {
        private string value;
        private object expressionObject;

        public ValueMember(string value, object expressionObject)
        {
            this.value = value;
            this.expressionObject = expressionObject;
        }

        public object Evaluate()
        {
            if (value.StartsAndEndWith("{", "}"))
            {
                value = value.RemoveFirstAndLast();

                if (value.StartsAndEndWith("\"", "\""))
                {
                    return value.RemoveFirstAndLast();
                }
                else if (int.TryParse(value, out int valueInt))
                {
                    return valueInt;
                }
                else
                {
                    // products.where( category.name = cpu ).first.TDP
                    // products.where( [ { category.name } = { m2 } ] ).where(properties.where(categoryProperties.name = "interface").first.value = { sata }).count
                    var res = EvaluateExp(value.SplitSteps().ToList(), expressionObject);
                    return (int.TryParse(res as string, out int resInt)) ? resInt : res;
                }
            }

            return new object();
        }

        private object EvaluateExp(List<string> steps, object value)
        {
            var step = steps.FirstOrDefault();
            steps.RemoveAt(0);

            if (step.StartsWith("where"))
            {
                var condition = step.Remove(0, 5).RemoveFirstAndLast();
                var sides = condition.Split("=");
                return EvaluateExp(steps, ((IEnumerable)value).Cast<object>().Where(v => new Comparator(condition, v).Evaluate()));
            }
            else if (step.Contains("first"))
            {
                var listValues = ((IEnumerable)value).Cast<object>().ToList();
                return steps.Count == 0 ? listValues.FirstOrDefault() : EvaluateExp(steps, listValues.FirstOrDefault());
            }
            else if (step.Contains("count"))
            {
                var listValues = ((IEnumerable)value).Cast<object>().ToList();
                return listValues.Count;
            }
            else
            {
                var newValue = value.GetType().GetProperty(step).GetValue(value);
                return steps.Count == 0 ? newValue : EvaluateExp(steps, newValue);
            }
        }
    }
}
