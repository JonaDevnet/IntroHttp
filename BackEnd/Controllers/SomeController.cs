using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {

            //Cronometro
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Thread.Sleep(1000);
            Console.WriteLine("Conexion a BD terminada");

            Thread.Sleep(1000);
            Console.WriteLine("Envio de mail teminado");

            Console.WriteLine("Todo finalizado");
            stopwatch.Stop();

            //Medimos el tiempo en milisegundos
            long tiempoEnMs = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Tardo: {tiempoEnMs} ms");

            //otra opcion en horas:minutos,segundos
            TimeSpan tiempoTotal = stopwatch.Elapsed;
            Console.WriteLine($"Tardo: {tiempoTotal.TotalSeconds} s");

            return Ok();
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            var task1 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a BD terminada");
            });

            task1.Start();

            Console.WriteLine("Haciendo otra cosa");

            await task1;

            Console.WriteLine("Todo ha terminado");

            return Ok();
        }
    }
}
