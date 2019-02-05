using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public abstract class MinMaxPropertyItem<T> : PropertyItem
    {
        protected MinMaxPropertyItem(Property property)
            : base(property)
        {
        }

        public T MinValue { get; set; }

        public T MaxValue { get; set; }
    }

}
