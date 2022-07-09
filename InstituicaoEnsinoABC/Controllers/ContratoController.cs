using DataLayer.Context;
using DataLayer.Models;
using InstituicaoEnsinoABC.Services;
using InstituicaoEnsinoABC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ContratoController : ControllerBase
    {
        private readonly ContratoService _contratoService;

        public ContratoController(ContratoService contratoService)
        {
            this._contratoService = contratoService;
        }

        [HttpGet]
        public IActionResult ReadContratos()
        {
            return Ok(this._contratoService.ReadContratos());
        }

        [HttpGet("{id}")]
        public IActionResult ReadContratoPorId(string Id)
        {
            var _contrato = this._contratoService.ReadContratoPorId(Int32.Parse(Id));
            return Ok(_contrato);
        }

        [HttpGet("parcela/{id}/{idcontrato}")]
        public async Task<IActionResult> ReadParcelaPorId(string Id, string IdContrato)
        {
            var _parcela = await this._contratoService.ReadParcelaPorId(Int32.Parse(Id), Int32.Parse(IdContrato));

            return Ok(_parcela);
        }
    }
}
