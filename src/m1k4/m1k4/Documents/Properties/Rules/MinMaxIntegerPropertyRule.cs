using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class MinMaxIntegerPropertyRule : PropertyRule
    {
        public Int32 MinValue { get; set; }

        public Int32 MaxValue { get; set; }

        public override bool Validate(object value)
        {
            Int32 valueToCompare = Convert.ToInt32(value);

            return valueToCompare >= MinValue && valueToCompare <= MaxValue;
        }
    }
}
