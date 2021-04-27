﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.Domain;


namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/evento")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;

        public EventoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
        }
    }
}