namespace ClientBankApp.Models.Account
{
    public class TransactionModel
    {
        public Guid FromAccountId { get; init; }
        public Guid DestinationAccountId { get; init; }
        public decimal Amount { get; init; }
    }
}
