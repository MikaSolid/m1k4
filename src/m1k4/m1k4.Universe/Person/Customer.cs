using System.Collections.Generic;

namespace m1k4.Model
{
    public class Customer
    {
        private List<ContactMechanism> _contactMechanisms;

        public readonly static Customer NotSet = new Customer { Name = "Unknown" };

        public string Name { get; set; }

        public List<ContactMechanism> ContactMechanisms
        {
            get { return _contactMechanisms; }
            set { _contactMechanisms = value; }
        }
    }
}