using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace MaisCultura.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ILogger<EventosController> _logger;

        public EventosController(ILogger<EventosController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IEnumerable<Evento> Post(ParametrosFeed parametrosFeed)
        {
            ListaEvento listaEvento = new ListaEvento();

            return listaEvento.Feed(parametrosFeed.usuario);
        }
    }
}