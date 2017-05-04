using System;

namespace m1k4.Model
{
    public class PartyRole
    {
        public int PartyId { get; set; }

        public PartyRoleType RoleId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}