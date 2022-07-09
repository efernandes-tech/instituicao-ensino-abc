using Application.Interfaces;
using Application.ViewModels;
using Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this.usuarioService.Get());
        }

        [HttpPost]
        public IActionResult Post(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.usuarioService.Post(usuarioViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.usuarioService.GetById(id));
        }

        [HttpPut]
        public IActionResult Put(UsuarioViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Put(usuarioViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            string _usuarioId = id;

            return Ok(this.usuarioService.Delete(_usuarioId));
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult Authenticate(UsuarioAuthenticateRequestViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Authenticate(usuarioViewModel));
        }
    }
}
