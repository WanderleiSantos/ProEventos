using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/evento")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return new Evento[]
            {
                new Evento()
                {
                    EventoId = 1,
                    Tema = "Angular",
                    Local = "BH",
                    Lote = "1545",
                    QtdPessoas = 154,
                    DataEvento = DateTime.Now.AddDays(2).ToString(),
                    ImagemURL = "fot.png"
                }
            };
        }
    }
}