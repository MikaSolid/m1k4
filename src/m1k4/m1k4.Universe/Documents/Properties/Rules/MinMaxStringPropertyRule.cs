using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class MinMaxStringLengthPropertyRule : PropertyRule
    {
        public Int32 MinValue { get; set; }

        public Int32 MaxValue { get; set; }

        public override bool Validate(object value)
        {
            // not correct if unicode characters are used
            int numberOfCharacters = ((string)value).Length;

            return numberOfCharacters >= MinValue && numberOfCharacters <= MaxValue;
        }
    }
}
