namespace ClientBankApp.Models.Bank
{
    public sealed class Bank
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Capital { get; set; }

        public DateTime DateOfCreation { get; set; }

    }
}
