using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// using Sdd;

namespace m1k4.Model.Documents
{
    public class DateSlice : Slice
    {
        private DateTime _startDate;

        internal DateSlice(PropertyItem propertyValue)
            : base(propertyValue)
        {
        }

        // public DateGranularity Granularity { get; set; }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate { get; set; }

        public string DateString { get { return StartDate.ToString(); } } //GetDateString(Granularity); } }
    }
}
