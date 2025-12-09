using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        public decimal Add(Numbers numbres, [FromHeader] string Host,
            //Asi para poder capturar parametros que no concuendas
            // con la escritura de c#
            [FromHeader(Name = "Content-Length")] string ContentLength,
            [FromHeader(Name = "X-Some")] string Some)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);
            Console.WriteLine(Some);
            return numbres.a - numbres.b;
        }

        [HttpPut]
        public decimal Edit(decimal a, decimal b)
        {
            return a * b;
        }

        [HttpDelete]
        public decimal Delete(decimal a, decimal b)
        {
            return a / b;
        }
    }

    public class Numbers // clase para mapear el json
    {
        public decimal a { get; set; }
        public decimal b { get; set; }
    }
}
