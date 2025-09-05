using CardSaverAPi.Models;
using CardSaverAPi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public IActionResult GetAll()
        {
            try
            {
                var cards = _cardService.GetAll();
                return Ok(cards); // return 200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las tarjetas: {ex.Message}"); // return 500
            }
        }

        /* GET BY ID ENDPOINT */
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var card = _cardService.GetById(id);
                if (card == null) return NotFound();
              
                return Ok(card); // return 200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hubo un error al buscar tarjeta: {ex.Message}"); // return 500
            }
        }

        /* POST ENDPOINT */
        [HttpPost]
        public IActionResult Create([FromBody] Card card)
        {
            try
            {
                if (string.IsNullOrEmpty(card.CardNumber) ||
               string.IsNullOrEmpty(card.ExpirationDate) ||
               string.IsNullOrEmpty(card.OwnerName))
                {
                    return BadRequest("Los campos requeridos no fueron completados.");
                }

                _cardService.Add(card);
                return CreatedAtAction(nameof(GetById), new { id = card.Id }, card); // return  201
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar tarjeta: {ex.Message}"); // return 500
            }
        }

        /* PUT ENDPOINT */
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Card updatedCard)
        {
            try
            {
                var existing = _cardService.GetById(id);
                if (existing == null) return NotFound();

                _cardService.Update(id, updatedCard);

                return Ok(existing); // return 200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar tarjeta: {ex.Message}"); // return 500
            }
        }

        /* DELETE ENDPOINT */
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var existing = _cardService.GetById(id);
                if (existing == null) return NotFound();

                _cardService.Delete(id);
                return NoContent();  // return 204
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la tarjeta: {ex.Message}"); // return 500
            }
        }
    }
}
