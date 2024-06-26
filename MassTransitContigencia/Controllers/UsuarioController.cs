using MassTransitContigencia.ApplicationSerivce.Interfaces;
using MassTransitContigencia.Models;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitContigencia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        readonly IApplicationServiceUsuario _applicationServicePublisher;
        public UsuarioController(IApplicationServiceUsuario applicationServicePublisher)
        {
            _applicationServicePublisher = applicationServicePublisher;
        }


        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            _applicationServicePublisher.CadastrarUsuario(usuario);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var usuariosList = _applicationServicePublisher.GetAll();
            return Ok(usuariosList);
        }
    }
}