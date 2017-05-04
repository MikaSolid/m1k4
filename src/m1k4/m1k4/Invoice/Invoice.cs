using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace m1k4.Model
{
    public abstract class Invoice
    {

        #region Private members

        private ObservableCollection<InvoiceItem> _items = new ObservableCollection<InvoiceItem>();
        private List<PartyRole> _partyRoles = new List<PartyRole>();
        private List<InvoiceStatus> _invoiceStatus = new List<InvoiceStatus>();

        #endregion

        #region Constructors and Factory methods

        public Invoice()
        {
            Date = DateTime.Now;
            AddStatus(InvoiceStatusType.New);
            Customer = Customer.NotSet;
        }

        //public Invoice()
        //{
        //    Invoice invoice = type == InvoiceType.SalesInvoice ? (Invoice)new SalesInvoice() : new PurchaseInvoice();
        //    invoice.Date = DateTime.Now;
        //    invoice.AddStatus(InvoiceStatusType.New);
        //    return invoice;
        //}

        //public static Invoice Create(InvoiceType type, Company party)
        //{
        //    var invoice = Create(type);
        //    invoice.Company = party;
        //    return invoice;
        //}

        #endregion

        #region Properties
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? DueDate { get; set; }

        public InvoiceRoleType InvoiceRole { get; set; }

        public List<PartyRole> PartyRoles
        {
            get { return _partyRoles; }
            set { _partyRoles = value; }
        }

        public List<InvoiceStatus> InvoiceStatus
        {
            get { return _invoiceStatus; }
            set { _invoiceStatus = value; }
        }

        public decimal Amount { get { return Items.Sum(i => i.TotalPrice); } }

        public string Code { get; set; }

        public bool IsPayed { get; set; }

        public ObservableCollection<InvoiceItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public Order Order { get; set; }

        #endregion

        private void AddStatus(InvoiceStatusType status)
        {
            InvoiceStatus.Add(new InvoiceStatus
            {
                DateTime = DateTime.Now,
                Status = status
            });
        }

        public void SetAmount(string amount)
        {
            var val = Convert.ToDecimal(amount);

            InvoiceItem item = _items.FirstOrDefault();

            if (item == null)
            {
                item = new InvoiceItem();
                _items.Add(item);
            }

            item.Quantity = val;
        }
    }
}