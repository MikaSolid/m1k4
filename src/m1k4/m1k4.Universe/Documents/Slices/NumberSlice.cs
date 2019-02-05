using System;


namespace m1k4.Model.Documents
{
    public class NumberSlice : Slice
    {
        internal NumberSlice(PropertyItem propertyValue)
            : base(propertyValue)
        {
        }

        public double StartValue { get; set; }

        public double EndValue { get; set; }

        public string StartValueString
        {
            get
            {
                return StartValue.ToString(); //.ToEngineeringNotation();
            }
        }

        public string EndValueString
        {
            get
            {
                if (StartValue == EndValue)
                    return String.Empty;

                return EndValue > 0 ? String.Format(" - {0}", EndValue.ToString()) : String.Empty; // .ToEngineeringNotation()) : String.Empty;
            }
        }
    }
}
