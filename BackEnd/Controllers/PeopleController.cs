using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.people;

        [HttpGet("{id}")]                 // First func de orden superior recibe una funcion  
        // ActionResult nos permite retornar la exepcion adecuada
        public ActionResult<People> Get(int id) 

            // Obtenemos el recurso
            { var people = Repository.people.FirstOrDefault(p => p.Id == id); 
            
            if (people == null)
            {
                return NotFound(); // Retornamos 404
            }

            return Ok(people); // Retornamos 200 con el recurso
        }
            

        [HttpGet("search/{search}")]
        public List<People> Get(string search) => // prog declarativa
            Repository.people.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost("add")]
        public IActionResult Add(People people)
        {
            if (string.IsNullOrEmpty(people.Name))
            {
                return BadRequest(); // Retornamos 400 
            }

            Repository.people.Add(people);

            return NoContent(); // Retornamos 204, ok pero sin contenido
        }
    }

    public class Repository // Simulacion de base de datos que contiene retorno una lista
    {
        public static List<People> people = new List<People>()
        {
            new People()
            {
                Id=1, Name="Juan", Birthdate=new DateTime(1990,1,1)
            },
            new People()
            {
                Id=2, Name="Ana", Birthdate=new DateTime(1985,5,23)
            },
            new People()
            {
                Id=3, Name="Luis", Birthdate=new DateTime(2000,12,12)
            },
            new People ()
            {
                Id=4, Name="Maria", Birthdate=new DateTime(1995,7,30)
            }
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
