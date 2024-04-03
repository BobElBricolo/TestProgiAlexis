using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProgiBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoitureController : ControllerBase
    {

        public VoitureController()
        {
        }


        /// <summary>
        /// GET permettant de créer une voiture ordinaire selon le prix
        /// </summary>
        /// <param name="prix"> Le prix de la voiture</param>
        /// <returns> La voiture ordinaire</returns>
        [HttpGet("voitureOrdinaire")]
        public IActionResult GetVoitureOrdinaire(string prix)
        {
            try
            {
                var voiture = new VoitureOrdinaire(decimal.Parse(prix));
                return Ok(voiture);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// GET permettant de créer une voiture de luxe selon le prix
        /// </summary>
        /// <param name="prix"> Le prix de la voiture</param>
        /// <returns> La voiture de luxe</returns>
        [HttpGet("voitureLuxe")]
        public IActionResult GetVoitureLuxe(string prix)
        {
            try
            {
                var voiture = new VoitureLuxe(decimal.Parse(prix));
                return Ok(voiture);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

    }
}