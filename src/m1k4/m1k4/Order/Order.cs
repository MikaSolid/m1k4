using System.Collections.ObjectModel;

namespace m1k4.Model
{
    /// <summary>
    /// U modulu Narudžbine možemo pratiti primljene narudžbine, ponude ili predračune kupcima i date narudžbine, trebovanja ili primljene predračune dobavljača. Narudžbine su opremljene statusima, tako da možemo da ih pratimo kroz celokupan životni ciklus.
    /// Otpremna lista pojednostavljuje rad u većim skladištima, istovremeno ima mogućnost »čvrste rezervacije« - dodeljivanje robe tačno određenom kupcu.CRM mehanizmi nam omogućavaju tekući pristup do svih dokumentacija, povezanih sa kupcima.
    /// Narudžbine mogu biti i osnova za fakturisanje i izdavanje robe i za radne naloge za proizvodnju.Priručnim i jednostavnim funkcijama možemo iz narudžbina kupaca ili dobavljača jednostavno i bez ponovnog unosa podataka da izradimo račun za prijem ili račun za izdavanje robe, a iz narudžbine kupaca možemo da izradimo i radni nalog za proizvodnju.
    /// Na osnovu signalne (minimalne ili optimalne) zalihe ili narudžbine kupaca, program uvažavajući rok isporuke, automatski generiše odgovarajuće narudžbine dobavljačima.Veoma koristan je i pregled izdavanja, jer za svaku poziciju narudžbine vidimo dinamiku nabavke.Vođenje narudžbina kupaca možemo da povežemo sa internet trgovinomB2B ili B2C.
    /// 
    /// Obračun narudžbina
    ///         Pregled naručenog i još neiporučenog od strane kupaca i dobavljača
    ///         Pregled materijalnih potreba
    ///         Analitika upita
    /// </summary>
    public class Order
    {
        private ObservableCollection<OrderItem> _items = new ObservableCollection<OrderItem>();

        public int Id { get; set; }

        public Invoice Invoice { get; set; }

        public ObservableCollection<OrderItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public OrderRoleType Type { get; set; }

        public Invoice GetInvoice()
        {
            Invoice invoice = Type == OrderRoleType.PurchaseOrder ? (Invoice)new PurchaseInvoice() : new SalesInvoice();

            foreach (var orderItem in _items)
                invoice.Items.Add(new InvoiceItem
                {
                    Product = orderItem.Product,
                    Quantity = orderItem.Quantity
                });

            return invoice;
        }
    }
}