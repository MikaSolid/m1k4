namespace m1k4.Model
{
    public class CompanyInfo : Organization
    {
        public CompanyInfo() { }

        public CompanyInfo(Company company) 
        {
            Id = company.Id;
            Name = company.Name;
            BillingAccount = company.Account;
            Code = company.Code;
        }
        

        public string BillingAccount { get; set; }
    }
}