using System.Collections.Generic;
namespace m1k4.Model
{
    public class Company : LegalOrganization
    {
        private List<ContactMechanism> _contactMechanisms = new List<ContactMechanism>();

        public int DefaultPaymentDays { get; set; }

        public string Account { get; set; }  

        public string CompanyNumber { get; set; }

        public string TaxNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ContactPerson { get; set; }

        public string Comments { get; set; }

        public List<ContactMechanism> ContactMechanisms
        {
            get
            {
                return _contactMechanisms;
            }
            set
            {
                _contactMechanisms = value;
            }
        }

        public  Customer ToCustomer()
        {
            var c = new Customer();
            c.Name = Name;
            c.ContactMechanisms = ContactMechanisms;
            return c;
        }

    }
}