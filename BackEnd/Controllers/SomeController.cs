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

            //Cronometro
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a BD terminada ASYNC");
                return 1;
            });

            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio de mail teminado ASYNC");
                return 2;
            });

            task1.Start();
            task2.Start(); // se ejecuta en subprocesos

            Console.WriteLine("Haciendo otra cosa ASYNC");

            var result1 = await task1;
            var result2 = await task2;

            Console.WriteLine("Todo ha terminado ASYNC");

            stopwatch.Stop();

            //Medimos el tiempo en milisegundos
            long tiempoEnMs = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Tardo: {tiempoEnMs} ms ASYNC");

            //otra opcion en horas:minutos,segundos
            TimeSpan tiempoTotal = stopwatch.Elapsed;
            Console.WriteLine($"Tardo: {tiempoTotal.TotalSeconds} s ASYNC");

            return Ok(result1 + " " + result2 + " " + stopwatch.Elapsed);
        }
    }
}
