using ControllerSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostSampleController : ControllerBase
    {

        [HttpPost("InsertCarModel")]
        //Request URL -> https://localhost:7088/api/PostSample/InsertCarModel 
        // Car Objekt wird in HTTP - Body mitgesendet
        public IActionResult InsertCarModel(Car car) //Body wird hier verwendet 
        {
            //Speichere Datensatz

            return Ok();
        }

        [HttpPost("InsertCarModelAsQuery")]
        //Request URL https://localhost:7088/api/PostSample/InsertCarModelAsQuery?Id=0&Brand=VW&Model=Polo
        //Car Object wird als URL QueryString mitgesendet 
        public IActionResult InsertCarModelAsQuery([FromQuery] Car car)
        {
            return Ok();
        }


        [HttpPost("InsertString")]
        //Request URL -> https://localhost:7088/api/PostSample/InsertString?name=Otto
        public IActionResult InsertString(string name)
        {
            return Ok();
        }

        [HttpPost("InsertString2/{name}")]
        //Request URL -> https://localhost:7088/api/PostSample/InsertString2/Otto
        public IActionResult InsertString2(string name)
        {
            return Ok();
        }

        [HttpPost("InsertString3")]
        //Request URL -> https://localhost:7088/api/PostSample/InsertString3 
        //string Name wird als JSON im HTTP-Body mitgeliefert und am Ende mit ModelBinding in die Variable name gemappt
        public IActionResult InsertString3([FromBody] string name)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCar(int id, Car car)
        {
            if (id != car.Id)
                return BadRequest();

            return Ok();
        }



    }
}
