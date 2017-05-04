using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model.ContactMechanisms
{
    public class PostalAddress : ContactMechanism
    {
        public string Address1 { get; set; }

        public string Address2 {get;set;}

        public City City { get; set; }

        public string Directions { get; set; }

    }
}
