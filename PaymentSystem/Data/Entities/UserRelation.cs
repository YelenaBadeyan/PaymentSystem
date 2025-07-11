namespace PaymentSystem.Data.Entities
{
    public class UserRelation
    {
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public string RelationType { get; set; }
    }
}
