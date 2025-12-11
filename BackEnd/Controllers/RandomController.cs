using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRandomService _randomServiceSingleton;
        private IRandomService _randomServiceScoped;
        private IRandomService _randomServiceTransient;

        private IRandomService _randomServiceSingleton2;
        private IRandomService _randomServiceScoped2;
        private IRandomService _randomServiceTransient2;

        /// <summary>
        /// Initializes a new instance of the RandomController class with the specified random service dependencies for
        /// singleton, scoped, and transient lifetimes.
        /// </summary>
        /// <remarks>This constructor allows the controller to access multiple instances of IRandomService
        /// with different lifetimes and keys, which can be useful for demonstrating or testing dependency injection
        /// behaviors in ASP.NET Core applications.</remarks>
        /// <param name="randomServiceSigleton">The singleton instance of the random service, resolved from keyed services with the key "randomSigleton".</param>
        /// <param name="randomServiceScoped">The scoped instance of the random service, resolved from keyed services with the key "randomScoped".</param>
        /// <param name="randomServiceTransient">The transient instance of the random service, resolved from keyed services with the key "randomTransient".</param>
        /// <param name="randomService2">An additional singleton instance of the random service, resolved from keyed services with the key
        /// "randomSigleton".</param>
        /// <param name="randomServiceScoped2">An additional scoped instance of the random service, resolved from keyed services with the key
        /// "randomScoped".</param>
        /// <param name="randomServiceTransient2">An additional transient instance of the random service, resolved from keyed services with the key
        /// "randomTransient".</param>
        public RandomController(
            [FromKeyedServices("randomSigleton")] IRandomService randomServiceSigleton,
            [FromKeyedServices("randomScoped")] IRandomService randomServiceScoped,
            [FromKeyedServices("randomTransient")] IRandomService randomServiceTransient,
            [FromKeyedServices("randomSigleton")] IRandomService randomServiceSingleton2,
            [FromKeyedServices("randomScoped")] IRandomService randomServiceScoped2,
            [FromKeyedServices("randomTransient")] IRandomService randomServiceTransient2
            )
        {
            _randomServiceSingleton = randomServiceSigleton;
            _randomServiceScoped = randomServiceScoped;
            _randomServiceTransient = randomServiceTransient;
            _randomServiceSingleton2 = randomServiceSingleton2;
            _randomServiceScoped2 = randomServiceScoped2;
            _randomServiceTransient2 = randomServiceTransient2;

        }

        ///Asi veremos si los objetos son los mismos o no
        ///porque en su constructor generan un numero aleatorio
        /*
         * OUTPUT
         {
              "Singleton 1": 88,
              "Scoped 1": 66,
              "Transient 1": 48,
              "Singleton 2": 88,
              "Scoped 2": 66,
              "Transient 2": 32
          }
         */
        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get()
        {
            var result = new Dictionary<string, int>();

            result.Add("Singleton 1", _randomServiceSingleton.Value);
            result.Add("Scoped 1", _randomServiceScoped.Value);
            result.Add("Transient 1", _randomServiceTransient.Value);

            result.Add("Singleton 2", _randomServiceSingleton2.Value);
            result.Add("Scoped 2", _randomServiceScoped2.Value);
            result.Add("Transient 2", _randomServiceTransient2.Value);

            return result;
        }

    }
}
