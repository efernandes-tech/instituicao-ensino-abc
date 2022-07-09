using DataLayer.Context;
using DataLayer.Models;
using InstituicaoEnsinoABC.DTO;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Services
{
    public class AlunoService
    {
        private InstituicaoEnsinoABCDbContext _db;

        public AlunoService(InstituicaoEnsinoABCDbContext dBContext)
        {
            _db = dBContext;
        }

        public List<AlunoViewModel> ReadAlunos()
        {
            var _listAlunoViewModel = new List<AlunoViewModel>();

            var _alunosDb = _db.Alunos.Include(x => x.Contratos).ToList();

            foreach (Aluno aluno in _alunosDb)
            {
                _listAlunoViewModel.Add(DataTransferObject.AlunoDTO(aluno));
            }

            return _listAlunoViewModel;
        }

        public AlunoViewModel CreateAluno(AlunoViewModel alunoViewModel)
        {
            var aluno = new Aluno
            {
                NomeCompleto = alunoViewModel.NomeCompleto,
                Cpf = alunoViewModel.Cpf,
                DataNascimento = DateTime.Parse(alunoViewModel.DataNascimento),
                EnderecoCompleto = alunoViewModel.EnderecoCompleto
            };
            _db.Alunos.Add(aluno);
            _db.SaveChanges();
            alunoViewModel.Id = aluno.Id;
            return alunoViewModel;
        }

        public AlunoViewModel ReadAlunoPorId(int id)
        {
            var aluno = _db.Alunos.FirstOrDefault(x => x.Id == id);

            return DataTransferObject.AlunoDTO(aluno);
        }

        public AlunoViewModel UpdateAluno(AlunoViewModel alunoViewModel)
        {
            var aluno = _db.Alunos.Find(alunoViewModel.Id);

            aluno.NomeCompleto = alunoViewModel.NomeCompleto;
            aluno.Cpf = alunoViewModel.Cpf;
            aluno.DataNascimento = DateTime.Parse(alunoViewModel.DataNascimento);
            aluno.EnderecoCompleto = alunoViewModel.EnderecoCompleto;

            _db.SaveChanges();

            alunoViewModel.Id = aluno.Id;

            return alunoViewModel;
        }

        public bool DeleteAluno(AlunoViewModel alunoViewModel)
        {
            try
            {
                var aluno = _db.Alunos.Find(alunoViewModel.Id);
                _db.Alunos.Remove(aluno);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
