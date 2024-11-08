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

        [HttpGet("/api/v1/persons/{id}")]
        public IActionResult GetPerson(int id)
        {

            var person = handler.getPerson(id);

            if (person == null)  
                return NotFound();
            else
                return Ok(person);
        }

        [HttpGet("/api/v1/persons/")]
        public IActionResult GetPersons()
        {
            var persons = handler.getPersons();
            return Ok(persons);
        }
        [HttpPost("/api/v1/persons/")]
        public IActionResult PostPerson([FromBody] Person person)
        {
            handler.addPerson(person);

            return CreatedAtAction(
            actionName: nameof(GetPerson),    
            routeValues: new { id = person.id },  
            value: null   
            );
        }
        [HttpDelete("/api/v1/persons/{id}")]
        public IActionResult DeletePerson(int id)
        {
            if (!handler.removePerson(id))
                return NotFound();
            return NoContent();
        }
        [HttpPatch("/api/v1/persons/{id}")]
        public IActionResult PatchPerson([FromBody] PersonUpdateDto person, int id)
        {
            if (handler.updatePerson(person, id))
                return Ok(new Person(id, person.name, person.address,
                    person.work, person.age));
            else
                return NotFound();
        }




    }
}
