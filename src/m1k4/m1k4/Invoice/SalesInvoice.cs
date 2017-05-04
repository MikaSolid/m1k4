namespace m1k4.Model
{
    public class SalesInvoice : Invoice
    {
        public SalesInvoice()
            : base()
        {
            InvoiceRole = InvoiceRoleType.SalesInvoice;
        }
    }
}