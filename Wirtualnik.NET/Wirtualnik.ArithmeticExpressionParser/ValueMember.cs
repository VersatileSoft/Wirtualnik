using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wirtualnik.ArithmeticExpressionParser.Handlers;

namespace Wirtualnik.ArithmeticExpressionParser
{
    // { products.where( category.name = "cpu" ).first.TDP }
    // { products.where( category.name = "m.2").where(properties.where(categoryProperties.name = "interface").first.value = "sata").count }
    // { 100 }
    // { Products.where( [ { Category.Name } = { \"cpu\" } ] ).first.ProductProperties.where( [ { CategoryProperty.Name } = { \" socket \" } ] ).first.Value }
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
                    var res = EvaluateExp(value.SplitSteps().ConvertSteps().ToList(), expressionObject);
                    return (int.TryParse(res as string, out int resInt)) ? resInt : res;
                }
            }

            return new object();
        }

        private object EvaluateExp(List<Step> steps, object value)
        {
            var step = steps.FirstOrDefault();
            steps.RemoveAt(0);
            return steps.Count == 0 ? step.Handle(value) : EvaluateExp(steps, step.Handle(value));
        }
    }
}
