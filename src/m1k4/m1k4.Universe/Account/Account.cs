using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m1k4.Model
{
    public class Account
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Comments { get; set; }

        public AccountType AccountType { get; set; }

        public List<Account> Accounts { get; set; }

    }
}
