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
    public class PagamentoController : ControllerBase
    {
        private readonly PagamentoService _pagamentoService;

        public PagamentoController(PagamentoService pagamentoService)
        {
            this._pagamentoService = pagamentoService;
        }

        [HttpGet]
        public IActionResult ReadPagamentos()
        {
            return Ok(this._pagamentoService.ReadPagamentos());
        }

        [HttpGet("{id}")]
        public IActionResult ReadPagamentoPorId(string Id)
        {
            var _contrato = this._pagamentoService.ReadPagamentoPorId(Int32.Parse(Id));
            return Ok(_contrato);
        }
    }
}
