using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model
{
    public class GeographicBoundary
    {

        private int _id;
        private string _geoCode;
        private string _name;
        private string _abbrevation;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string GeoCode
        {
            get { return _geoCode; }
            set { _geoCode = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Abbrevation
        {
            get { return _abbrevation; }
            set { _abbrevation = value; }
        }
    }
}