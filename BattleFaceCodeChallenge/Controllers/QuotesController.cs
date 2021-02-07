using System.Threading.Tasks;
using BattleFaceCodeChallenge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BattleFaceCodeChallenge.Controllers
{
    [ApiController]
    [Route("quotes")]
    [Authorize]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesService _quotesService;

        public QuotesController(IQuotesService QuoteService)
        {
            _quotesService = QuoteService;
        }

        [HttpPost]
        [Route("quotation")]
        public async Task<IActionResult> CalculateQuote([FromBody] QuoteRequest quote)
        {
            try
            {
                if (ModelState.IsValid) return Ok(await _quotesService.CalculateQuote(quote));
                else return BadRequest(quote);
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
