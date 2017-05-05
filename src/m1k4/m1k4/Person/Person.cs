using System;
using System.Collections.Generic;

namespace m1k4.Model
{
    public class Person : Party
    {
        private List<ContactMechanism> _contactMechanisms = new List<ContactMechanism>();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(NickName))
                {
                    return NickName;
                }

                return String.Format("{0}{1}{2}", FirstName, String.IsNullOrEmpty(LastName) ? String.Empty : " ", LastName);
            }
        }


        public string Comment { get; set; }

        public DateTime BirthDate { get; set; }

        public IEnumerable<Role> Roles { get; set; }
        
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

        public Customer ToCustomer()
        {
            var c = new Customer();
            c.Name = Name;
            c.ContactMechanisms = ContactMechanisms;
            return c;
        }

    }
}