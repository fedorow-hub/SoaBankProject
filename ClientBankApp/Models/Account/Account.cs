namespace ClientBankApp.Models.Account
{
    public class Account
    {
        public Guid Id { get; set; }
        /// <summary>
        /// идентификационный номер клиента, которому принадлежит счет
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// дата и время создания счета
        /// </summary>
        public DateTime TimeOfCreated { get; set; }

        /// <summary>
        /// сумма, лежащая на счете
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// дата, до которой действует счет
        /// </summary>
        public DateTime AccountTerm { get; set; }

        /// <summary>
        /// действующий или закрытый счет
        /// </summary>
        public bool IsExistance { get; set; }

        public string Type { get; set; }

    }
}
