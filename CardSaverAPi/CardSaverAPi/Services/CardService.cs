using CardSaverAPi.Models;
using System.Text.Json;

namespace CardSaverAPi.Services
{
    public class CardService


    {
        /* defining the path*/
        private readonly string cardsFilePath = "cards.json";

        /* Save method */
        private void Save(List<Card> cards)
        {
            var json = JsonSerializer.Serialize(cards, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(cardsFilePath, json);
        }

        /* Get all the cards from the json*/
        public List<Card> GetAll()
        {
            if (!File.Exists(cardsFilePath))
                return new List<Card>();

            var json = File.ReadAllText(cardsFilePath);
            return JsonSerializer.Deserialize<List<Card>>(json) ?? new List<Card>();
        }

        /* Get the card by ID */
        public Card? GetById(string id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        /* Adding a card */
        public void Add(Card card)
        {
            /* getting all the cards then adding on top and saving */
            var cards = GetAll();
            //generating a unique id
            card.Id = Guid.NewGuid().ToString();
            cards.Add(card);
            Save(cards);
        }

        /* Updating a card */
        public void Update(string id, Card updatedCard)
        {
            /* getting all the cards and looking with the id */
            var cards = GetAll();
            var index = cards.FindIndex(c => c.Id == id);
            if (index != -1)
            {
                updatedCard.Id = id;
                cards[index] = updatedCard;
                Save(cards);
            }
        }

        /* Delete a card */
        public void Delete(string id)
        {
            var cards = GetAll();
            cards.RemoveAll(c => c.Id == id);
            Save(cards);
        }

    
}
}
