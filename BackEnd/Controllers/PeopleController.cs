using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.peoples;
    }

    public class Repository
    {
        public static List<People> peoples = new List<People>()
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
