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
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _alunoService;

        public AlunoController(AlunoService alunoService)
        {
            this._alunoService = alunoService;
        }

        [HttpGet]
        public IActionResult ReadAlunos()
        {
            return Ok(this._alunoService.ReadAlunos());
        }

        [HttpPost]
        public IActionResult CreateAluno(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Alunos = this._alunoService.CreateAluno(alunoViewModel);
            return Ok(Alunos);
        }

        [HttpGet("{id}")]
        public IActionResult ReadAlunoPorId(string id)
        {
            var Alunos = this._alunoService.ReadAlunoPorId(Int32.Parse(id));

            return Ok(Alunos);
        }

        [HttpPut]
        public IActionResult UpdateAluno(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Alunos = this._alunoService.UpdateAluno(alunoViewModel);
            return Ok(Alunos);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(string id)
        {
            AlunoViewModel alunoViewModel = new AlunoViewModel
            {
                Id = Int32.Parse(id)
            };

            var Alunos = this._alunoService.DeleteAluno(alunoViewModel);
            return Ok(Alunos);
        }
    }
}
