using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.Documents
{
    public class StringSlice : Slice
    {
        private StringSliceMethod _stringSliceMethod = StringSliceMethod.Contains;

        internal StringSlice(PropertyItem propertyValue)
            : base(propertyValue)
        {
        }

        public StringSliceMethod StringSliceMethod
        {
            get { return _stringSliceMethod; }
            set { _stringSliceMethod = value; }
        }
    }

    public enum StringSliceMethod
    {
        Contains,
        StartsWith
    }
}
