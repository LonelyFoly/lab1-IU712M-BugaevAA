using Lab1.DB;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [ApiController]

    public class PersonController : ControllerBase
    {
        dbHandler handler;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
            handler = new dbHandler(null);
        }

        [HttpGet("persons/{id}")]
        public IActionResult GetPerson(int id)
        {

            var person = handler.getPerson(id);

            if (person == null)  
                return NotFound();
            else
                return Ok(person);
        }

        [HttpGet("persons/")]
        public IActionResult GetPersons()
        {

            //var person = new Person[] { new Person { id = 1, name = "John Doe" }, new Person { id = 2, name = "Joe Peach" } };
            var persons = handler.getPersons();
            return Ok(persons);
        }
        [HttpPost("persons/")]
        public IActionResult PostPerson([FromBody] Person person)
        {

            //var person = new Person[] { new Person { id = 1, name = "John Doe" }, new Person { id = 2, name = "Joe Peach" } };
            handler.addPerson(person);

            return CreatedAtAction(
            actionName: nameof(GetPerson),     // Метод, который возвращает созданный объект
            routeValues: new { id = person.id },  // Параметр маршрута
            value: null   // Пустое тело ответа
            );
        }
        [HttpDelete("persons/{id}")]
        public IActionResult DeletePerson(int id)
        {
            if (!handler.removePerson(id))
                return NotFound();
            return Ok();
        }
        [HttpPatch("persons/{id}")]
        public IActionResult PatchPerson([FromBody] PersonUpdateDto person, int id)
        {

            //var person = new Person[] { new Person { id = 1, name = "John Doe" }, new Person { id = 2, name = "Joe Peach" } };
            if (handler.updatePerson(person, id))
                return Ok();
            else
                return NotFound();
        }



        /*[HttpGet("persons/{personId}")]
        public Person GetPerson(int personId)
        {

            var person = new Person { id = personId, name = "John Doe" };
            return Ok(person);
        }*/
    }
}
