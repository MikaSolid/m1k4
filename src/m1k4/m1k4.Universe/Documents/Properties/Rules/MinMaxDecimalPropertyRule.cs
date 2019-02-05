using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class MinMaxDecimalPropertyRule : PropertyRule
    {
        public Decimal MinValue { get; set; }

        public Decimal MaxValue { get; set; }

        public override bool Validate(object value)
        {
            Decimal valueToCompare = Convert.ToDecimal(value);

            return valueToCompare >= MinValue && valueToCompare <= MaxValue;
        }
    }

}
