namespace PaymentSystem.Data.Entities
{
    public class BankCards
    {
        public int ID { get; set; }
        public int CardNumber { get; set; }
        public DateTime ValidTo { get; set; }
        public int CVV { get; set; }
        public string BankName { get; set; }



    }
}
