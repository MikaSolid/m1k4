using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class IsRequiredRule : PropertyRule
    {
        public override bool Validate(object value)
        {
            if (value is string)
                return (!String.IsNullOrEmpty(value.ToString()) && value.ToString() != Constants.None);

            return value != null;
        }
    }
}