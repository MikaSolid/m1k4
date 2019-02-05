using System;

namespace m1k4.Model
{
    public class InvoiceRole
    {
        public int PartyId { get; set; }

        public Party Party { get; set; }

        public InvoiceRoleType Role { get; set; }

        public DateTime DateTime { get; set; }
    }
}
