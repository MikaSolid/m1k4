using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public abstract class PropertyRule
    {
        public string Name { get; set; }

        public PropertyRuleType PropertyRuleType { get; set; }

        public abstract bool Validate(object value);
    }
}
