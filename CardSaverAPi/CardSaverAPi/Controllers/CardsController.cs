using CardSaverAPi.Models;
using CardSaverAPi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardSaverAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        /* Instanciating the card service*/

        private readonly CardService _cardService = new CardService();

        /* GET ENDPOINT */

        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetAll() => _cardService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Card> GetById(string id)
        {
            var card = _cardService.GetById(id);
            if (card == null) return NotFound();
            return card;
        }

        /* POST ENDPOINT */

        [HttpPost]
        public ActionResult<Card> Add(Card card)
        {
            if (string.IsNullOrEmpty(card.CardNumber) ||
                string.IsNullOrEmpty(card.ExpirationDate) ||
                string.IsNullOrEmpty(card.OwnerName))
            {
                return BadRequest("Los campos requeridos no fueron completados.");
            }

            _cardService.Add(card);
            return CreatedAtAction(nameof(GetById), new { id = card.Id }, card);
        }

        /* PUT ENDPOINT */

        [HttpPut("{id}")]
        public IActionResult Update(string id, Card card)
        {
            var existing = _cardService.GetById(id);
            if (existing == null) return NotFound();

            _cardService.Update(id, card);
            return NoContent();
        }

        /* DELETE ENDPOINT */

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var existing = _cardService.GetById(id);
            if (existing == null) return NotFound();

            _cardService.Delete(id);
            return NoContent();
        }
    }
}
