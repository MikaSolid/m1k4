namespace m1k4.Model
{
    public class PurchaseInvoice : Invoice
    {
        public PurchaseInvoice() : base()
        {
            InvoiceRole = InvoiceRoleType.PurchaseInvoice;
        }
    }
}
