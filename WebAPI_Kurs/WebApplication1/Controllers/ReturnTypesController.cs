using ControllerSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerSamples.Controllers
{
    //https://localhost:12345/api/ReturnTypes
    [Route("api/[controller]")]
    [ApiController] //Gibt an, dass wir eine WebAPI verwenden (MVC Controller verwenden keine Attribute)
    public class ReturnTypesController : ControllerBase
    {
        //.NET Core Native Datentypen kann man zurück gegeben (string, int, decimal, DateTime...)


        //OHNE HttpVerb -> Minimale Konvention (Swagger versteht diese leider nicht) 
        #region Native Datentypen
        //HttpGet -> HttpVerb
        [HttpGet] //URL -> https://localhost:7088/api/ReturnTypes
        public string HelloWorld()
        {
            return "Hello World";
        }


        //ContentResult gibt einen string zurück
        //URL von der Roote aus -> Absolute Route -> https://localhost:7088/GetCurrentTime
        [HttpGet("/GetCurrentTime")]
        public ContentResult GetCurrenTime()
        {
            return Content(DateTime.Now.ToString());
        }

        [HttpGet("GetCurrentTime2")] // Erweiterung der Route -> https://localhost:7088/api/ReturnTypes/GetCurrentTime2
        public ContentResult GetCurrenTime2()
        {
            return Content(DateTime.Now.ToString());
        }
        #endregion


        #region Complexe Datentypen
        [HttpGet("GetComplexObject")]
        //Komplexe Objekte werden als JSON Serialisiert und zurück gegeben
        public Car GetComplexObject()
        {
            Car car = new();
            car.Id = 1;
            car.Brand = "Porsche";
            car.Model = "911er";

            return car; //Das ist die einziste Möglichkeit etwas zurück zu geben. Und nur vom Typ 'Car'
        }

        #endregion

        #region IActionResult + ActionResult

        //TEIL 1: Synchron
        //ActionResult -> Bei Get-Methoden (StatusaCode + Datensatz) -> kann aber gegenüber IActionResult, mehrere Rückgabe Formate (FileResult oder FileStream) 

        //IActionResult -> Bei POST / PUI / Delete (Nur Statuscodes + Datensatz) 

        [HttpGet("GetCarWith_IActionResult")]
        public IActionResult GetCarWith_IActionResult()
        {
            Car car = new();
            car.Id = 1;
            car.Brand = "Porsche";
            car.Model = "911er";

            if (car.Brand != "Prosche")
                return BadRequest(); //400

            if (car.Brand == String.Empty)
                return NotFound(); //404

            return Ok(car); //200 bei Get
        }

        [HttpGet("GetCarWith_ActionResult")]
        public ActionResult GetCarWith_ActionResult()
        {
            Car car = new();
            car.Id = 1;
            car.Brand = "Porsche";
            car.Model = "911er";

            if (car.Brand != "Prosche")
                return BadRequest(); //400

            if (car.Brand == String.Empty)
                return NotFound(); //404

            return Ok(car); //200 bei Get
        }





        // Asynchrone Methoden mit async / await
        [HttpGet("GetCarWith_IActionResultAsync")]
        public async Task<IActionResult> GetCarWith_IActionResultAsync()
        {
            await Task.Delay(1000);
            Car car = new();
            car.Id = 1;
            car.Brand = "Porsche";
            car.Model = "911er";

            if (car.Brand != "Prosche")
                return BadRequest(); //400

            if (car.Brand == String.Empty)
                return NotFound(); //404

            return Ok(car); //200 bei Get
        }

        [HttpGet("GetCarWith_ActionResultAsync")]
        public async Task<ActionResult> GetCarWith_ActionResultAsync()
        {
            await Task.Delay(1000);
            Car car = new();
            car.Id = 1;
            car.Brand = "Porsche";
            car.Model = "911er";

            if (car.Brand != "Prosche")
                return BadRequest(); //400

            if (car.Brand == String.Empty)
                return NotFound(); //404

            return Ok(car); //200 bei Get
        }

        #endregion


        [HttpGet("GetCarIEnumerable")]
        public IEnumerable<Car> GetCarIEnumerable()
        {
            Car car = new();
            car.Id = 1;
            car.Brand = "Porsche";
            car.Model = "911er";


            Car car1 = new();
            car1.Id = 2;
            car1.Brand = "Audi";
            car1.Model = "Quatro";

            Car car2 = new();
            car2.Id = 3;
            car2.Brand = "VW";
            car2.Model = "Polo";

            List<Car> carList = new List<Car>();
            carList.Add(car);
            carList.Add(car1);
            carList.Add(car2);


            foreach (Car currentCar in carList)
                yield return currentCar; //Wir bleiben in der Schleife und geben jeden einzelenen Datensatz raus. 


        } //Wir verlassen hier die Methode


        //Erst Ab ASP.NET Core 3.1 -> Fehlerfrei 
        [HttpGet("GetCarIAsyncEnumerable")]
        public async IAsyncEnumerable<Car> GetCarIEnumerableAsync()
        {

            Car car = new();
            car.Id = 1;
            car.Brand = "Porsche";
            car.Model = "911er";


            Car car1 = new();
            car1.Id = 2;
            car1.Brand = "Audi";
            car1.Model = "Quatro";

            Car car2 = new();
            car2.Id = 3;
            car2.Brand = "VW";
            car2.Model = "Polo";

            List<Car> carList = new List<Car>();
            carList.Add(car);
            carList.Add(car1);
            carList.Add(car2);


            foreach (Car currentCar in carList)
            {
                await Task.Delay(1000);
                yield return currentCar; //Wir bleiben in der Schleife und geben jeden einzelenen Datensatz raus. 
            }
                


        } //Wir verlassen hier die Methode

    }
}
