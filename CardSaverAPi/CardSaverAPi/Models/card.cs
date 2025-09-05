namespace CardSaverAPi.Models
{
        public class Card
        {
            public string Id { get; set; } = Guid.NewGuid().ToString();
            public string CardNumber { get; set; } = string.Empty;
            public string ExpirationDate { get; set; } = string.Empty;
            public string OwnerName { get; set; } = string.Empty;
            public string CVV { get; set; } = string.Empty;
        }
}
