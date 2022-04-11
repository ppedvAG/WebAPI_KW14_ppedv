using ControllerSamples.Data;
using ControllerSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))] //Default-Convention für eine komplette Controller - Klasse 
    public class ConventionsController : ControllerBase
    {
        private readonly IContactRepository contactRepository;

        public ConventionsController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status406NotAcceptable)]
        
        
        public ActionResult<Contact> GetContact(int? id)
        {
            if (!id.HasValue)
                return BadRequest(); //400

            Contact contact = contactRepository.Get(id.Value);

            if (contact == null)
                return NotFound(); //404


            return Ok(contact);
        }

        [HttpPost]
        //Default-Einstellung 
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public IActionResult Insert(Contact contact)
        {
            contactRepository.Add(contact);
            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        [HttpPut]
        public IActionResult Update(int id, Contact contact)
        {
            if (id != contact.Id)
                return BadRequest(); //400

            contactRepository.Update(contact);

            return NoContent(); //204
        }



    }
}
